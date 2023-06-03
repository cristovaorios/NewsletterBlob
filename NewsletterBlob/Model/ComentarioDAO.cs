using MySqlConnector;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.Model
{
    public class ComentarioDAO
    {
        private MySqlConnection con;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string sql;

        public ComentarioDAO()
        {
            con = ConnectionFactory.Conexao();
        }

        //Adicionar Notícia
        public int adicionarComentario(Comentario comentario)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                sql = $"INSERT INTO tb_comentario (id_leitor, id_noticia, imagem, texto)" +
                    $"VALUES (@id_leitor, @id_noticia, @imagem, @texto)";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@id_leitor", comentario.IdAutor);
                command.Parameters.AddWithValue("@id_noticia", comentario.IdNoticia);
                command.Parameters.AddWithValue("@imagem", comentario.ImagemAutor);
                command.Parameters.AddWithValue("@texto", comentario.Texto);
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

        //Listar comentários de notícia
        public List<Comentario> listarComentarioPorNoticia(int idNoticia)
        {
            List<Comentario> comentarios = new List<Comentario>();
            try
            {
                // Criação do Objeto de Conexão
                using (con)
                {
                    // Abertura da Conexão
                    con.Open();
                    // Comando SQL para buscar os comentários da notícia
                    sql = "SELECT id_comentario, id_leitor, imagem, texto FROM tb_comentario WHERE id_noticia = @id;";
                    using (command = new MySqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("@id", idNoticia);
                        command.Prepare();
                        using (reader = command.ExecuteReader())
                        {
                            // Itera sobre os resultados da consulta e cria objetos Comentario
                            while (reader.Read())
                            {
                                Comentario comentario = new Comentario();
                                if (reader["imagem"] != null && reader["imagem"].ToString().Length > 0)
                                {
                                    comentario.IdComentario = reader.GetInt32(0);
                                    comentario.IdAutor = reader.GetInt32(1);
                                    comentario.ImagemAutor = (byte[])reader["imagem"];
                                    comentario.Texto = reader.GetString(3);
                                }
                                else
                                {
                                    comentario.IdComentario = reader.GetInt32(0);
                                    comentario.IdAutor = reader.GetInt32(1);
                                    comentario.ImagemAutor = null;
                                    comentario.Texto = reader.GetString(3);
                                }
                                comentarios.Add(comentario);
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
            // Retorna os comentários encontrados
            return comentarios;
        }


        //Deletar
        public int deletarComentario(int idComentario)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                if (idComentario > 0)
                {
                    sql = $"DELETE FROM tb_comentario WHERE id_comentario = @id_comentario";
                    command = new MySqlCommand(sql, con);
                    command.Parameters.AddWithValue("@id_comentario", idComentario);
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

        public Leitor getLeitorComentario(string identificador)
        {
            Leitor leitor = new Leitor();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"SELECT id_leitor, nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil " +
                    $"FROM tb_usuario_leitor WHERE email = @identificador;";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@identificador", identificador);
                command.Prepare();
                reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    if (reader["imagem_de_perfil"] != null && reader["imagem_de_perfil"].ToString().Length > 0)
                    {
                        leitor.Id = reader.GetInt32(0);
                        leitor.ImagemPerfil = (byte[])reader["imagem_de_perfil"];
                    }
                    else
                    {
                        leitor.Id = reader.GetInt32(0);
                        leitor.ImagemPerfil = null;
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
            //Retornando o leitor
            return leitor;
        }

    }
}
