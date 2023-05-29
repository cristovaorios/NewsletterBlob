using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                int id=0;

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

        //Editar
        public void atualizarNoticia(Noticia noticia)
        {
            try
            {
                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Imagem
                MySqlCommand command = conexao.CreateCommand();
                if (noticia.Id > 0)
                {
                    command.CommandText = $"call editar_noticia(@id_noticia, @titulo, @subtitulo, @texto, @imagem, @categoria, @autores, @dataPublicacao);";
                    command.Parameters.AddWithValue("@id_noticia", noticia.Id);
                    command.Parameters.AddWithValue("@titulo", noticia.Titulo);
                    command.Parameters.AddWithValue("@subtitulo", noticia.SubTitulo);
                    command.Parameters.AddWithValue("@texto", noticia.Texto);
                    command.Parameters.AddWithValue("@imagem", noticia.Imagem);
                    command.Parameters.AddWithValue("@categoria", noticia.Categoria);
                    command.Parameters.AddWithValue("@autores", noticia.Autores);
                    command.Parameters.AddWithValue("@dataPublicacao", noticia.DataPublicacao);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Dados Editados com Sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possível editar os dados!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Pegar Notícias por Raking de Melhor para Pior
        public List<Noticia> listarPrincipaisNoticias()
        {
            try
            {
                List<Noticia> noticias = new List<Noticia>();

                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT id_noticia, id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao, qtd_curtidas " +
                        "FROM tb_noticia ORDER BY qtd_curtidas DESC, qtd_comentarios DESC LIMIT 3;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
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
                                Noticia noticia = new Noticia(idNoticia, idAutor, titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao, qtdCurtidas);
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


        //Listar Noticias do Banner
        public List<Noticia> listarNoticiasBanner()
        {
            try
            {
                List<Noticia> noticias = new List<Noticia>();

                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT * FROM tb_noticias ORDER BY RAND() LIMIT 5;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
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
                                Noticia noticia = new Noticia(idNoticia, idAutor, titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao, qtdCurtidas);
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

    }
}
