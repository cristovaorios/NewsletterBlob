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
    }
}
