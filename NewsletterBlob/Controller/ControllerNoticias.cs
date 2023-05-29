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

        //Notícias Autor
        public List<Noticia> listarNoticiasAutor(string identificador)
        {
            try
            {
                List<Noticia> lista = new NoticiaDAO().listarNoticiaPorAutor(identificador);
                return lista;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        //Editar Notícia
        public void editarNoticia(int id_noticia, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao)
        {
            try
            {
                Noticia noticia = new Noticia(id_noticia, titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao);
                new NoticiaDAO().atualizarNoticia(noticia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível editar os dados!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Excluir Usuário Leitor
        public void excluirNoticia(string identificador, int idNoticia)
        {
            try
            {
                int resp = new NoticiaDAO().deletarNoticia(identificador, idNoticia);
                MessageBox.Show("Publicação excluída com sucesso!", "Messagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Listar Todas as Notícias
        public List<Noticia> exibirPrincipaisNoticias()
        {
            try
            {
                List<Noticia> lista = new NoticiaDAO().listarPrincipaisNoticias();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        //Listar Notícias do Banner
        public List<Noticia> exibirNoticiasBanner()
        {
            try
            {
                List<Noticia> lista = new NoticiaDAO().listarNoticiasBanner();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

    }
}
