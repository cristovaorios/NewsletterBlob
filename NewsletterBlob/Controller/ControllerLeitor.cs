using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    internal class ControllerLeitor
    {
        //Cadastrar Usuário Leitor
        public void cadastrarLeitor(string nome, string email,DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            try
            {
                Leitor leitor = new Leitor(nome, email, dataDeNascimento, cpf, endereco, telefone, senha);
                LeitorDAO leitorDAO = new LeitorDAO();
                leitorDAO.adicionarLeitor(leitor);
                MessageBox.Show("Usuário Cadastrado com Sucesso!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ler Usuário Leitor


        //Editar Usuário Leitor


        //Alterar Foto Usuário Leitor


        //Excluir Foto Usuário Leitor


        //Excluir Usuário Leitor


    }
}
