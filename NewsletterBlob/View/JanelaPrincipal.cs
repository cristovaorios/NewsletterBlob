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

        public JanelaPrincipal()
        {
            InitializeComponent();
            noticiasBanner = new ControllerNoticias().exibirNoticiasBanner();
        }
        public JanelaPrincipal(string identificador, bool ehAutor)
        {
            InitializeComponent();
            this.identificador = identificador;
            this.ehAutor = ehAutor;
            noticiasPrincipais = carregarNoticiasPrincipais();
            noticiasBanner = new ControllerNoticias().exibirNoticiasBanner();
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

                //Picture Box 2
                pctBoxNoticiaComum02.Image = ByteToImage.ByteArrayToImage(noticias[1].Imagem);
                lblNoticiaComum02.Text = noticias[1].Titulo;

                //Picture Box 3
                pctBoxNoticiaComum03.Image = ByteToImage.ByteArrayToImage(noticias[2].Imagem);
                lblNoticiaComum03.Text = noticias[2].Titulo;
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
            if (numImg == 0)
            {
                numImg = 4;
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
            new JanelaNoticiaExpandida(identificador, ehAutor, noticiasPrincipais[0].Id).Show();
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
                    // Recupera a imagem da lista usando o índice numImg
                    byte[] fotoBytes = noticiasBanner[numImg].Imagem;

                    // Converte o objeto byte[] em um objeto Image
                    using (MemoryStream ms = new MemoryStream(fotoBytes))
                    {
                        System.Drawing.Image foto = System.Drawing.Image.FromStream(ms);

                        // Define a propriedade Image do PictureBox com a imagem convertida
                        pb.Image = foto;
                        lb.Text = noticiasBanner[numImg].Titulo;
                    }
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

    }
}
