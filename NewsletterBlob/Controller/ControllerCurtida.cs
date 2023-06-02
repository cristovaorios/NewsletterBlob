using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    internal class ControllerCurtida
    {
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
                    {
                        MessageBox.Show("Não foi possível curtir a publicação!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Curtido com sucesso!");
                    }
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
            try
            {
                int id = getId(identificador);

                if (id == 0)
                {
                    MessageBox.Show("Usuário não encontrado!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    bool estaCurtido = new CurtidaDAO().verificarCurtidaAutorNoticia(idNoticia, id);
                    return estaCurtido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Descurtir Notícia
        public int descurtirNoticia(int idNoticia, string identificador)
        {
            try
            {
                int id = getId(identificador);

                if (id == 0)
                {
                    MessageBox.Show("Usuário não encontrado!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else
                {
                    int resp = new CurtidaDAO().excluirCurtida(idNoticia, id);
                    return resp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int getId(string identificador)
        {
            int id = new CurtidaDAO().getIdLeitorCurtida(identificador);
            return id;
        }
    }
}
