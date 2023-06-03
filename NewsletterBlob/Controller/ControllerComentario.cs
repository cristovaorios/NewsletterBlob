using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    public class ControllerComentario
    {
        private Comentario comentario;
        private ComentarioDAO comentarioDAO;

        //Cadastrar Notícia
        public void cadastrarComentario(int idNoticia, string identificador, string texto)
        {
            try
            {
                Leitor leitor = getLeitor(identificador);
                comentario = new Comentario(idNoticia, leitor.Id, leitor.ImagemPerfil, texto);
                comentarioDAO = new ComentarioDAO();
                int result = comentarioDAO.adicionarComentario(comentario);
                if(result == 0)
                {
                    MessageBox.Show("Não foi possível adicionar o comentário!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Notícias Autor
        public List<Comentario> listarComentariosNoticia(int idNoticia)
        {
            List<Comentario> lista = new List<Comentario>();
            try
            {
                comentarioDAO = new ComentarioDAO();
                lista = comentarioDAO.listarComentarioPorNoticia(idNoticia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        //Excluir Usuário Leitor
        public void excluirComentario(int idComentario)
        {
            try
            {
                comentarioDAO = new ComentarioDAO();
                int resp = comentarioDAO.deletarComentario(idComentario);
                if (resp == 0)
                    MessageBox.Show("Não foi possível excluir o comentário!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int getIdLeitor(string identificador)
        {
            Leitor leitor = getLeitor(identificador);
            return leitor.Id;
        }

        private Leitor getLeitor(string identificador)
        {
            comentarioDAO = new ComentarioDAO();
            Leitor leitor = comentarioDAO.getLeitorComentario(identificador);
            return leitor;
        }
    }
}
