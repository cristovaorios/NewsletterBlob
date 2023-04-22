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
    public partial class JanelaCadastrarUsuario : Form
    {
        public JanelaCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaLoginLeitor().Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }
    }
}
