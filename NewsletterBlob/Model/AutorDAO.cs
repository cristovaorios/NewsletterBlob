using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    internal class AutorDAO
    {
        public List<string> comparaUsuarioSenha(string registroProfissional, string senha)
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
                command.CommandText = $"select registro_profissional, senha from tb_usuario_autor " +
                    $"where registro_profissional = verifica_usuario_senha_autor('{registroProfissional}', '{senha}');";
                MySqlDataReader reader = command.ExecuteReader();

                //Retornando o resultado
                while (reader.Read())
                {
                    usuario.Add(reader.GetString(0));   //Email
                    usuario.Add(reader.GetString(1));   //Senha
                }

                //Fechando a conexão
                conexao.Close();
                if (usuario.Contains(""))
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

        public void adicionarFotoPerfil(string registroProfissional, byte[] imagem)
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
                        command.CommandText = "UPDATE tb_usuario_autor SET imagem_de_perfil = @imagem WHERE registro_profissional = @registro_profissional";
                        command.Parameters.AddWithValue("@imagem", imagem);
                        command.Parameters.AddWithValue("@registro_profissional", registroProfissional);
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

        public void deletarFotoPerfil(string registroProfissional)
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
                command.CommandText = $"UPDATE tb_usuario_autor SET imagem_de_perfil = '{null}' WHERE registro_profissional = '{registroProfissional}'";
                command.ExecuteNonQuery();

                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Autor listarAutor(string registroProfissional)
        {
            try
            {
                Autor autor = new Autor();

                //String de Conexão
                string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";
                //Criação do Objeto de Conexão
                MySqlConnection conexao = new MySqlConnection(strconexao);
                //Abertura da Conexao
                conexao.Open();
                //Adicionando Registro
                MySqlCommand command = conexao.CreateCommand();
                command.CommandText = $"SELECT nome, email, cpf, endereco, telefone, senha, data_de_nascimento, imagem_de_perfil FROM tb_usuario_autor WHERE registro_profissional = '{registroProfissional}';";
                MySqlDataReader reader = command.ExecuteReader();

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
                //Retornando o leitor
                return autor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void atualizarLeitor(Autor autor, string old_registro_profissional)
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
                int id = getIdByRegistroProfissional(old_registro_profissional);
                MessageBox.Show("Id: " + id);
                if (id != 0)
                {
                    command.CommandText = $"call editar_usuario({id}, '{autor.Nome}', '{autor.Email}'," +
                    $" '{autor.Cpf}', '{autor.Endereco}', '{autor.Telefone}'," +
                    $" '{autor.Senha}', '{autor.DataDeNascimento.ToString("yyyy-MM-dd HH:mm:ss")}');";
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

        public int getIdByRegistroProfissional(string registroProfissional)
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
                command.CommandText = $"SELECT id_autor FROM tb_usuario_autor WHERE id_autor = capturar_id_usuario_autor('{registroProfissional}');";
                MySqlDataReader reader = command.ExecuteReader();
                //Atribuindo o id encontrado
                int id = 0;
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
