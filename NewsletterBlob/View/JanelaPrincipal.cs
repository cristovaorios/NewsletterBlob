using NewsletterBlob.API;
using NewsletterBlob.Model;
using NewsletterBlob.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using NewsletterBlob.Util;

namespace NewsletterBlob.View
{
    public partial class JanelaPrincipal : Form
    {
        
        private bool ehAutor = false;
        private string identificador;
        private List<Noticia> noticiasPrincipais;
        private List<Noticia> noticiasBanner;
        int numImg = 0;
        int indiceNoticiaAtual;

        public JanelaPrincipal(string identificador, bool ehAutor)
        {
            InitializeComponent();
            
            this.identificador = identificador;
            this.ehAutor = ehAutor;
            noticiasPrincipais = carregarNoticiasPrincipais();
            noticiasBanner = new ControllerNoticias().exibirNoticiasBanner();
            if (noticiasBanner != null && noticiasBanner.Count > 0)
            {
                // Defina a primeira imagem do banner como o InitialImage do pctBoxNoticiaBanner
                byte[] primeiraImagem = noticiasBanner[0].Imagem;
                pctBoxNoticiaBanner.Image = ByteToImage.ByteArrayToImage(primeiraImagem);
                lblNoticiaBanner.Text = noticiasBanner[0].Titulo;
            }

            /* Recurso Cidade Temperatura de API
            try
            {
                // Capturando Cidade e Temperatura de API
                WeatherService service = new WeatherService();
                WeatherInfo info = service.GetWeatherInfo("São Luís");
                lblLocalizacao.Text = info.City;
                lblClima.Text = info.Temperature + "ºC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar a API!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }*/
        }

        
        private List<Noticia> carregarNoticiasPrincipais()
        {
            List<Noticia> noticias = new ControllerNoticias().exibirPrincipaisNoticias();
            
            if(noticias != null && noticias.Count >= 3)
            {
                //Picture Box 1
                pctBoxNoticiaComum01.Image = ByteToImage.ByteArrayToImage(noticias[0].Imagem);
                lblNoticiaComum01.Text = noticias[0].Titulo;
                config_size_label(lblNoticiaComum01);

                //Picture Box 2
                pctBoxNoticiaComum02.Image = ByteToImage.ByteArrayToImage(noticias[1].Imagem);
                lblNoticiaComum02.Text = noticias[1].Titulo;
                config_size_label(lblNoticiaComum02);

                //Picture Box 3
                pctBoxNoticiaComum03.Image = ByteToImage.ByteArrayToImage(noticias[2].Imagem);
                lblNoticiaComum03.Text = noticias[2].Titulo;
                config_size_label(lblNoticiaComum03);
                return noticias;
            }
            else
            {
                MessageBox.Show("Não foi possível carregar as notícias!");
                return null;
            }
        }
        public void Carrossel()
        {
            indiceNoticiaAtual = numImg;
            converterFoto(numImg, pctBoxNoticiaBanner, lblNoticiaBanner);

            if (numImg == 4)
            {
                numImg = 0;
            }
            else
            {
                numImg++;
            }
        }

        public void Carrossel_Invertido()
        {
            indiceNoticiaAtual = numImg - 1;
            if (numImg == 0)
            {
                numImg = noticiasBanner.Count - 1;
            }
            else
            {
                numImg--;
            }
            converterFoto(numImg, pctBoxNoticiaBanner, lblNoticiaBanner);
        }
        private void timerCarrossel_Tick(object sender, EventArgs e)
        {
            Carrossel();
        }

        private void pctBoxSetaDireita_Click(object sender, EventArgs e)
        {
            Carrossel();
        }

        private void pctBoxSetaEsquerda_Click(object sender, EventArgs e)
        {
            Carrossel_Invertido();
        }


        private void JanelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pctBoxNoticiaBanner_Click(object sender, EventArgs e)
        {
            if(indiceNoticiaAtual < 0)
            {
                indiceNoticiaAtual = 4;
            }
            new JanelaNoticiaExpandida(identificador, ehAutor, noticiasBanner[indiceNoticiaAtual].Id).Show();
            this.Hide();
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

        private void lblTecnologia_Click(object sender, EventArgs e){}



        private void pctBoxNoticiaComum01_Click(object sender, EventArgs e)
        {
            if (noticiasPrincipais != null && noticiasPrincipais.Count >= 3)
            {
                new JanelaNoticiaExpandida(identificador, ehAutor, noticiasPrincipais[0].Id).Show();
                this.Hide();
            }
        }

        private void pctBoxNoticiaComum02_Click(object sender, EventArgs e)
        {
            if (noticiasPrincipais != null && noticiasPrincipais.Count >= 3)
            {
                new JanelaNoticiaExpandida(identificador, ehAutor, noticiasPrincipais[1].Id).Show();
                this.Hide();
            }
        }

        private void pctBoxNoticiaComum03_Click(object sender, EventArgs e)
        {
            if (noticiasPrincipais != null && noticiasPrincipais.Count >= 3)
            {
                new JanelaNoticiaExpandida(identificador, ehAutor, noticiasPrincipais[2].Id).Show();
                this.Hide();
            }
        }
        public void converterFoto(int numImg, PictureBox pb, Label lb)
        {
            try
            {
                if (noticiasBanner != null && numImg >= 0 && numImg < noticiasBanner.Count)
                {
                    pb.Image = ByteToImage.ByteArrayToImage(noticiasBanner[numImg].Imagem);
                    lb.Text = noticiasBanner[numImg].Titulo;
                    config_size_label(lb);
                    /*
                    // Recupera a imagem da lista usando o índice numImg
                    byte[] fotoBytes = noticiasBanner[numImg].Imagem;
                    // Converte o objeto byte[] em um objeto Image
                    using (MemoryStream ms = new MemoryStream(fotoBytes))
                    {
                        System.Drawing.Image foto = System.Drawing.Image.FromStream(ms);
                        // Define a propriedade Image do PictureBox com a imagem convertida
                        pb.Image = foto;
                        lb.Text = noticiasBanner[numImg].Titulo;
                        
                    }*/
                }
                else
                {
                    MessageBox.Show("Não há imagens disponíveis.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void config_label_noticias_princi(Label lbl)
        {
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            int larguraMaxima = 200;
            lbl.MaximumSize = new Size(larguraMaxima, 0);
            int alturaMaxima = 500;
            lbl.MaximumSize = new Size(larguraMaxima, alturaMaxima);
        }
        public void config_label_noticia_banner(Label lbl)
        {
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            int larguraMaxima = 200;
            int alturaMaxima = 500;
            lbl.MaximumSize = new Size(larguraMaxima, alturaMaxima);

        }
        private void config_size_label(Label lbl)
        {
            SizeF tamanhoTexto = TextRenderer.MeasureText(lbl.Text, lbl.Font, lbl.MaximumSize, TextFormatFlags.WordBreak);
            lbl.Height = (int)Math.Ceiling(tamanhoTexto.Height);
        }

    }
}
