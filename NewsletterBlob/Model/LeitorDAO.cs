using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
