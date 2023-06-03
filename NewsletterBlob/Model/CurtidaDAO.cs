using MySqlConnector;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    public class CurtidaDAO
    {
        private MySqlConnection con;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string sql;

        public CurtidaDAO()
        {
            con = ConnectionFactory.Conexao();
        }

        //Adicionar Notícia
        public int adicionarCurtida(int idNoticia, int idLeitor, bool estaCurtido)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                sql = $"INSERT INTO tb_curtida (id_noticia, id_leitor, esta_curtido)" +
                    $"VALUES (@id_noticia, @id_autor, @esta_curtido)";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@id_noticia", idNoticia);
                command.Parameters.AddWithValue("@id_autor", idLeitor);
                command.Parameters.AddWithValue("@esta_curtido", estaCurtido);
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

        //Verificar curtida de autor em notícia
        public bool verificarCurtidaAutorNoticia(int idNoticia, int idLeitor)
        {
            bool estaCurtido = false;
            try
            {
                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar as notícias do autor
                    sql = "SELECT esta_curtido FROM tb_curtida WHERE id_noticia = @id_noticia AND id_leitor = @id_autor;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("@id_noticia", idNoticia);
                        command.Parameters.AddWithValue("@id_autor", idLeitor);
                        command.Prepare();
                        using (reader = command.ExecuteReader())
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
            return estaCurtido;
        }


        //Deletar
        public int excluirCurtida(int idNoticia, int idLeitor)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                if (idNoticia > 0)
                {
                    command.CommandText = $"DELETE FROM tb_curtida WHERE id_noticia = @id_noticia AND id_leitor = @id_autor;";
                    command.Parameters.AddWithValue("@id_noticia", idNoticia);
                    command.Parameters.AddWithValue("@id_autor", idLeitor);
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

        public int getIdLeitorCurtida(string idLeitor)
        {
            try
            {
                int id = 0;
                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar as notícias do autor
                    sql = "SELECT id_leitor FROM tb_usuario_leitor WHERE email = @id_leitor;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("@id_leitor", idLeitor);
                        command.Prepare();
                        using (reader = command.ExecuteReader())
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
            catch (MySqlException e)
            {
                throw;
            }
        }
    }
}
