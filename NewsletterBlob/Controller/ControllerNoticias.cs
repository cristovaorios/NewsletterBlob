using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    public class ControllerNoticias
    {
        private Noticia noticia;
        private NoticiaDAO noticiaDAO;
        //Cadastrar Notícia
        public void cadastrarNoticia(string registroProfissional, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao)
        {
            try
            {
                noticia = new Noticia(titulo, subtitulo, texto, imagem, categoria, autores, dataPublicacao);
                noticiaDAO = new NoticiaDAO();

                //Capturando Id de Autor pelo registro profissional
                int idAutor = new AutorDAO().getIdByRegistroProfissional(registroProfissional);
                int result = noticiaDAO.adicionarNoticia(idAutor, noticia);
                if(result == 0)
                    MessageBox.Show("Não foi possível cadastrar a notícia", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Notícia publicada com sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                noticiaDAO = new NoticiaDAO();
                noticia = noticiaDAO.listarNoticia(id);
                if (noticia.Equals(null))
                {
                    MessageBox.Show("Não foi possível carregar a notícia!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    return noticia;
                }
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
            List<Noticia> lista = new List<Noticia>();
            try
            {
                noticiaDAO = new NoticiaDAO();
                lista = noticiaDAO.listarNoticiaPorAutor(identificador);
                if (lista.Count == 0)
                {
                    MessageBox.Show("Você não possui notícias!", "Mensagem de Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                else
                {
                    return lista;
                }
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
                int result =  noticiaDAO.atualizarNoticia(noticia);
                if (result == 0)
                    MessageBox.Show("Não foi possível editar os dados!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Menssagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Excluir Usuário Leitor
        public void excluirNoticia(string identificador, int idNoticia)
        {
            try
            {
                noticiaDAO = new NoticiaDAO();
                int resp = noticiaDAO.deletarNoticia(identificador, idNoticia);
                if(resp == 0)
                    MessageBox.Show("Não foi possível excluir a publicação!", "Messagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
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
                noticiaDAO = new NoticiaDAO();
                List<Noticia> lista = new List<Noticia>();
                lista = noticiaDAO.listarPrincipaisNoticias();
                if (lista.Count == 0)
                    return null;
                else
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
                noticiaDAO = new NoticiaDAO();
                List<Noticia> lista = new List<Noticia>();
                lista = noticiaDAO.listarNoticiasBanner();
                if (lista.Count == 0)
                    return null;
                else
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
