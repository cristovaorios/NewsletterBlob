using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    public class ControllerCurtida
    {
        private Curtida curtida;
        private CurtidaDAO curtidaDAO;

        //Cadastrar Curtida
        public void cadastrarCurtida(int idNoticia, string identificador, bool estaCurtido)
        {
            try
            {
                int id = getId(identificador);

                if (id == 0)
                    MessageBox.Show("Usuário não encontrado!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int resp = new CurtidaDAO().adicionarCurtida(idNoticia, id, estaCurtido);
                    if (resp == 0)
                        MessageBox.Show("Não foi possível curtir a publicação!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Verificar se já curtiu a notícia
        public bool verificarNoticiaCurtida(int idNoticia, string identificador)
        {
            bool estaCurtido = false;
            try
            {
                int id = getId(identificador);
                if (id != 0)
                    estaCurtido = new CurtidaDAO().verificarCurtidaAutorNoticia(idNoticia, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return estaCurtido;
        }

        //Descurtir Notícia
        public int descurtirNoticia(int idNoticia, string identificador)
        {
            int result = 0;
            try
            {
                int id = getId(identificador);
                if (id != 0)
                {
                    curtidaDAO = new CurtidaDAO();
                    result = curtidaDAO.excluirCurtida(idNoticia, id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private int getId(string identificador)
        {
            curtidaDAO = new CurtidaDAO();
            int id = curtidaDAO.getIdLeitorCurtida(identificador);
            return id;
        }
    }
}
