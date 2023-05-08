namespace NewsletterBlob.View
{
    partial class JanelaCadastrarNoticias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaCadastrarNoticias));
            this.pctBoxPerfil = new System.Windows.Forms.PictureBox();
            this.pctBoxArrowBack = new System.Windows.Forms.PictureBox();
            this.lblCadastraNoticia = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBoxTitulo = new System.Windows.Forms.TextBox();
            this.txtBoxSubTitulo = new System.Windows.Forms.TextBox();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.txtBoxAutor = new System.Windows.Forms.TextBox();
            this.lblAutor = new System.Windows.Forms.Label();
            this.dtTmPckrData = new System.Windows.Forms.DateTimePicker();
            this.lblImagem = new System.Windows.Forms.Label();
            this.txtBoxConteudo = new System.Windows.Forms.TextBox();
            this.lblConteudo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnCarregarImagem = new System.Windows.Forms.Button();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.cmbBoxCategoria = new System.Windows.Forms.ComboBox();
            this.pctBoxAlertaTitulo = new System.Windows.Forms.PictureBox();
            this.pctBoxAlertaAutor = new System.Windows.Forms.PictureBox();
            this.pctBoxAlertaSubTitulo = new System.Windows.Forms.PictureBox();
            this.pctBoxAlertaConteudo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArrowBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaSubTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaConteudo)).BeginInit();
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
            this.pctBoxPerfil.TabIndex = 72;
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
            this.pctBoxArrowBack.TabIndex = 71;
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
            this.lblCadastraNoticia.Size = new System.Drawing.Size(261, 48);
            this.lblCadastraNoticia.TabIndex = 70;
            this.lblCadastraNoticia.Text = "Criar publicação";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblTitulo.Location = new System.Drawing.Point(178, 135);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 25);
            this.lblTitulo.TabIndex = 73;
            this.lblTitulo.Text = "Título:";
            // 
            // txtBoxTitulo
            // 
            this.txtBoxTitulo.Location = new System.Drawing.Point(182, 162);
            this.txtBoxTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxTitulo.Name = "txtBoxTitulo";
            this.txtBoxTitulo.Size = new System.Drawing.Size(282, 20);
            this.txtBoxTitulo.TabIndex = 74;
            // 
            // txtBoxSubTitulo
            // 
            this.txtBoxSubTitulo.Location = new System.Drawing.Point(488, 162);
            this.txtBoxSubTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxSubTitulo.Name = "txtBoxSubTitulo";
            this.txtBoxSubTitulo.Size = new System.Drawing.Size(282, 20);
            this.txtBoxSubTitulo.TabIndex = 76;
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(484, 135);
            this.lblSubTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(86, 25);
            this.lblSubTitulo.TabIndex = 75;
            this.lblSubTitulo.Text = "Sub-Título:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblData.Location = new System.Drawing.Point(484, 216);
            this.lblData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(48, 25);
            this.lblData.TabIndex = 79;
            this.lblData.Text = "Data:";
            // 
            // txtBoxAutor
            // 
            this.txtBoxAutor.Location = new System.Drawing.Point(182, 243);
            this.txtBoxAutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxAutor.Name = "txtBoxAutor";
            this.txtBoxAutor.Size = new System.Drawing.Size(282, 20);
            this.txtBoxAutor.TabIndex = 78;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblAutor.Location = new System.Drawing.Point(178, 216);
            this.lblAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(52, 25);
            this.lblAutor.TabIndex = 77;
            this.lblAutor.Text = "Autor:";
            // 
            // dtTmPckrData
            // 
            this.dtTmPckrData.Location = new System.Drawing.Point(488, 243);
            this.dtTmPckrData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtTmPckrData.Name = "dtTmPckrData";
            this.dtTmPckrData.Size = new System.Drawing.Size(282, 20);
            this.dtTmPckrData.TabIndex = 80;
            // 
            // lblImagem
            // 
            this.lblImagem.AutoSize = true;
            this.lblImagem.BackColor = System.Drawing.Color.Transparent;
            this.lblImagem.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblImagem.Location = new System.Drawing.Point(178, 294);
            this.lblImagem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagem.Name = "lblImagem";
            this.lblImagem.Size = new System.Drawing.Size(73, 25);
            this.lblImagem.TabIndex = 83;
            this.lblImagem.Text = "Imagem:";
            // 
            // txtBoxConteudo
            // 
            this.txtBoxConteudo.Location = new System.Drawing.Point(488, 321);
            this.txtBoxConteudo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxConteudo.Multiline = true;
            this.txtBoxConteudo.Name = "txtBoxConteudo";
            this.txtBoxConteudo.Size = new System.Drawing.Size(282, 142);
            this.txtBoxConteudo.TabIndex = 82;
            // 
            // lblConteudo
            // 
            this.lblConteudo.AutoSize = true;
            this.lblConteudo.BackColor = System.Drawing.Color.Transparent;
            this.lblConteudo.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConteudo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblConteudo.Location = new System.Drawing.Point(484, 294);
            this.lblConteudo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConteudo.Name = "lblConteudo";
            this.lblConteudo.Size = new System.Drawing.Size(85, 25);
            this.lblConteudo.TabIndex = 81;
            this.lblConteudo.Text = "Conteúdo:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoria.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.lblCategoria.Location = new System.Drawing.Point(178, 382);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(84, 25);
            this.lblCategoria.TabIndex = 84;
            this.lblCategoria.Text = "Categoria:";
            // 
            // btnCarregarImagem
            // 
            this.btnCarregarImagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.btnCarregarImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarregarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarImagem.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarImagem.ForeColor = System.Drawing.Color.White;
            this.btnCarregarImagem.Location = new System.Drawing.Point(182, 321);
            this.btnCarregarImagem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCarregarImagem.Name = "btnCarregarImagem";
            this.btnCarregarImagem.Size = new System.Drawing.Size(281, 29);
            this.btnCarregarImagem.TabIndex = 85;
            this.btnCarregarImagem.Text = "Carregar imagem";
            this.btnCarregarImagem.UseVisualStyleBackColor = false;
            this.btnCarregarImagem.Click += new System.EventHandler(this.btnCarregarImagem_Click);
            // 
            // btnPublicar
            // 
            this.btnPublicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.btnPublicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicar.ForeColor = System.Drawing.Color.White;
            this.btnPublicar.Location = new System.Drawing.Point(327, 502);
            this.btnPublicar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(266, 40);
            this.btnPublicar.TabIndex = 86;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = false;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // cmbBoxCategoria
            // 
            this.cmbBoxCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbBoxCategoria.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxCategoria.FormattingEnabled = true;
            this.cmbBoxCategoria.Items.AddRange(new object[] {
            "Tecnologia",
            "Esporte",
            "Entretenimento",
            "Política"});
            this.cmbBoxCategoria.Location = new System.Drawing.Point(182, 409);
            this.cmbBoxCategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbBoxCategoria.Name = "cmbBoxCategoria";
            this.cmbBoxCategoria.Size = new System.Drawing.Size(282, 30);
            this.cmbBoxCategoria.TabIndex = 87;
            // 
            // pctBoxAlertaTitulo
            // 
            this.pctBoxAlertaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxAlertaTitulo.Image = global::NewsletterBlob.Properties.Resources.Vector__5_;
            this.pctBoxAlertaTitulo.Location = new System.Drawing.Point(163, 162);
            this.pctBoxAlertaTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxAlertaTitulo.Name = "pctBoxAlertaTitulo";
            this.pctBoxAlertaTitulo.Size = new System.Drawing.Size(15, 16);
            this.pctBoxAlertaTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxAlertaTitulo.TabIndex = 88;
            this.pctBoxAlertaTitulo.TabStop = false;
            this.pctBoxAlertaTitulo.Visible = false;
            // 
            // pctBoxAlertaAutor
            // 
            this.pctBoxAlertaAutor.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxAlertaAutor.Image = global::NewsletterBlob.Properties.Resources.Vector__5_;
            this.pctBoxAlertaAutor.Location = new System.Drawing.Point(163, 243);
            this.pctBoxAlertaAutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxAlertaAutor.Name = "pctBoxAlertaAutor";
            this.pctBoxAlertaAutor.Size = new System.Drawing.Size(15, 16);
            this.pctBoxAlertaAutor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxAlertaAutor.TabIndex = 89;
            this.pctBoxAlertaAutor.TabStop = false;
            this.pctBoxAlertaAutor.Visible = false;
            // 
            // pctBoxAlertaSubTitulo
            // 
            this.pctBoxAlertaSubTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxAlertaSubTitulo.Image = global::NewsletterBlob.Properties.Resources.Vector__5_;
            this.pctBoxAlertaSubTitulo.Location = new System.Drawing.Point(774, 162);
            this.pctBoxAlertaSubTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxAlertaSubTitulo.Name = "pctBoxAlertaSubTitulo";
            this.pctBoxAlertaSubTitulo.Size = new System.Drawing.Size(15, 16);
            this.pctBoxAlertaSubTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxAlertaSubTitulo.TabIndex = 90;
            this.pctBoxAlertaSubTitulo.TabStop = false;
            this.pctBoxAlertaSubTitulo.Visible = false;
            // 
            // pctBoxAlertaConteudo
            // 
            this.pctBoxAlertaConteudo.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxAlertaConteudo.Image = global::NewsletterBlob.Properties.Resources.Vector__5_;
            this.pctBoxAlertaConteudo.Location = new System.Drawing.Point(774, 321);
            this.pctBoxAlertaConteudo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctBoxAlertaConteudo.Name = "pctBoxAlertaConteudo";
            this.pctBoxAlertaConteudo.Size = new System.Drawing.Size(15, 16);
            this.pctBoxAlertaConteudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxAlertaConteudo.TabIndex = 91;
            this.pctBoxAlertaConteudo.TabStop = false;
            this.pctBoxAlertaConteudo.Visible = false;
            // 
            // JanelaCadastrarNoticias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::NewsletterBlob.Properties.Resources.Cadastro__1_;
            this.ClientSize = new System.Drawing.Size(946, 569);
            this.Controls.Add(this.pctBoxAlertaConteudo);
            this.Controls.Add(this.pctBoxAlertaSubTitulo);
            this.Controls.Add(this.pctBoxAlertaAutor);
            this.Controls.Add(this.pctBoxAlertaTitulo);
            this.Controls.Add(this.cmbBoxCategoria);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.btnCarregarImagem);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.txtBoxConteudo);
            this.Controls.Add(this.lblConteudo);
            this.Controls.Add(this.dtTmPckrData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txtBoxAutor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.txtBoxSubTitulo);
            this.Controls.Add(this.lblSubTitulo);
            this.Controls.Add(this.txtBoxTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pctBoxPerfil);
            this.Controls.Add(this.pctBoxArrowBack);
            this.Controls.Add(this.lblCadastraNoticia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "JanelaCadastrarNoticias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blob News";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArrowBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaSubTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlertaConteudo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxPerfil;
        private System.Windows.Forms.PictureBox pctBoxArrowBack;
        private System.Windows.Forms.Label lblCadastraNoticia;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBoxTitulo;
        private System.Windows.Forms.TextBox txtBoxSubTitulo;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtBoxAutor;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.DateTimePicker dtTmPckrData;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.TextBox txtBoxConteudo;
        private System.Windows.Forms.Label lblConteudo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnCarregarImagem;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.ComboBox cmbBoxCategoria;
        private System.Windows.Forms.PictureBox pctBoxAlertaTitulo;
        private System.Windows.Forms.PictureBox pctBoxAlertaAutor;
        private System.Windows.Forms.PictureBox pctBoxAlertaSubTitulo;
        private System.Windows.Forms.PictureBox pctBoxAlertaConteudo;
    }
}