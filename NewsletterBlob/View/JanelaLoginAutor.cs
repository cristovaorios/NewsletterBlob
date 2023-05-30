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
    public partial class JanelaLoginAutor: Form
    {
        public JanelaLoginAutor()
        {
            InitializeComponent();
        }

        private void lblLimpar_Click(object sender, EventArgs e)
        {
            txtBoxUsuario.Clear();
            txtBoxSenha.Clear();
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
                ControllerAutor controllerAutor = new ControllerAutor();

                string user = txtBoxUsuario.Text.Trim();
                string password = txtBoxSenha.Text.Trim();

                //Verificando Usuário e Senha
                string registroProfissional = controllerAutor.verificaUsuarioSenha(user, password);

                if (user == "" || password == "")
                {
                    MessageBox.Show("Digite usuário e senha para acessar a aplicação!", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (registroProfissional == null)
                {
                    MessageBox.Show("Usuário ou Senha Incorretos!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    new JanelaPrincipal(registroProfissional, true).Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaLoginLeitor().Show();
            this.Hide();
        }
    }
}
