using NewsletterBlob.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.View
{
    public partial class JanelaLoginLeitor : Form
    {
        public JanelaLoginLeitor()
        {
            InitializeComponent();
        }

        private void JanelaLoginLeitor_Load(object sender, EventArgs e){}

        private void lblLimpar_Click(object sender, EventArgs e)
        {
            txtBoxUsuario.Clear();
            txtBoxSenha.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new JanelaCadastrarUsuario().Show();
            this.Hide();
        }

        private void lblEntrarAutor_Click(object sender, EventArgs e)
        {
            new JanelaLoginAutor().Show();
            this.Hide();
        }

        private void checkBoxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarSenha.Checked)
            {
                txtBoxSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerLeitor controllerLeitor = new ControllerLeitor();

                string user = txtBoxUsuario.Text.Trim();
                string password = txtBoxSenha.Text.Trim();

                //Verificando Usuário e Senha
                string email = controllerLeitor.verificaUsuarioSenha(user, password);

                if (user == "" || password == "")
                {
                    MessageBox.Show("Digite usuário e senha para acessar a aplicação!", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (email == null)
                {
                    MessageBox.Show("Usuário ou Senha Incorretos!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show($"Você conseguir logar com a conta: {email}");
                    new JanelaPrincipal(email).Show();
                    this.Hide();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
