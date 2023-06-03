using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    public class ControllerAutor
    {
        private Autor autor;
        private AutorDAO autorDAO;
        //Verificar Usuário e Senha
        public string verificaUsuarioSenha(string registroProfissional, string senha)
        {
            try
            {
                autorDAO = new AutorDAO();
                List<string> usuario = autorDAO.comparaUsuarioSenha(registroProfissional, senha);

                if (usuario.Any() && !(usuario.Equals(null)))
                {
                    string user = usuario.Find(x => x == registroProfissional);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Ler Usuário Autor
        public Autor exibirAutor(string registroProfissional)
        {
            try
            {
                autorDAO = new AutorDAO();
                autor = autorDAO.listarAutor(registroProfissional);
                return autor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Alterar Foto Usuário Autor
        public void alterarFotoPerfil(string registroProfissional, byte[] imagem)
        {
            try
            {
                autorDAO = new AutorDAO();
                if (imagem != null)
                {
                    int resp = autorDAO.adicionarFotoPerfil(registroProfissional, imagem);
                    if(resp == 0)
                        MessageBox.Show("Não foi possível alterar a foto de perfil!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Excluir Foto Usuário Leitor
        public void removerFotoPerfil(string registroProfissional)
        {
            try
            {
                autorDAO = new AutorDAO();
                int resp = autorDAO.deletarFotoPerfil(registroProfissional);
                if(resp == 0)
                    MessageBox.Show("Não foi possível remover a foto de perfil!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
