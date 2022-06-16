namespace Financial
{
    partial class frmFinancial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnSaidas = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnCadastros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEntradas
            // 
            this.btnEntradas.Location = new System.Drawing.Point(12, 27);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(249, 69);
            this.btnEntradas.TabIndex = 0;
            this.btnEntradas.Text = "Entradas";
            this.btnEntradas.UseVisualStyleBackColor = true;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // btnSaidas
            // 
            this.btnSaidas.Location = new System.Drawing.Point(12, 102);
            this.btnSaidas.Name = "btnSaidas";
            this.btnSaidas.Size = new System.Drawing.Size(249, 69);
            this.btnSaidas.TabIndex = 1;
            this.btnSaidas.Text = "Saídas";
            this.btnSaidas.UseVisualStyleBackColor = true;
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Location = new System.Drawing.Point(12, 177);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(249, 69);
            this.btnRelatorios.TabIndex = 2;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(714, 407);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(74, 31);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(714, 12);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(74, 31);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnCadastros
            // 
            this.btnCadastros.Location = new System.Drawing.Point(12, 252);
            this.btnCadastros.Name = "btnCadastros";
            this.btnCadastros.Size = new System.Drawing.Size(249, 69);
            this.btnCadastros.TabIndex = 5;
            this.btnCadastros.Text = "Cadastros";
            this.btnCadastros.UseVisualStyleBackColor = true;
            this.btnCadastros.Click += new System.EventHandler(this.btnCadastros_Click);
            // 
            // frmFinancial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCadastros);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnRelatorios);
            this.Controls.Add(this.btnSaidas);
            this.Controls.Add(this.btnEntradas);
            this.Name = "frmFinancial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial";
            this.Load += new System.EventHandler(this.frmFinancial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSaidas;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnCadastros;
    }
}

