using NewsletterBlob.Controller;
using NewsletterBlob.Model;
using NewsletterBlob.Properties;
using NewsletterBlob.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            carregarNoticia(idNoticia);
            ListarComentarios(getComentariosNoticia(idNoticia));
        }

        private List<Comentario> getComentariosNoticia(int idNoticia)
        {
            return new ControllerComentario().listarComentariosNoticia(idNoticia);
        }

        private void carregarComponentesVisuaisComentario()
        {
            pnlComentarios.Controls.Clear();

            // Estilização do Label "Comentários"
            Label lblTituloComentarios = new Label();
            lblTituloComentarios.Text = "Comentários";
            lblTituloComentarios.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold);
            lblTituloComentarios.ForeColor = Color.FromArgb(19, 75, 128);
            lblTituloComentarios.Location = new Point(96, 15);
            lblTituloComentarios.Size = new Size(105, 18);
            lblTituloComentarios.TextAlign = ContentAlignment.TopCenter;

            // Estilização do painel de underline
            Panel pnlUnderline = new Panel();
            pnlUnderline.BackColor = Color.FromArgb(19, 75, 128);
            pnlUnderline.BorderStyle = BorderStyle.None;
            pnlUnderline.Location = new Point(74, 41);
            pnlUnderline.Size = new Size(150, 2);

            pnlComentarios.Controls.Add(lblTituloComentarios);
            pnlComentarios.Controls.Add(pnlUnderline);
        }

        private void ListarComentarios(List<Comentario> comentarios)
        {
            carregarComponentesVisuaisComentario();

            int y = 66;
            int panelHeightDefault = 63; // Altura padrão do painel

            foreach (Comentario comentario in comentarios)
            {
                Panel pnlComentario = new Panel();
                pnlComentario.Location = new Point(13, y);
                pnlComentario.BorderStyle = BorderStyle.FixedSingle;
                pnlComentario.Tag = comentario.IdComentario; // Armazena o idComentario no Tag do Panel

                PictureBox pctBoxFotoLeitor = new PictureBox();
                pctBoxFotoLeitor.Location = new Point(13, 15);
                pctBoxFotoLeitor.Size = new Size(30, 33);
                pctBoxFotoLeitor.SizeMode = PictureBoxSizeMode.Zoom;
                Image imagem = ByteToImage.ByteArrayToImage(comentario.ImagemAutor);

                if (imagem == null)
                    pctBoxFotoLeitor.Image = Resources.icon_no_profile_photo;
                else
                    pctBoxFotoLeitor.Image = imagem;

                Label lblComentario = new Label();
                lblComentario.Location = new Point(49, 12);
                lblComentario.AutoSize = true;
                lblComentario.MaximumSize = new Size(146, 0);
                lblComentario.Text = comentario.Texto;
                lblComentario.Font = new Font("Microsoft Sans Serif", 8.25f);
                lblComentario.ForeColor = Color.Black;

                // Calcula a altura do texto
                int comentarioHeight = MeasureTextHeight(comentario.Texto, lblComentario.Font, lblComentario.MaximumSize.Width) + 20; // Altura do texto + espaço para o PictureBox e margem inferior

                if (comentarioHeight < panelHeightDefault)
                {
                    comentarioHeight = panelHeightDefault;
                    lblComentario.MaximumSize = new Size(146, lblComentario.PreferredHeight);
                }

                pnlComentario.Size = new Size(264, comentarioHeight);

                if (comentario.IdAutor == new ControllerComentario().getIdLeitor(identificador))
                {
                    PictureBox pctBoxDeletaComentario = new PictureBox();
                    pctBoxDeletaComentario.Location = new Point(232, 23);
                    pctBoxDeletaComentario.Size = new Size(18, 20);
                    pctBoxDeletaComentario.SizeMode = PictureBoxSizeMode.Zoom;
                    pctBoxDeletaComentario.Image = Resources.Vector__7_;

                    // Evento de clique para deletar o comentário
                    pctBoxDeletaComentario.Click += (sender, e) =>
                    {
                        // Obtém o idComentario do Panel pai do PictureBox
                        int idComentario = (int)pnlComentario.Tag;
                        deletarComentario(idComentario);
                    };

                    pnlComentario.Controls.Add(pctBoxDeletaComentario);
                }

                pnlComentario.Controls.Add(pctBoxFotoLeitor);
                pnlComentario.Controls.Add(lblComentario);

                pnlComentarios.Controls.Add(pnlComentario);

                y += comentarioHeight + 5;
            }
        }

        private int MeasureTextHeight(string text, Font font, int width)
        {
            using (Graphics graphics = CreateGraphics())
            {
                SizeF size = graphics.MeasureString(text, font, width);
                return (int)Math.Ceiling(size.Height);
            }
        }

        private void deletarComentario(int idComentario)
        {
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir esse comentário?", "Aviso de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (resp == DialogResult.Yes)
            {
                // Excluir o comentário usando o idComentario
                new ControllerComentario().excluirComentario(idComentario);
                ListarComentarios(getComentariosNoticia(idNoticia));
            }
        }

        private void carregarNoticia(int idNoticia)
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
            if (!ehAutor)
            {
                bool jaCurtiu = new ControllerCurtida().verificarNoticiaCurtida(idNoticia, identificador);
                if (jaCurtiu)
                {
                 
                    MessageBox.Show("Entrei em descurtir");
                    int resp = new ControllerCurtida().descurtirNoticia(idNoticia, identificador);
                    if (resp == 0)
                    {
                        MessageBox.Show("Não foi possível descurtir!", "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int likes = Convert.ToInt32(lblLike.Text);
                        int qtdLikes = likes - 1;
                        lblLike.Text = qtdLikes.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Entrei em cadastrar curtida");
                    new ControllerCurtida().cadastrarCurtida(idNoticia, identificador, true);
                    int likes = Convert.ToInt32(lblLike.Text);
                    int qtdLikes = likes + 1;
                    lblLike.Text = qtdLikes.ToString();
                }
            }
            else
            {
                MessageBox.Show("Perfis do tipo Autor não podem curtir e comentar em publicações!", "Messagem de Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            string texto = txtBoxComentario.Text.Trim();
            if (!ehAutor)
            {
                if (texto.Length > 0)
                {
                    new ControllerComentario().cadastrarComentario(idNoticia, identificador, texto);
                    ListarComentarios(getComentariosNoticia(idNoticia));
                    txtBoxComentario.Clear();
                }
            }
            else
            {
                MessageBox.Show("Perfis do tipo Autor não podem curtir e comentar em publicações!", "Messagem de Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
