using NewsletterBlob.Controller;
using NewsletterBlob.Model;
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
using static System.Net.Mime.MediaTypeNames;

namespace NewsletterBlob.View
{
    public partial class JanelaEditarNoticias : Form
    {
        private string identificador;
        private int id_noticia;
        private byte[] imagem = null;
        public JanelaEditarNoticias(string identificador, int id_noticia)
        {
            this.identificador = identificador;
            this.id_noticia = id_noticia;
            InitializeComponent();
            carregarDados(id_noticia);
        }

        private void carregarDados(int id_noticia)
        {
            try
            {
                Noticia noticia = new ControllerNoticias().exibirNoticia(id_noticia);
                txtBoxTitulo.Text = noticia.Titulo;
                txtBoxSubTitulo.Text = noticia.SubTitulo;
                txtBoxAutor.Text = noticia.Autores;
                txtBoxConteudo.Text = noticia.Texto;
                imagem = noticia.Imagem;
                int i;
                for(i=0; i<4; i++)
                {
                    if (cmbBoxCategoria.Items[i].Equals(noticia.Categoria))
                        break;
                }
                cmbBoxCategoria.SelectedIndex = i;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERRO ao carregar os dados da notícia!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaNoticiasAutor(identificador).Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            new JanelaOpcoesAutor(identificador).Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
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
            else if (imagem == null)
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
                    new ControllerNoticias().editarNoticia(id_noticia, txtBoxTitulo.Text.Trim(), txtBoxSubTitulo.Text.Trim(), txtBoxConteudo.Text.Trim(),
                        imagem, cmbBoxCategoria.SelectedItem.ToString(), txtBoxAutor.Text.Trim(), Convert.ToDateTime(dtTmPckrData.Value));
                    MessageBox.Show("Notícia Editada com sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível editar a notícia!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (carregarFoto())
                MessageBox.Show("Imagem carregada com sucesso!", "Mensagem de Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não foi possível carregar a imagem!", "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
