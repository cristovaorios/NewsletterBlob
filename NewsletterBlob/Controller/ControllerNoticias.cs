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
        public void cadastrarNoticia(string registroProfissional, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao)
        {
            try
            {
                Noticia noticia = new Noticia(titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao);
                NoticiaDAO noticiaDAO = new NoticiaDAO();

                //Capturando Id de Autor pelo registro profissional
                int idAutor = new AutorDAO().getIdByRegistroProfissional(registroProfissional);
                noticiaDAO.adicionarNoticia(idAutor, noticia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ler Notícias
        public Noticia exibirNoticia(int id)
        {
            try
            {
                Noticia noticia = new NoticiaDAO().listarNoticia(id);
                return noticia;
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
