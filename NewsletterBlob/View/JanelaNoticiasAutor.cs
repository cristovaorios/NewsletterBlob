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
    public partial class JanelaNoticiasAutor : Form
    {
        public JanelaNoticiasAutor()
        {
            InitializeComponent();
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void pctBoxNoticiaComum01_Click(object sender, EventArgs e)
        {
            new JanelaEditarNoticias().Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor().Show();
            this.Hide();
        }
    }
}
