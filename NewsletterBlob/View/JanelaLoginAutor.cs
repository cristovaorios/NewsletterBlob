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
    }
}
