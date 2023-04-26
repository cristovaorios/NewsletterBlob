
namespace NewsletterBlob.View
{
    partial class JanelaNoticiasAutor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaNoticiasAutor));
            this.pctBoxPerfil = new System.Windows.Forms.PictureBox();
            this.pctBoxArrowBack = new System.Windows.Forms.PictureBox();
            this.lblCadastraNoticia = new System.Windows.Forms.Label();
            this.lblSuasPublicacoes = new System.Windows.Forms.Label();
            this.pnlNoticiasAutor = new System.Windows.Forms.Panel();
            this.lblNoticiacomum02 = new System.Windows.Forms.Label();
            this.pctBoxNoticiaComum01 = new System.Windows.Forms.PictureBox();
            this.lblNoticiaComum01 = new System.Windows.Forms.Label();
            this.pctBoxNoticiaComum02 = new System.Windows.Forms.PictureBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArrowBack)).BeginInit();
            this.pnlNoticiasAutor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxNoticiaComum01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxNoticiaComum02)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxPerfil
            // 
            this.pctBoxPerfil.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBoxPerfil.Image = global::NewsletterBlob.Properties.Resources.Component_4;
            this.pctBoxPerfil.Location = new System.Drawing.Point(882, 19);
            this.pctBoxPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxPerfil.Name = "pctBoxPerfil";
            this.pctBoxPerfil.Size = new System.Drawing.Size(38, 41);
            this.pctBoxPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxPerfil.TabIndex = 75;
            this.pctBoxPerfil.TabStop = false;
            this.pctBoxPerfil.Click += new System.EventHandler(this.pctBoxPerfil_Click);
            // 
            // pctBoxArrowBack
            // 
            this.pctBoxArrowBack.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxArrowBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBoxArrowBack.Image = global::NewsletterBlob.Properties.Resources.Frame__2_;
            this.pctBoxArrowBack.Location = new System.Drawing.Point(22, 19);
            this.pctBoxArrowBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxArrowBack.Name = "pctBoxArrowBack";
            this.pctBoxArrowBack.Size = new System.Drawing.Size(30, 32);
            this.pctBoxArrowBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxArrowBack.TabIndex = 74;
            this.pctBoxArrowBack.TabStop = false;
            this.pctBoxArrowBack.Click += new System.EventHandler(this.pctBoxArrowBack_Click);
            // 
            // lblCadastraNoticia
            // 
            this.lblCadastraNoticia.AutoSize = true;
            this.lblCadastraNoticia.BackColor = System.Drawing.Color.Transparent;
            this.lblCadastraNoticia.Font = new System.Drawing.Font("Poppins", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastraNoticia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblCadastraNoticia.Location = new System.Drawing.Point(345, 58);
            this.lblCadastraNoticia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCadastraNoticia.Name = "lblCadastraNoticia";
            this.lblCadastraNoticia.Size = new System.Drawing.Size(273, 48);
            this.lblCadastraNoticia.TabIndex = 73;
            this.lblCadastraNoticia.Text = "Editar publicação";
            // 
            // lblSuasPublicacoes
            // 
            this.lblSuasPublicacoes.AutoSize = true;
            this.lblSuasPublicacoes.BackColor = System.Drawing.Color.Transparent;
            this.lblSuasPublicacoes.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuasPublicacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblSuasPublicacoes.Location = new System.Drawing.Point(185, 126);
            this.lblSuasPublicacoes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSuasPublicacoes.Name = "lblSuasPublicacoes";
            this.lblSuasPublicacoes.Size = new System.Drawing.Size(137, 25);
            this.lblSuasPublicacoes.TabIndex = 76;
            this.lblSuasPublicacoes.Text = "Suas publicações:";
            // 
            // pnlNoticiasAutor
            // 
            this.pnlNoticiasAutor.AutoScroll = true;
            this.pnlNoticiasAutor.BackColor = System.Drawing.Color.Transparent;
            this.pnlNoticiasAutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoticiasAutor.Controls.Add(this.lblNoticiacomum02);
            this.pnlNoticiasAutor.Controls.Add(this.pctBoxNoticiaComum01);
            this.pnlNoticiasAutor.Controls.Add(this.lblNoticiaComum01);
            this.pnlNoticiasAutor.Controls.Add(this.pctBoxNoticiaComum02);
            this.pnlNoticiasAutor.ForeColor = System.Drawing.Color.Black;
            this.pnlNoticiasAutor.Location = new System.Drawing.Point(189, 162);
            this.pnlNoticiasAutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlNoticiasAutor.Name = "pnlNoticiasAutor";
            this.pnlNoticiasAutor.Size = new System.Drawing.Size(574, 322);
            this.pnlNoticiasAutor.TabIndex = 77;
            // 
            // lblNoticiacomum02
            // 
            this.lblNoticiacomum02.AutoSize = true;
            this.lblNoticiacomum02.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticiacomum02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNoticiacomum02.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoticiacomum02.Location = new System.Drawing.Point(416, 78);
            this.lblNoticiacomum02.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoticiacomum02.Name = "lblNoticiacomum02";
            this.lblNoticiacomum02.Size = new System.Drawing.Size(122, 25);
            this.lblNoticiacomum02.TabIndex = 81;
            this.lblNoticiacomum02.Text = "Título da notícia";
            // 
            // pctBoxNoticiaComum01
            // 
            this.pctBoxNoticiaComum01.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxNoticiaComum01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxNoticiaComum01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBoxNoticiaComum01.Location = new System.Drawing.Point(44, 37);
            this.pctBoxNoticiaComum01.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxNoticiaComum01.Name = "pctBoxNoticiaComum01";
            this.pctBoxNoticiaComum01.Size = new System.Drawing.Size(112, 111);
            this.pctBoxNoticiaComum01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxNoticiaComum01.TabIndex = 78;
            this.pctBoxNoticiaComum01.TabStop = false;
            this.pctBoxNoticiaComum01.Click += new System.EventHandler(this.pctBoxNoticiaComum01_Click);
            // 
            // lblNoticiaComum01
            // 
            this.lblNoticiaComum01.AutoSize = true;
            this.lblNoticiaComum01.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticiaComum01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNoticiaComum01.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoticiaComum01.Location = new System.Drawing.Point(160, 78);
            this.lblNoticiaComum01.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoticiaComum01.Name = "lblNoticiaComum01";
            this.lblNoticiaComum01.Size = new System.Drawing.Size(122, 25);
            this.lblNoticiaComum01.TabIndex = 80;
            this.lblNoticiaComum01.Text = "Título da notícia";
            // 
            // pctBoxNoticiaComum02
            // 
            this.pctBoxNoticiaComum02.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxNoticiaComum02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxNoticiaComum02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBoxNoticiaComum02.Location = new System.Drawing.Point(299, 37);
            this.pctBoxNoticiaComum02.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxNoticiaComum02.Name = "pctBoxNoticiaComum02";
            this.pctBoxNoticiaComum02.Size = new System.Drawing.Size(112, 111);
            this.pctBoxNoticiaComum02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxNoticiaComum02.TabIndex = 79;
            this.pctBoxNoticiaComum02.TabStop = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.btnCadastrar.Location = new System.Drawing.Point(473, 519);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(289, 40);
            this.btnCadastrar.TabIndex = 79;
            this.btnCadastrar.Text = "Descartar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(189, 519);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(280, 40);
            this.btnEntrar.TabIndex = 78;
            this.btnEntrar.Text = "Salvar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            // 
            // JanelaNoticiasAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::NewsletterBlob.Properties.Resources.Cadastro__1_;
            this.ClientSize = new System.Drawing.Size(946, 598);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.pnlNoticiasAutor);
            this.Controls.Add(this.lblSuasPublicacoes);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.pctBoxPerfil);
            this.Controls.Add(this.pctBoxArrowBack);
            this.Controls.Add(this.lblCadastraNoticia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "JanelaNoticiasAutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blob News";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArrowBack)).EndInit();
            this.pnlNoticiasAutor.ResumeLayout(false);
            this.pnlNoticiasAutor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxNoticiaComum01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxNoticiaComum02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxPerfil;
        private System.Windows.Forms.PictureBox pctBoxArrowBack;
        private System.Windows.Forms.Label lblCadastraNoticia;
        private System.Windows.Forms.Label lblSuasPublicacoes;
        private System.Windows.Forms.Panel pnlNoticiasAutor;
        private System.Windows.Forms.Label lblNoticiacomum02;
        private System.Windows.Forms.PictureBox pctBoxNoticiaComum01;
        private System.Windows.Forms.Label lblNoticiaComum01;
        private System.Windows.Forms.PictureBox pctBoxNoticiaComum02;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnEntrar;
    }
}