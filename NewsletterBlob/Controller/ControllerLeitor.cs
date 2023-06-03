using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.Controller
{
    public class ControllerLeitor
    {
        private Leitor leitor;
        private LeitorDAO leitorDAO;

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

        //Verificar Usuário e Senha
        public string verificaUsuarioSenha(string email, string senha)
        {
            try
            {
                List<string> usuario = new LeitorDAO().comparaUsuarioSenha(email, senha);

                if (usuario.Any() && !(usuario.Equals(null)))
                {
                    string user = usuario.Find(x => x == email);
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

        //Verificar Email
        public bool verificaEmail(string email)
        {
            try
            {
                int result = new LeitorDAO().validaEmail(email);
                
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Verificar Cpf
        public bool verificaCpf(string cpf)
        {
            try
            {
                int result = new LeitorDAO().validaCpf(cpf);

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Ler Usuário Leitor
        public Leitor exibirLeitor(string email)
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


        //Editar Usuário Leitor
        public void editarLeitor(string old_email, string nome, string email, DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            try
            {
                leitorDAO = new LeitorDAO();
                Leitor leitor = new Leitor(nome, email, dataDeNascimento, cpf, endereco, telefone, senha);
                int resp = leitorDAO.atualizarLeitor(leitor, old_email);
                if(resp == 0)
                    MessageBox.Show("Não foi possível editar os dados!", "Mensagem de ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Alterar Foto Usuário Leitor
        public void alterarFotoPerfil(string email, byte[] imagem)
        {
            try
            {
                if (imagem != null)
                {
                    leitorDAO = new LeitorDAO();
                    int result = leitorDAO.adicionarFotoPerfil(email, imagem);
                    if(result == 0)
                        MessageBox.Show("Não foi possível alterar sua foto de perfil!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Excluir Foto Usuário Leitor
        public void removerFotoPerfil(string email)
        {
            try
            {
                leitorDAO = new LeitorDAO();
                int result = leitorDAO.deletarFotoPerfil(email);
                if (result == 0)
                {
                    MessageBox.Show("Não foi possível excluir a foto de perfil!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
