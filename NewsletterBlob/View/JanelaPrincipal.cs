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

        public JanelaPrincipal()
        {
            InitializeComponent();
        }
        public JanelaPrincipal(string identificador, bool ehAutor)
        {
            InitializeComponent();
            this.identificador = identificador;
            this.ehAutor = ehAutor;
            carregarNoticiasPrincipais();
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

        
        private void carregarNoticiasPrincipais()
        {
            List<Noticia> noticias = new ControllerNoticias().exibirPrincipaisNoticias();
            
            if(noticias != null && noticias.Count >= 3)
            {
                //Picture Box 1
                pctBoxNoticiaComum01.Image = ByteToImage.ByteArrayToImage(noticias[0].Imagem);
                lblNoticiaComum01.Text = noticias[0].Texto;

                //Picture Box 2
                pctBoxNoticiaComum02.Image = ByteToImage.ByteArrayToImage(noticias[1].Imagem);
                lblNoticiaComum02.Text = noticias[1].Texto;

                //Picture Box 3
                pctBoxNoticiaComum03.Image = ByteToImage.ByteArrayToImage(noticias[2].Imagem);
                lblNoticiaComum03.Text = noticias[2].Texto;
            }
            else
            {
                MessageBox.Show("Não foi possível carregar as notícias!");
            }
        }

        private void JanelaPrincipal_Load(object sender, EventArgs e)
        {

        }

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

        private void pctBoxSetaEsquerda_Click(object sender, EventArgs e)
        {

        }
    }
}
