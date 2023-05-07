using NewsletterBlob.API;
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
