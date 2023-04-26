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
    public partial class JanelaNoticiaExpandida : Form
    {
        public JanelaNoticiaExpandida()
        {
            InitializeComponent();
        }

        private void lblGeral_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void pctBoxLogo_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void pctBoxLike_Click(object sender, EventArgs e)
        {
            int likes = Convert.ToInt32(lblLike.Text);
            int qtdLikes = likes + 1;
            lblLike.Text = qtdLikes.ToString();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor().Show();
            this.Hide();
        }
    }
}
