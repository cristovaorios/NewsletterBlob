using NewsletterBlob.Controller;
using NewsletterBlob.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NewsletterBlob.View
{
    public partial class JanelaContaUsuario : Form
    {
        private string identificador;
        private bool ehAutor = false;
        public JanelaContaUsuario(string identificador, bool ehAutor)
        {
            this.identificador = identificador;
            this.ehAutor = ehAutor;
            InitializeComponent();
            carregarDados();
        }
        public JanelaContaUsuario()
        {
            InitializeComponent();
        }

        private void carregarDados()
        {
            try
            {
                if (ehAutor)
                {
                    Autor autor = new ControllerAutor().exibirAutor(identificador);
                    txtBoxNome.Text = autor.Nome;
                    txtBoxEmail.Text = autor.Email;
                    dtTmPckrDataNasc.Value = autor.DataDeNascimento;
                    txtBoxCPF.Text = autor.Cpf;
                    txtBoxEndereco.Text = autor.Endereco;
                    txtBoxTelefone.Text = autor.Telefone;
                    txtBoxSenha.Text = autor.Senha;
                    if (autor.ImagemPerfil != null && autor.ImagemPerfil.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(autor.ImagemPerfil))
                        {
                            // converter MemoryStream em Stream
                            Stream stream = new MemoryStream(ms.ToArray());

                            // solução para erro de parâmetro inválido
                            Image imagem = null;
                            try
                            {
                                //posicionando o ponteiro de leitura do stream no início dos dados da imagem
                                stream.Seek(0, SeekOrigin.Begin);
                                imagem = Image.FromStream(stream);
                                // Atribuindo a imagem ao PictureBox
                                pctBoxFotoUsuario.Image = imagem;
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show("Não foi possível carregar a imagem!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    Leitor leitor = new ControllerLeitor().exibirLeitor(identificador);
                    txtBoxNome.Text = leitor.Nome;
                    txtBoxEmail.Text = leitor.Email;
                    dtTmPckrDataNasc.Value = leitor.DataDeNascimento;
                    txtBoxCPF.Text = leitor.Cpf;
                    txtBoxEndereco.Text = leitor.Endereco;
                    txtBoxTelefone.Text = leitor.Telefone;
                    txtBoxSenha.Text = leitor.Senha;
                    if (leitor.ImagemPerfil != null && leitor.ImagemPerfil.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(leitor.ImagemPerfil))
                        {
                            // converter MemoryStream em Stream
                            Stream stream = new MemoryStream(ms.ToArray());

                            // solução para erro de parâmetro inválido
                            Image imagem = null;
                            try
                            {
                                //posicionando o ponteiro de leitura do stream no início dos dados da imagem
                                stream.Seek(0, SeekOrigin.Begin);
                                imagem = Image.FromStream(stream);
                                // Atribuindo a imagem ao PictureBox
                                pctBoxFotoUsuario.Image = imagem;
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show("Não foi possível carregar a imagem!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show("Não foi possível carregar todos os dados do usuário!", err.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaPrincipal(identificador, ehAutor).Show();
            this.Hide();
        }

        private void pctBoxPerfil_Click(object sender, EventArgs e)
        {
            if (ehAutor)
            {
                new JanelaOpcoesAutor().Show();
                this.Hide();
            }
        }

        private void btnAlterarFoto_Click(object sender, EventArgs e)
        {
            byte[] imagem = carregarFoto();
            if (imagem != null)
            {
                if (ehAutor)
                {
                    new ControllerAutor().alterarFotoPerfil(this.identificador, imagem);
                    MessageBox.Show("Imagem de perfil alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    new ControllerLeitor().alterarFotoPerfil(this.identificador, imagem);
                    MessageBox.Show("Imagem de perfil alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private byte[] carregarFoto()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png| *.jpg; *png";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string caminhoFoto = openFile.FileName;
                pctBoxFotoUsuario.Load(caminhoFoto);
                using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        // reposiciona o ponteiro de leitura no início do stream
                        stream.Seek(0, SeekOrigin.Begin);
                        return reader.ReadBytes((int)stream.Length);
                    }
                }
            }
            else
            {
                return null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtBoxNome.Text.Trim() == "")
            {
                pctBoxAlertaNome.Visible = true;
            }
            else if (txtBoxEmail.Text.Trim() == "")
            {
                pctBoxAlertaEmail.Visible = true;
            }
            else if (txtBoxCPF.Text.Trim() == "")
            {
                pctBoxAlertaCPF.Visible = true;
            }
            else if (txtBoxEndereco.Text.Trim() == "")
            {
                pctBoxAlertaEndereco.Visible = true;
            }
            else if (txtBoxTelefone.Text.Trim() == "")
            {
                pctBoxAlertaTelefone.Visible = true;
            }
            else if (txtBoxSenha.Text.Trim() == "")
            {
                pctBoxAlertaSenha.Visible = true;
            }
            else
            {
                if (ehAutor)
                {
                    //Controller Autor
                }
                else
                {
                    ControllerLeitor controllerLeitor = new ControllerLeitor();

                    //Verificando a idade
                    DateTime dataNascimento = Convert.ToDateTime(dtTmPckrDataNasc.Value);
                    int idade = DateTime.Now.Year - dataNascimento.Year;
                    if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                    {
                        idade = idade - 1;
                    }

                    if (idade >= 18)
                    {
                        controllerLeitor.editarLeitor(identificador, txtBoxNome.Text.Trim(), txtBoxEmail.Text.Trim(),
                            dtTmPckrDataNasc.Value, txtBoxCPF.Text.Trim(), txtBoxEndereco.Text.Trim(),
                            txtBoxTelefone.Text.Trim(), txtBoxSenha.Text.Trim());
                        identificador = txtBoxEmail.Text.Trim();
                    }
                    else
                        MessageBox.Show("O usuário deve ser maior de idade!", "Validação de Maioridade", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }            
            }
        }

        private void btnApagarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (pctBoxFotoUsuario.Image != null)
                {
                    DialogResult op = MessageBox.Show("Tem certeza que deseja excluir a foto de perfil?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (op == DialogResult.Yes)
                    {
                        if (ehAutor)
                        {
                            ControllerAutor controllerAutor = new ControllerAutor();
                            controllerAutor.removerFotoPerfil(this.identificador);
                            pctBoxFotoUsuario.Image = null;
                        }
                        else
                        {
                            ControllerLeitor controllerLeitor = new ControllerLeitor();
                            controllerLeitor.removerFotoPerfil(this.identificador);
                            pctBoxFotoUsuario.Image = null;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível excluir a imagem!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
/*// Ler a imagem de um arquivo
byte[] imagemBytes = File.ReadAllBytes("imagem.jpg");

// Conectar com o banco de dados
MySqlConnection conexao = new MySqlConnection("string_de_conexao");
conexao.Open();

// Criar uma instrução SQL que insere a imagem na tabela
string sql = "INSERT INTO tabela (nome, imagem) VALUES (@nome, @imagem)";

// Criar um objeto Command e definir seus parâmetros
MySqlCommand comando = new MySqlCommand(sql, conexao);
comando.Parameters.AddWithValue("@nome", "imagem.jpg");
comando.Parameters.AddWithValue("@imagem", imagemBytes);

// Executar o comando
comando.ExecuteNonQuery();

// Fechar a conexão
conexao.Close();*/


/*
 // supondo que você tenha a cadeia de bytes da imagem em um array chamado "byteArray"
using (MemoryStream stream = new MemoryStream(byteArray))
{
    pictureBox1.Image = Image.FromStream(stream);
}
 */



/*
 if (imagemBytes != null && imagemBytes.Length > 0)
{
   using (MemoryStream ms = new MemoryStream(imagemBytes))
   {
      pictureBox1.Image = Image.FromStream(ms);
   }
}
else
{
   // exibir uma mensagem ou atribuir uma imagem padrão quando o array de bytes estiver vazio
   pictureBox1.Image = Properties.Resources.defaultImage;
}
 */

/*
string base64string = info.GetString(6);
byte[] blobImage = Convert.FromBase64String(base64string);

using (MemoryStream ms = new MemoryStream(blobImage))
{
 pictureCadastro.Image = Image.FromStream(ms);
}
*/