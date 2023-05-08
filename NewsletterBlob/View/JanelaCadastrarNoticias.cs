using NewsletterBlob.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.View
{
    public partial class JanelaCadastrarNoticias : Form
    {
        private string registroProfissional;
        private byte[] imagem = null;
        public JanelaCadastrarNoticias(string registroProfissional)
        {
            InitializeComponent();
            this.registroProfissional = registroProfissional;
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal(registroProfissional, true).Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor(registroProfissional).Show();
            this.Hide();
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            if (txtBoxTitulo.Text.Trim() == "")
            {
                pctBoxAlertaTitulo.Visible = true;
            }
            else if (txtBoxSubTitulo.Text.Trim() == "")
            {
                pctBoxAlertaSubTitulo.Visible = true;
            }
            else if (txtBoxAutor.Text.Trim() == "")
            {
                pctBoxAlertaAutor.Visible = true;
            }
            else if (txtBoxConteudo.Text.Trim() == "")
            {
                pctBoxAlertaConteudo.Visible = true;
            }
            else if(imagem == null)
            {
                MessageBox.Show("Necessário carregar uma imagem para a notícia!", "Aviso de Imagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (cmbBoxCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Necessário selecionar uma categoria para notícia!", "Aviso de Categoria", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    new ControllerNoticias().cadastrarNoticia(registroProfissional, txtBoxTitulo.Text.Trim(), txtBoxSubTitulo.Text.Trim(), txtBoxConteudo.Text.Trim(),
                        imagem, cmbBoxCategoria.SelectedItem.ToString(), txtBoxAutor.Text.Trim(), Convert.ToDateTime(dtTmPckrData.Value));
                    MessageBox.Show("Notícia publicada com sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBoxTitulo.Clear();
                    txtBoxSubTitulo.Clear();
                    txtBoxAutor.Clear();
                    txtBoxConteudo.Clear();
                    dtTmPckrData.Value = DateTime.Now;
                    cmbBoxCategoria.SelectedIndex = -1;
                    imagem = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Não foi possível publicar a notícia!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool carregarFoto()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png| *.jpg; *png";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string caminhoFoto = openFile.FileName;
                using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        // reposiciona o ponteiro de leitura no início do stream
                        stream.Seek(0, SeekOrigin.Begin);
                        imagem = new byte[stream.Length];
                        imagem = reader.ReadBytes((int)stream.Length);
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
                if(carregarFoto()) 
                    MessageBox.Show("Imagem carregada com sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Não foi possível carregar a imagem!", "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
