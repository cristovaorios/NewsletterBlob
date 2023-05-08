using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.Model
{
    internal class NoticiaDAO
    {
        //Adicionar Notícia
        public void adicionarNoticia(int idAutor, Noticia noticia)
        {

            try
            {
                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                command.CommandText = $"INSERT INTO tb_noticia (id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao)" +
                    $"VALUES (@id_autor, @titulo, @subtitulo, @texto, @imagem, @categoria, @autores, @data_publicacao)";
                command.Parameters.AddWithValue("@id_autor", idAutor);
                command.Parameters.AddWithValue("@titulo", noticia.Titulo);
                command.Parameters.AddWithValue("@subtitulo", noticia.SubTitulo);
                command.Parameters.AddWithValue("@texto", noticia.Texto);
                command.Parameters.AddWithValue("@imagem", noticia.Imagem);
                command.Parameters.AddWithValue("@categoria", noticia.Categoria);
                command.Parameters.AddWithValue("@autores", noticia.Autores);
                command.Parameters.AddWithValue("@data_publicacao", noticia.DataPublicacao.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Ler Notícia
        public Noticia listarNoticia(int id)
        {
            try
            {
                Noticia noticia = new Noticia();

                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"SELECT id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao FROM tb_noticia WHERE id_noticia = @id;";
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    noticia = new Noticia(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), (byte[])reader["imagem"],
                    reader.GetString(5), reader.GetString(6), reader.GetDateTime(7));
                }
                //Retornando o leitor
                return noticia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
