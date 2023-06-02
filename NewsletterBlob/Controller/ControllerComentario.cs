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
    internal class ControllerComentario
    {


        //Cadastrar Notícia
        public void cadastrarComentario(int idNoticia, string identificador, string texto)
        {
            try
            {
                Leitor leitor = getLeitor(identificador);
                Comentario comentario = new Comentario(idNoticia, leitor.Id, leitor.ImagemPerfil, texto);

                new ComentarioDAO().adicionarComentario(comentario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Notícias Autor
        public List<Comentario> listarComentariosNoticia(int idNoticia)
        {
            try
            {
                List<Comentario> lista = new ComentarioDAO().listarComentarioPorNoticia(idNoticia);
                if (lista != null && lista.Count > 0)
                {
                    return lista;
                }
                else
                {
                    return new List<Comentario>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Comentario>();
            }
        }

        //Excluir Usuário Leitor
        public void excluirComentario(int idComentario)
        {
            try
            {
                int resp = new ComentarioDAO().deletarComentario(idComentario);
                if (resp == 0)
                {
                    MessageBox.Show("Não foi possível excluir o comentário!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            Leitor leitor = new ComentarioDAO().getLeitorComentario(identificador);
            return leitor;
        }
    }
}
