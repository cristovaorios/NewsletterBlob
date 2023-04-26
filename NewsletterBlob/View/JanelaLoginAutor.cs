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
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaLoginLeitor().Show();
            this.Hide();
        }
    }
}
