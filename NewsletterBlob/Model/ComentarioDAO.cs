using MySqlConnector;
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
    internal class ComentarioDAO
    {
        private const string conect = "server=localhost;userid=root;password=;database=db_blobnews";

        //Adicionar Notícia
        public void adicionarComentario(Comentario comentario)
        {

            try
            {
                //String de Conexão
                string strconexao = conect;
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                command.CommandText = $"INSERT INTO tb_comentario (id_leitor, id_noticia, imagem, texto)" +
                    $"VALUES (@id_leitor, @id_noticia, @imagem, @texto)";
                command.Parameters.AddWithValue("@id_leitor", comentario.IdAutor);
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

        //Listar comentários de notícia
        public List<Comentario> listarComentarioPorNoticia(int idNoticia)
        {
            try
            {
                List<Comentario> comentarios = new List<Comentario>();

                // String de Conexão
                string strconexao = conect;
                // Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    // Abertura da Conexão
                    conexao.Open();
                    // Comando SQL para buscar os comentários da notícia
                    string query = "SELECT id_comentario, id_leitor, imagem, texto FROM tb_comentario WHERE id_noticia = @id;";
                    using (MySqlCommand command = new MySqlCommand(query, conexao))
                    {
                        command.Parameters.AddWithValue("@id", idNoticia);
                        command.Prepare();
                        using (MySqlDataReader reader = command.ExecuteReader())
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
                // Retorna os comentários encontrados
                return comentarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //Deletar
        public int deletarComentario(int idComentario)
        {
            try
            {
                //String de Conexão
                string strconexao = conect;
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Imagem
                MySqlCommand command = conexao.CreateCommand();
                if (idComentario > 0)
                {
                    command.CommandText = $"DELETE FROM tb_comentario WHERE id_comentario = @id_comentario";
                    command.Parameters.AddWithValue("@id_comentario", idComentario);
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
                MessageBox.Show(ex.Message, "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public Leitor getLeitorComentario(string identificador)
        {
            try
            {
                Leitor leitor = new Leitor();

                //String de Conexão
                string strconexao = conect;
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"SELECT id_leitor, nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil " +
                    $"FROM tb_usuario_leitor WHERE email = @identificador;";
                command.Parameters.AddWithValue("identificador", identificador);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();

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
                //Retornando o leitor
                return leitor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
