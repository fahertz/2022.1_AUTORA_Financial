namespace Financial.Forms
{
    partial class frmCadastros
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
            this.gpbCategorizacao = new System.Windows.Forms.GroupBox();
            this.btnTipoCategoria = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbEntidades = new System.Windows.Forms.GroupBox();
            this.btnClassificacoes = new System.Windows.Forms.Button();
            this.btnEntidades = new System.Windows.Forms.Button();
            this.gpbCategorizacao.SuspendLayout();
            this.gpbEntidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCategorizacao
            // 
            this.gpbCategorizacao.Controls.Add(this.btnTipoCategoria);
            this.gpbCategorizacao.Controls.Add(this.btnCategoria);
            this.gpbCategorizacao.Location = new System.Drawing.Point(12, 12);
            this.gpbCategorizacao.Name = "gpbCategorizacao";
            this.gpbCategorizacao.Size = new System.Drawing.Size(249, 110);
            this.gpbCategorizacao.TabIndex = 0;
            this.gpbCategorizacao.TabStop = false;
            this.gpbCategorizacao.Text = "Categorização";
            // 
            // btnTipoCategoria
            // 
            this.btnTipoCategoria.Location = new System.Drawing.Point(6, 63);
            this.btnTipoCategoria.Name = "btnTipoCategoria";
            this.btnTipoCategoria.Size = new System.Drawing.Size(102, 38);
            this.btnTipoCategoria.TabIndex = 1;
            this.btnTipoCategoria.Text = "Tipo Categoria";
            this.btnTipoCategoria.UseVisualStyleBackColor = true;
            this.btnTipoCategoria.Click += new System.EventHandler(this.btnTipoCategoria_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(6, 19);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(102, 38);
            this.btnCategoria.TabIndex = 0;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(713, 411);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 27);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // gpbEntidades
            // 
            this.gpbEntidades.Controls.Add(this.btnClassificacoes);
            this.gpbEntidades.Controls.Add(this.btnEntidades);
            this.gpbEntidades.Location = new System.Drawing.Point(12, 128);
            this.gpbEntidades.Name = "gpbEntidades";
            this.gpbEntidades.Size = new System.Drawing.Size(249, 110);
            this.gpbEntidades.TabIndex = 2;
            this.gpbEntidades.TabStop = false;
            this.gpbEntidades.Text = "Entidades";
            // 
            // btnClassificacoes
            // 
            this.btnClassificacoes.Location = new System.Drawing.Point(6, 63);
            this.btnClassificacoes.Name = "btnClassificacoes";
            this.btnClassificacoes.Size = new System.Drawing.Size(102, 38);
            this.btnClassificacoes.TabIndex = 1;
            this.btnClassificacoes.Text = "Classificações";
            this.btnClassificacoes.UseVisualStyleBackColor = true;
            this.btnClassificacoes.Click += new System.EventHandler(this.btnClassificacoes_Click);
            // 
            // btnEntidades
            // 
            this.btnEntidades.Location = new System.Drawing.Point(6, 19);
            this.btnEntidades.Name = "btnEntidades";
            this.btnEntidades.Size = new System.Drawing.Size(102, 38);
            this.btnEntidades.TabIndex = 0;
            this.btnEntidades.Text = "Entidades";
            this.btnEntidades.UseVisualStyleBackColor = true;
            this.btnEntidades.Click += new System.EventHandler(this.btnEntidades_Click);
            // 
            // frmCadastros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpbEntidades);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbCategorizacao);
            this.Name = "frmCadastros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastros";
            this.Load += new System.EventHandler(this.frmCadastros_Load);
            this.gpbCategorizacao.ResumeLayout(false);
            this.gpbEntidades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCategorizacao;
        private System.Windows.Forms.Button btnTipoCategoria;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox gpbEntidades;
        private System.Windows.Forms.Button btnClassificacoes;
        private System.Windows.Forms.Button btnEntidades;
    }
}