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

namespace NewsletterBlob.View
{
    public partial class JanelaPrincipal : Form
    {
        private bool ehAutor = false;
        private string identificador;

        public JanelaPrincipal()
        {
            InitializeComponent();
            carregarNoticias();
        }
        public JanelaPrincipal(string identificador, bool ehAutor)
        {
            InitializeComponent();
            this.identificador = identificador;
            this.ehAutor = ehAutor;
            carregarNoticias();
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

        private void carregarNoticias()
        {
            List<Noticia> noticias = new List<Noticia>();
            for (int i = 1; i < 3; i++)
            {
                noticias.Add(new ControllerNoticias().exibirNoticia(i));
            }
            using (MemoryStream ms = new MemoryStream(noticias[0].Imagem))
            {
                // converter MemoryStream em Stream
                Stream stream = new MemoryStream(ms.ToArray());
                // solução para erro de parâmetro inválido
                Image imagem = null;
                //posicionando o ponteiro de leitura do stream no início dos dados da imagem
                stream.Seek(0, SeekOrigin.Begin);
                imagem = Image.FromStream(stream);
                // Atribuindo a imagem ao PictureBox
                pctBoxNoticiaComum01.Image = imagem;
            }
            lblNoticiaComum01.Text = noticias[0].Texto;
            using (MemoryStream ms = new MemoryStream(noticias[1].Imagem))
            {
                // converter MemoryStream em Stream
                Stream stream = new MemoryStream(ms.ToArray());
                // solução para erro de parâmetro inválido
                Image imagem = null;
                //posicionando o ponteiro de leitura do stream no início dos dados da imagem
                stream.Seek(0, SeekOrigin.Begin);
                imagem = Image.FromStream(stream);
                // Atribuindo a imagem ao PictureBox
                pctBoxNoticiaComum02.Image = imagem;
            }
            lblNoticiaComum02.Text = noticias[1].Texto;
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
    }
}
