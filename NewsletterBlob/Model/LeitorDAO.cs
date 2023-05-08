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

namespace NewsletterBlob.Model
{
    internal class LeitorDAO
    {
        public void adicionarLeitor(Leitor leitor)
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
                command.CommandText = $"INSERT INTO tb_usuario_leitor(nome, email, cpf, endereco, telefone, senha, data_de_nascimento)" +
                    $"VALUES ('{leitor.Nome}', '{leitor.Email}', '{leitor.Cpf}', '{leitor.Endereco}', '{leitor.Telefone}', '{leitor.Senha}', '{leitor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss")}')";
                command.ExecuteNonQuery();

                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> comparaUsuarioSenha(string email, string senha)
        {
            try
            {
                List<string> usuario = new List<string>();

                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"select email, senha from tb_usuario_leitor " +
                    $"where email = verifica_usuario_senha('{email}', '{senha}');";
                MySqlDataReader reader = command.ExecuteReader();
                
                //Retornando o resultado
                while(reader.Read())
                {
                    usuario.Add(reader.GetString(0));   //Email
                    usuario.Add(reader.GetString(1));   //Senha
                }

                //Fechando a conexão
                conexao.Close();
                if(usuario.Contains(""))
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int validaEmail(string email)
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
                command.CommandText = $"select verifica_email('{email}');";
                MySqlDataReader reader = command.ExecuteReader();
                int result = 0;
                //Retornando o resultado
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                conexao.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int validaCpf(string cpf)
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
                command.CommandText = $"select verifica_cpf('{cpf}');";
                MySqlDataReader reader = command.ExecuteReader();
                int result = 0;
                //Retornando o resultado
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                conexao.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public void adicionarFotoPerfil(string email, byte[] imagem)
        {
            try
            {
                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                using (MySqlConnection conexao = new MySqlConnection(strconexao))
                {
                    //Abertura da Conexao
                    conexao.Open();
                    //Adicionando Imagem
                    using (MySqlCommand command = conexao.CreateCommand())
                    {
                        // utiliza parâmetros para evitar problemas com caracteres especiais e ataques de injeção de SQL
                        command.CommandText = "UPDATE tb_usuario_leitor SET imagem_de_perfil = @imagem WHERE email = @email";
                        command.Parameters.AddWithValue("@imagem", imagem);
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                    }
                    //Fechando a conexão
                    conexao.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deletarFotoPerfil(string email)
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
                command.CommandText = $"UPDATE tb_usuario_leitor SET imagem_de_perfil = '{null}' WHERE email = '{email}'";
                command.ExecuteNonQuery();

                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Leitor listarLeitor(string email)
        {
            try
            {
                Leitor leitor = new Leitor();

                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"SELECT nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil FROM tb_usuario_leitor WHERE email = '{email}';";
                MySqlDataReader reader = command.ExecuteReader();

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
                //Retornando o leitor
                return leitor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void atualizarLeitor(Leitor leitor, string old_email)
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
                //Capturando o id do usuário
                int id = getIdByEmail(old_email);
                MessageBox.Show("Id: "+id);
                if(id != 0)
                {
                    command.CommandText = $"call editar_usuario({id}, '{leitor.Nome}', '{leitor.Email}'," +
                    $" '{leitor.Cpf}', '{leitor.Endereco}', '{leitor.Telefone}'," +
                    $" '{leitor.Senha}', '{leitor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss")}');";
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

        public int getIdByEmail(string email)
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
                //Capturando o id do usuário
                command.CommandText = $"SELECT id_leitor FROM tb_usuario_leitor WHERE id_leitor = capturar_id_usuario('{email}');";
                MySqlDataReader reader = command.ExecuteReader();
                //Atribuindo o id encontrado
                int id=0;
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                //Retornando o resultado
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

    }
}
