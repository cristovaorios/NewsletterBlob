using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    internal class NoticiaDAO
    {
        public void adicionarNoticia(Noticia noticia)
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
                command.CommandText = $"";
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
