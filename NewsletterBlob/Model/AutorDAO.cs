using MySqlConnector;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    public class AutorDAO
    {
        private MySqlConnection con;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string sql;

        public AutorDAO()
        {
            con = ConnectionFactory.Conexao();
        }

        public List<string> comparaUsuarioSenha(string registroProfissional, string senha)
        {
            List<string> usuario = new List<string>();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"select registro_profissional, senha from tb_usuario_autor " +
                    $"where registro_profissional = verifica_usuario_senha_autor(@registro_profissional, @senha);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
                command.Parameters.AddWithValue("@senha", senha);
                command.Prepare();
                reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    usuario.Add(reader.GetString(0));   //Email
                    usuario.Add(reader.GetString(1));   //Senha
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
            return usuario;
        }

        public int adicionarFotoPerfil(string registroProfissional, byte[] imagem)
        {
            int result = 0;
            try
            {
                //Criação do Objeto de Conexão
                using (con)
                {
                    //Abertura da Conexao
                    con.Open();
                    //Adicionando Imagem
                    using (command = con.CreateCommand())
                    {
                        // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de SQL Injection
                        sql = "UPDATE tb_usuario_autor SET imagem_de_perfil = @imagem WHERE registro_profissional = @registro_profissional";
                        command = new MySqlCommand(sql, con);
                        command.Parameters.AddWithValue("@imagem", imagem);
                        command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
                        command.Prepare();
                        result = command.ExecuteNonQuery();
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
            return result;
        }

        public int deletarFotoPerfil(string registroProfissional)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                sql = $"UPDATE tb_usuario_autor SET imagem_de_perfil = @imagem_de_perfil WHERE registro_profissional = @registro_profissional";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@imagem_de_perfil", null);
                command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
                command.Prepare();
                result = command.ExecuteNonQuery();
            }
            catch (MySqlException e) { throw; }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return result;
        }

        public Autor listarAutor(string registroProfissional)
        {
            Autor autor = new Autor();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"SELECT nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil " +
                    $"FROM tb_usuario_autor WHERE registro_profissional = @registro_profissional;";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
                command.Prepare();
                reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    if (reader["imagem_de_perfil"] != null && reader["imagem_de_perfil"].ToString().Length > 0)
                    {
                        autor = new Autor(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), (byte[])reader["imagem_de_perfil"]);
                    }
                    else
                    {
                        autor = new Autor(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), null);
                    }
                }
            }
            catch (MySqlException e) { throw; }
            finally
            {
                //Fechando a Conexão
                con.Close();
            }
            return autor;
        }

        public int atualizarLeitor(Autor autor, string old_registro_profissional)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                //Capturando o id do usuário
                int id = getIdByRegistroProfissional(old_registro_profissional);
                if (id != 0)
                {
                    sql = $"call editar_usuario( @id, @nome, @email," +
                    $" @cpf, @endereco, @telefone," +
                    $" @senha, @data_nascimento);";
                    command = new MySqlCommand(sql, con);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", autor.Nome);
                    command.Parameters.AddWithValue("@email", autor.Email);
                    command.Parameters.AddWithValue("@cpf", autor.Cpf);
                    command.Parameters.AddWithValue("@endereco", autor.Endereco);
                    command.Parameters.AddWithValue("@telefone", autor.Telefone);
                    command.Parameters.AddWithValue("@senha", autor.Senha);
                    command.Parameters.AddWithValue("@data_nascimento", autor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Prepare();
                    result = command.ExecuteNonQuery();
                }
                else
                {
                    result = 0;
                }
            }
            catch (MySqlException e) { throw; }
            finally
            {
                //Fechando a conexão
                con.Close();
            }
            return result;
        }

        public int getIdByRegistroProfissional(string registroProfissional)
        {
            int id = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                //Capturando o id do usuário
                sql = $"SELECT id_autor FROM tb_usuario_autor WHERE id_autor = capturar_id_usuario_autor(@registro_profissional);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                //Atribuindo o id encontrado
                
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
            //Retornando o resultado
            return id;
        }

    }
}
