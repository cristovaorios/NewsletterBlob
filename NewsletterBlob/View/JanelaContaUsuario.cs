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
    public partial class JanelaContaUsuario : Form
    {
        public JanelaContaUsuario()
        {
            InitializeComponent();
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal().Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor().Show();
            this.Hide();
        }

        private void btnAlterarFoto_Click(object sender, EventArgs e)
        {
            carregarFoto();
        }

        private void carregarFoto()
        {
            string caminhoFoto = "";
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png| *.jpg; *png";
            openFile.Multiselect = false;

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = openFile.FileName;
            }
            if (caminhoFoto != "")
            {
                pctBoxFotoUsuario.Load(caminhoFoto);
            }
        }
    }
}
