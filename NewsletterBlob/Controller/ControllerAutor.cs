using NewsletterBlob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Controller
{
    internal class ControllerAutor
    {
        //Verificar Usuário e Senha
        public string verificaUsuarioSenha(string registroProfissional, string senha)
        {
            try
            {
                List<string> usuario = new AutorDAO().comparaUsuarioSenha(registroProfissional, senha);

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
                Autor autor = new AutorDAO().listarAutor(registroProfissional);
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
                if (imagem != null)
                {
                    new AutorDAO().adicionarFotoPerfil(registroProfissional, imagem);
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
                new AutorDAO().deletarFotoPerfil(registroProfissional);
                MessageBox.Show("Foto Removida!", "Mensagem de SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Editar Usuário Leitor
        /*public void editarLeitor(string identificador, string nome, string email, DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            try
            {
                Leitor leitor = new Leitor(nome, email, dataDeNascimento, cpf, endereco, telefone, senha);
                new LeitorDAO().atualizarLeitor(leitor, identificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível editar os dados!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }*/
    }
}
