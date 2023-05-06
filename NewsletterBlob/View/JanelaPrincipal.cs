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
    public partial class JanelaPrincipal : Form
    {
        private string email;
        public JanelaPrincipal()
        {
            InitializeComponent();
        }
        public JanelaPrincipal(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void JanelaPrincipal_Load(object sender, EventArgs e){}

        private void pctBoxSetaDireita_Click(object sender, EventArgs e)
        {

        }

        private void pctBoxNoticiaBanner_Click(object sender, EventArgs e)
        {
            new JanelaNoticiaExpandida().Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaContaUsuario(email).Show();
            this.Hide();
        }

        private void lblTecnologia_Click(object sender, EventArgs e){}
    }
}
