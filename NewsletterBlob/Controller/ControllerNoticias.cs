using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    internal class ControllerNoticias
    {
        //Cadastrar Notícia
        public void cadastrarNoticia()
        {
            try
            {
                Noticia noticia = new Noticia();
                NoticiaDAO noticiaDAO = new NoticiaDAO();
                
                MessageBox.Show("Notícia Cadastrada com Sucesso!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ler Notícias
        public Leitor exibirNoticias(string email)
        {
            try
            {
                Leitor leitor = new LeitorDAO().listarLeitor(email);
                return leitor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Editar Notícia
        public void editarNoticia(string old_email, string nome, string email, DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            try
            {
                Leitor leitor = new Leitor(nome, email, dataDeNascimento, cpf, endereco, telefone, senha);
                new LeitorDAO().atualizarLeitor(leitor, old_email);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível editar os dados!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Excluir Usuário Leitor


    }
}
