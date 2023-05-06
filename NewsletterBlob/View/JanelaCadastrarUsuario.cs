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

namespace NewsletterBlob.View
{
    public partial class JanelaCadastrarUsuario : Form
    {
        public JanelaCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void pctBoxArrowBack_Click(object sender, EventArgs e)
        {
            new JanelaLoginLeitor().Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (rdBtnConcordaTermos.Checked)
            {
                try
                {
                    //Verificação
                    if(txtBoxNome.Text.Trim() == "")
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
                    else if(txtBoxTelefone.Text.Trim() == "")
                    {
                        pctBoxAlertaTelefone.Visible = true;
                    }
                    else if(txtBoxSenha.Text.Trim() == "")
                    {
                        pctBoxAlertaSenha.Visible = true;
                    }
                    else if(txtBoxConfirmaSenha.Text.Trim() == "")
                    {
                        pctBoxAlertaConfirmaSenha.Visible = true;
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
                            if (txtBoxConfirmaSenha.Text == txtBoxSenha.Text)
                            {
                                if (!controllerLeitor.verificaEmail(txtBoxEmail.Text.Trim()))
                                {
                                    pctBoxAlertaEmail.Visible = true;
                                }
                                else if(!controllerLeitor.verificaCpf(txtBoxCPF.Text.Trim()))
                                {
                                    pctBoxAlertaCPF.Visible = true;
                                }
                                else
                                {
                                    pctBoxAlertaNome.Visible = false;
                                    pctBoxAlertaEmail.Visible = false;
                                    pctBoxAlertaCPF.Visible = false;
                                    pctBoxAlertaEndereco.Visible = false;
                                    pctBoxAlertaTelefone.Visible = false;
                                    pctBoxAlertaSenha.Visible = false;
                                    pctBoxAlertaConfirmaSenha.Visible = false;
                                    controllerLeitor.cadastrarLeitor(txtBoxNome.Text.Trim(), txtBoxEmail.Text.Trim(),
                                        dtTmPckrDataNasc.Value, txtBoxCPF.Text.Trim(), txtBoxEndereco.Text.Trim(),
                                        txtBoxTelefone.Text.Trim(), txtBoxSenha.Text.Trim());
                                    new JanelaLoginLeitor().Show();
                                    this.Hide();
                                }
                            }
                            else
                                MessageBox.Show("As senhas devem ser iguais!", "Confimação de senha diferente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                            MessageBox.Show("O usuário deve ser maior de idade!", "Validação de Maioridade", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensagem de ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aceite os termos de contrato para criar uma conta na aplicação!", "Condição dos Termos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
