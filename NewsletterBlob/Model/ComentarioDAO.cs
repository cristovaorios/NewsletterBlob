using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    internal class ComentarioDAO
    {
        //Adicionar Notícia
        public void adicionarNoticia(int idAutor, Comentario comentario)
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
                command.CommandText = $"INSERT INTO tb_comentario (id_autor, id_noticia, imagem, texto)" +
                    $"VALUES (@id_autor, @id_noticia, @imagem, @texto)";
                command.Parameters.AddWithValue("@id_autor", idAutor);
                command.Parameters.AddWithValue("@id_noticia", comentario.IdNoticia);
                command.Parameters.AddWithValue("@imagem", comentario.ImagemAutor);
                command.Parameters.AddWithValue("@texto", comentario.Texto);
                command.Prepare();
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
                command.CommandText = $"SELECT id_noticia, id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao, qtd_curtidas FROM tb_noticia WHERE id_noticia = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    int idNoticia = reader.GetInt32(0);
                    int idAutor = reader.GetInt32(1);
                    string titulo = reader.GetString(2);
                    string subtitulo = reader.GetString(3);
                    string texto = reader.GetString(4);
                    byte[] imagem = (byte[])reader["imagem"];
                    string categoria = reader.GetString(6);
                    string autores = reader.GetString(7);
                    DateTime dataPublicacao = reader.GetDateTime(8);
                    int qtdCurtidas = 0;
                    if (!reader.IsDBNull(9))
                    {
                        qtdCurtidas = reader.GetInt32(9);
                    }
                    noticia = new Noticia(idNoticia, idAutor, titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao, qtdCurtidas);
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

        //Listar noticias por Autor
        public List<Noticia> listarNoticiaPorAutor(string identificador)
        {
            try
            {
                List<Noticia> noticias = new List<Noticia>();

                int id = getIdAutorByIdentificador(identificador);

                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT id_noticia, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao FROM tb_noticia WHERE id_autor = @id;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
                            while (reader.Read())
                            {
                                int idNoticia = reader.GetInt32(0);
                                string titulo = reader.GetString(1);
                                string subtitulo = reader.GetString(2);
                                string texto = reader.GetString(3);
                                byte[] imagem = (byte[])reader["imagem"];
                                string categoria = reader.GetString(5);
                                string autores = reader.GetString(6);
                                DateTime dataPublicacao = reader.GetDateTime(7);

                                Noticia noticia = new Noticia(idNoticia, titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao);
                                noticias.Add(noticia);
                            }
                        }
                    }
                }
                // Retorna as notícias encontradas
                return noticias;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int getIdAutorByIdentificador(string identificador)
        {
            try
            {
                int id = 0;

                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"SELECT id_autor FROM tb_usuario_autor WHERE registro_profissional = @identificador;";
                command.Parameters.AddWithValue("@identificador", identificador);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                //Retornando id do autor
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //Deletar
        public int deletarNoticia(string identificador, int idNoticia)
        {
            try
            {
                int id = getIdAutorByIdentificador(identificador);
                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Imagem
                MySqlCommand command = conexao.CreateCommand();
                if (idNoticia > 0)
                {
                    command.CommandText = $"delete from tb_noticia where id_noticia = @id_noticia";
                    command.Parameters.AddWithValue("@id_noticia", idNoticia);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    //Fechando a conexão
                    conexao.Close();
                    return 1;
                }
                else
                {
                    //Fechando a conexão
                    conexao.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
