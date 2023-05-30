using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    internal class CurtidaDAO
    {
        //Adicionar Notícia
        public int adicionarCurtida(int idNoticia, int idAutor, bool estaCurtido)
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
                command.CommandText = $"INSERT INTO tb_curtida (id_noticia, id_leitor, esta_curtido)" +
                    $"VALUES (@id_noticia, @id_autor, @esta_curtido)";
                command.Parameters.AddWithValue("@id_noticia", idNoticia);
                command.Parameters.AddWithValue("@id_autor", idAutor);
                command.Parameters.AddWithValue("@esta_curtido", estaCurtido);
                command.Prepare();
                command.ExecuteNonQuery();
                //Fechando a conexão
                conexao.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Verificar curtida de autor em notícia
        public bool verificarCurtidaAutorNoticia(int idNoticia, int idAutor)
        {
            try
            {
                bool estaCurtido = false;
                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT esta_curtido FROM tb_curtida WHERE id_noticia = @id_noticia AND id_leitor = @id_autor;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id_noticia", idNoticia);
                        command.Parameters.AddWithValue("@id_autor", idAutor);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(0))
                                    estaCurtido = false;
                                else
                                    estaCurtido = true;
                            }
                        }
                    }
                }
                // Retorna as notícias encontradas
                return estaCurtido;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Verificar se está curtido ou descurtido
        public bool verificarCurtidaDescurtida(int idNoticia, int idAutor)
        {
            try
            {
                bool estaCurtido = false;
                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT esta_curtido FROM tb_curtida WHERE id_noticia = @id_noticia AND id_leitor = @id_autor;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id_noticia", idNoticia);
                        command.Parameters.AddWithValue("@id_autor", idAutor);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(0))
                                    estaCurtido = false;
                                else
                                    estaCurtido = reader.GetBoolean(0);
                            }
                        }
                    }
                }
                // Retorna as notícias encontradas
                return estaCurtido;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Deletar
        public int descurtir(int idNoticia, int idAutor, bool estaCurtido)
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
                if (idNoticia > 0)
                {
                    command.CommandText = $"UPDATE tb_curtida SET esta_curtido = @esta_curtido WHERE id_noticia = @id_noticia AND id_leitor = @id_autor;";
                    command.Parameters.AddWithValue("@id_noticia", idNoticia);
                    command.Parameters.AddWithValue("@id_autor", idAutor);
                    command.Parameters.AddWithValue("@esta_curtido", estaCurtido);
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

        public int getIdAutorCurtida(string idAutor)
        {
            try
            {
                int id = 0;
                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT id_autor FROM tb_usuario_autor WHERE registro_profissional = @id_autor;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id_autor", idAutor);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
                            while (reader.Read())
                            {
                                id = reader.GetInt32(0);
                            }
                        }
                    }
                }
                // Retorna as notícias encontradas
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int getIdLeitorCurtida(string idLeitor)
        {
            try
            {
                int id = 0;
                // String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar as notícias do autor
                    string query = "SELECT id_leitor FROM tb_usuario_leitor WHERE email = @id_leitor;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id_leitor", idLeitor);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Noticia
                            while (reader.Read())
                            {
                                id = reader.GetInt32(0);
                            }
                        }
                    }
                }
                // Retorna as notícias encontradas
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }
}
