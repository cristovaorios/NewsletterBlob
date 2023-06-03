using MySqlConnector;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.Model
{
    public class NoticiaDAO
    {
        private MySqlConnection con;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string sql;

        public NoticiaDAO()
        {
            con = ConnectionFactory.Conexao();
        }

        //Adicionar Notícia
        public int adicionarNoticia(int idAutor, Noticia noticia)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                sql = $"INSERT INTO tb_noticia (id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao, qtd_comentarios, qtd_curtidas)" +
                    $"VALUES (@id_autor, @titulo, @subtitulo, @texto, @imagem, @categoria, @autores, @data_publicacao, 0, 0)";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@id_autor", idAutor);
                command.Parameters.AddWithValue("@titulo", noticia.Titulo);
                command.Parameters.AddWithValue("@subtitulo", noticia.Subtitulo);
                command.Parameters.AddWithValue("@texto", noticia.Texto);
                command.Parameters.AddWithValue("@imagem", noticia.Imagem);
                command.Parameters.AddWithValue("@categoria", noticia.Categoria);
                command.Parameters.AddWithValue("@autores", noticia.Autores);
                command.Parameters.AddWithValue("@data_publicacao", noticia.DataPublicacao.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Prepare();
                result = command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return result;
        }


        //Ler Notícia
        public Noticia listarNoticia(int id)
        {
            Noticia noticia = new Noticia();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"SELECT id_noticia, id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao, qtd_curtidas FROM tb_noticia WHERE id_noticia = @id;";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@id", id);
                command.Prepare();
                reader = command.ExecuteReader();

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
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            //Retornando o leitor
            return noticia;
        }

        //Listar noticias por Autor
        public List<Noticia> listarNoticiaPorAutor(string identificador)
        {
            List<Noticia> noticias = new List<Noticia>();
            try
            {
                int id = getIdAutorByIdentificador(identificador);

                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar as notícias do autor
                    sql = "SELECT id_noticia, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao FROM tb_noticia WHERE id_autor = @id;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Prepare();
                        using (reader = command.ExecuteReader())
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
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return noticias;
        }

        public int getIdAutorByIdentificador(string identificador)
        {
            int id = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"SELECT id_autor FROM tb_usuario_autor WHERE registro_profissional = @identificador;";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@identificador", identificador);
                command.Prepare();
                reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            //Retornando id do autor
            return id;
        }

        //Editar
        public int atualizarNoticia(Noticia noticia)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                if (noticia.Id > 0)
                {
                    sql = $"call editar_noticia(@id_noticia, @titulo, @subtitulo, @texto, @imagem, @categoria, @autores, @dataPublicacao);";
                    command = new MySqlCommand(sql, con);
                    command.Parameters.AddWithValue("@id_noticia", noticia.Id);
                    command.Parameters.AddWithValue("@titulo", noticia.Titulo);
                    command.Parameters.AddWithValue("@subtitulo", noticia.Subtitulo);
                    command.Parameters.AddWithValue("@texto", noticia.Texto);
                    command.Parameters.AddWithValue("@imagem", noticia.Imagem);
                    command.Parameters.AddWithValue("@categoria", noticia.Categoria);
                    command.Parameters.AddWithValue("@autores", noticia.Autores);
                    command.Parameters.AddWithValue("@dataPublicacao", noticia.DataPublicacao);
                    command.Prepare();
                    result = command.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return result;
        }

        //Deletar
        public int deletarNoticia(string identificador, int idNoticia)
        {
            int result = 0;
            try
            {
                int id = getIdAutorByIdentificador(identificador);
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                if (idNoticia > 0)
                {
                    command.CommandText = $"delete from tb_noticia where id_noticia = @id_noticia";
                    command.Parameters.AddWithValue("@id_noticia", idNoticia);
                    command.Prepare();
                    result = command.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return result;
        }

        //Pegar Notícias por Raking de Melhor para Pior
        public List<Noticia> listarPrincipaisNoticias()
        {
            List<Noticia> noticias = new List<Noticia>();
            try
            {
                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar as notícias do autor
                    sql = "SELECT id_noticia, id_autor, titulo, subtitulo, texto, imagem, categoria, autores, data_publicacao, qtd_curtidas " +
                        "FROM tb_noticia ORDER BY qtd_curtidas DESC, qtd_comentarios DESC LIMIT 3;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        using (reader = command.ExecuteReader())
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
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            // Retorna as notícias encontradas
            return noticias;
        }


        //Listar Noticias do Banner
        public List<Noticia> listarNoticiasBanner()
        {
            List<Noticia> noticias = new List<Noticia>();
            try
            {
                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar as notícias do autor
                    sql = "SELECT * FROM tb_noticia ORDER BY RAND() LIMIT 5;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        command.Prepare();
                        using (reader = command.ExecuteReader())
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
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            // Retorna as notícias encontradas
            return noticias;
        }
       
    }
}
