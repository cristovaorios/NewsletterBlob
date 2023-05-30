using NewsletterBlob.Controller;
using NewsletterBlob.Model;
using NewsletterBlob.Util;
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
        private string identificador;
        private int idNoticia = 0;
        public JanelaNoticiasAutor(string identificador)
        {
            this.identificador = identificador;
            InitializeComponent();
            CarregarNoticiasAutor();
        }

        public void CarregarNoticiasAutor()
        {
            pnlNoticiasAutor.Controls.Clear();

            List<Noticia> noticias = new ControllerNoticias().listarNoticiasAutor(identificador);

            int y = 0;
            foreach (Noticia noticia in noticias)
            {
                Panel pnlNoticia = new Panel();
                pnlNoticia.Location = new Point(0, y);
                pnlNoticia.Size = new Size(560, 111); // Ajuste de largura para caber no pnlNoticiasAutor

                PictureBox pbImagem = new PictureBox();
                pbImagem.Location = new Point(0, 0);
                pbImagem.Size = new Size(112, 111);
                pbImagem.SizeMode = PictureBoxSizeMode.Zoom;
                pbImagem.Image = ByteToImage.ByteArrayToImage(noticia.Imagem);
                pbImagem.SizeMode = PictureBoxSizeMode.Zoom;
                // Evento de clique no Panel
                pbImagem.Click += (sender, e) =>
                {
                    idNoticia = noticia.Id; // Armazenar o id da notícia na variável global

                    // Alterar o BorderStyle do Panel clicado
                    foreach (Control control in pnlNoticiasAutor.Controls)
                    {
                        if (control is Panel)
                        {
                            Panel panel = (Panel)control;
                            panel.BorderStyle = (panel == pnlNoticia) ? BorderStyle.FixedSingle : BorderStyle.None;
                        }
                    }
                };

                Label lblTitulo = new Label();
                lblTitulo.Location = new Point(130, 10); // Ajuste de posição vertical
                lblTitulo.Size = new Size(430, 40); // Ajuste de tamanho
                lblTitulo.Text = noticia.Titulo;
                lblTitulo.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

                Label lblSubTitulo = new Label();
                lblSubTitulo.Location = new Point(130, 50); // Ajuste de posição vertical
                lblSubTitulo.Size = new Size(430, 51); // Ajuste de tamanho
                lblSubTitulo.Text = noticia.SubTitulo;
                lblSubTitulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);

                pnlNoticia.Controls.Add(pbImagem);
                pnlNoticia.Controls.Add(lblTitulo);
                pnlNoticia.Controls.Add(lblSubTitulo);

                pnlNoticiasAutor.Controls.Add(pnlNoticia);

                y += 111;
            }
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal(identificador, true).Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor(identificador).Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idNoticia > 0)
            {
                new JanelaEditarNoticias(identificador, idNoticia).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sem notícias selecionadas!", "Aviso de Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idNoticia > 0)
            {
                DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir essa publicação?", "Aviso de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(resp == DialogResult.Yes)
                {
                    new ControllerNoticias().excluirNoticia(identificador, idNoticia);
                }
            }
            else
            {
                MessageBox.Show("Sem notícias selecionadas!", "Aviso de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
