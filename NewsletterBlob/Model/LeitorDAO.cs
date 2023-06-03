using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NewsletterBlob.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.Model
{
    public class LeitorDAO
    {
        private MySqlConnection con;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string sql;

        public LeitorDAO()
        {
            con = ConnectionFactory.Conexao();
        }

        public int adicionarLeitor(Leitor leitor)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"INSERT INTO tb_usuario_leitor(nome, email, cpf, endereco, telefone, senha, data_de_nascimento)" +
                    $"VALUES (@nome, @email, @cpf, @endereco, @telefone, @senha, @data_nascimento)";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@nome", leitor.Nome);
                command.Parameters.AddWithValue("@email", leitor.Email);
                command.Parameters.AddWithValue("@cpf", leitor.Cpf);
                command.Parameters.AddWithValue("@endereco", leitor.Endereco);
                command.Parameters.AddWithValue("@telefone", leitor.Telefone);
                command.Parameters.AddWithValue("@senha", leitor.Senha);
                command.Parameters.AddWithValue("@data_nascimento", leitor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public List<string> comparaUsuarioSenha(string email, string senha)
        {
            List<string> usuario = new List<string>();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"select email, senha from tb_usuario_leitor " +
                    $"where email = verifica_usuario_senha(@email, @senha);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Prepare();
                reader = command.ExecuteReader();
                
                //Retornando o resultado
                while(reader.Read())
                {
                    if (reader.IsDBNull(0))
                        return null;
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

        public int validaEmail(string email)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"select verifica_email(@email);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@email", email);
                command.Prepare();
                reader = command.ExecuteReader();
                //Retornando o resultado
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
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

        public int validaCpf(string cpf)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"select verifica_cpf(@cpf);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@cpf", cpf);
                command.Prepare();
                reader = command.ExecuteReader();
                //Retornando o resultado
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
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

        public int adicionarFotoPerfil(string email, byte[] imagem)
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
                        // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                        sql = "UPDATE tb_usuario_leitor SET imagem_de_perfil = @imagem WHERE email = @email";
                        command = new MySqlCommand(sql, con);
                        command.Parameters.AddWithValue("@imagem", imagem);
                        command.Parameters.AddWithValue("@email", email);
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

        public int deletarFotoPerfil(string email)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                sql = $"UPDATE tb_usuario_leitor SET imagem_de_perfil = @imagem WHERE email = @email";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@imagem", null);
                command.Parameters.AddWithValue("@email", email);
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

        public Leitor listarLeitor(string email)
        {
            Leitor leitor = new Leitor();
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Registro
                command = con.CreateCommand();
                sql = $"SELECT nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil " +
                    $"FROM tb_usuario_leitor WHERE email = @email;";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@email", email);
                command.Prepare();
                reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    if (reader["imagem_de_perfil"] != null && reader["imagem_de_perfil"].ToString().Length > 0)
                    {
                        leitor = new Leitor(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), (byte[])reader["imagem_de_perfil"]);
                    }
                    else
                    {
                        leitor = new Leitor(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), null);
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
            return leitor;
        }

        public int atualizarLeitor(Leitor leitor, string old_email)
        {
            int result = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                //Capturando o id do usuário
                int id = getIdByEmail(old_email);
                if (id != 0)
                {
                    sql = $"call editar_usuario(@id, @nome, @email," +
                    $" @cpf, @endereco, @telefone," +
                    $" @senha, @data_nascimento);";
                    command = new MySqlCommand(sql, con);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", leitor.Nome);
                    command.Parameters.AddWithValue("@email", leitor.Email);
                    command.Parameters.AddWithValue("@cpf", leitor.Cpf);
                    command.Parameters.AddWithValue("@endereco", leitor.Endereco);
                    command.Parameters.AddWithValue("@telefone", leitor.Telefone);
                    command.Parameters.AddWithValue("@senha", leitor.Senha);
                    command.Parameters.AddWithValue("@data_nascimento", leitor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public int getIdByEmail(string email)
        {
            int id = 0;
            try
            {
                //Abertura da Conexao
                con.Open();
                //Adicionando Imagem
                command = con.CreateCommand();
                //Capturando o id do usuário
                sql = $"SELECT id_leitor FROM tb_usuario_leitor WHERE id_leitor = capturar_id_usuario(@email);";
                command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@email", email);
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
