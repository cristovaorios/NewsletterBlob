using NewsletterBlob.Controller;
using NewsletterBlob.Model;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.View
{
    public partial class JanelaNoticiaExpandida : Form
    {
        private bool ehAutor;
        private string identificador;
        private int idNoticia;
        public JanelaNoticiaExpandida(string identificador, bool ehAutor, int idNoticia)
        {
            this.ehAutor = ehAutor;
            this.identificador = identificador;
            this.idNoticia = idNoticia;
            InitializeComponent();
            carregarNoticia();
        }

        private void carregarNoticia()
        {
            try
            {
                Noticia noticia = new ControllerNoticias().exibirNoticia(idNoticia);
                if (noticia != null)
                {
                    lblTitulo.MaximumSize = new Size(517, 0);
                    lblTitulo.Text = noticia.Titulo;

                    lblSubTitulo.MaximumSize = new Size(517, 0);
                    lblSubTitulo.Text = noticia.SubTitulo;
                    lblSubTitulo.Top = lblTitulo.Top + lblTitulo.Height + 5; // Ajuste a posição vertical do lblSubTitulo

                    lblAutores.Text = noticia.Autores;
                    lblAutores.Top = lblSubTitulo.Top + lblSubTitulo.Height + 5; // Ajuste a posição vertical do lblAutores

                    lblData.Text = noticia.DataPublicacao.ToString("dd/MM/yyyy");
                    lblData.Top = lblAutores.Top + lblAutores.Height + 5; // Ajuste a posição vertical do lblData
                    
                    pctBoxNoticia.Image = ByteToImage.ByteArrayToImage(noticia.Imagem);
                    pctBoxNoticia.Top = lblData.Top + lblData.Height + 5; // Ajuste a posição vertical do pctBoxNoticia

                    lblConteudoNoticia.Text = noticia.Texto;
                    lblConteudoNoticia.Top = pctBoxNoticia.Top + pctBoxNoticia.Height + 5; // Ajuste a posição vertical do lblConteudoNoticia

                    lblLike.Text = noticia.QtdCurtidas.ToString();

                    // Calcular a altura do texto e ajustar a altura do label
                    int tituloHeight = TextRenderer.MeasureText(noticia.Titulo, lblTitulo.Font, lblTitulo.MaximumSize, TextFormatFlags.WordBreak).Height;
                    int subtituloHeight = TextRenderer.MeasureText(noticia.SubTitulo, lblSubTitulo.Font, lblSubTitulo.MaximumSize, TextFormatFlags.WordBreak).Height;
                    int autoresHeight = TextRenderer.MeasureText(noticia.Autores, lblAutores.Font, lblAutores.Size, TextFormatFlags.WordBreak).Height;
                    int conteudoHeight = TextRenderer.MeasureText(noticia.Texto, lblConteudoNoticia.Font, lblConteudoNoticia.Size, TextFormatFlags.WordBreak).Height;

                    lblTitulo.Height = tituloHeight;
                    lblSubTitulo.Height = subtituloHeight;
                    lblAutores.Height = autoresHeight;
                    lblConteudoNoticia.Height = conteudoHeight;
                }
                else
                {
                    MessageBox.Show("Notícia não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar a notícia!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblGeral_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal(identificador, ehAutor).Show();
            this.Hide();
        }

        private void pctBoxLogo_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal(identificador, ehAutor).Show();
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
            if (ehAutor)
            {
                new JanelaOpcoesAutor(identificador).Show();
                this.Hide();
            }
            else
            {
                new JanelaContaUsuario(identificador, ehAutor).Show();
                this.Hide();
            }
        }

        private void btnPostarComentario_Click(object sender, EventArgs e)
        {

        }
    }
}
