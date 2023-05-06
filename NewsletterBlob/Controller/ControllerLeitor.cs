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
    internal class ControllerLeitor
    {
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

        //Ler Usuário Leitor
        public Leitor exibirLeitor(string email)
        {
            try
            {
                Leitor leitor = new LeitorDAO().listarLeitor(email);
                MessageBox.Show("Dados Carregados com Sucesso!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Leitor leitor = new Leitor(nome, email, dataDeNascimento, cpf, endereco, telefone, senha);
                new LeitorDAO().atualizarLeitor(leitor, old_email);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível editar os dados!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Alterar Foto Usuário Leitor
        public void alterarFotoPerfil(string email, byte[] imagem)
        {
            try
            {
                if (imagem != null)
                {
                    new LeitorDAO().adicionarFotoPerfil(email, imagem);
                    MessageBox.Show("Foto Inserida com Sucesso!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new LeitorDAO().deletarFotoPerfil(email);
                MessageBox.Show("Foto Removida!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Excluir Usuário Leitor


    }
}
