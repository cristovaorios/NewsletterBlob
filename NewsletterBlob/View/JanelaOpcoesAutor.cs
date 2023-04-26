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
    public partial class JanelaOpcoesAutor : Form
    {
        public JanelaOpcoesAutor()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void btnMinhaConta_Click(object sender, EventArgs e)
        {
            new JanelaContaUsuario().Show();
            this.Hide();
        }

        private void btnCriarPublicacao_Click(object sender, EventArgs e)
        {
            new JanelaCadastrarNoticias().Show();
            this.Hide();
        }

        private void btnEditarPublicacao_Click(object sender, EventArgs e)
        {
            new JanelaNoticiasAutor().Show();
            this.Hide();
        }
    }
}
