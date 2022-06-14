namespace Financial.Forms
{
    partial class frmCategoriaNovo
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
            this.lblTipoCategoria = new System.Windows.Forms.Label();
            this.txtCodTipoCategoria = new System.Windows.Forms.TextBox();
            this.txtDescTipoCategoria = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTipoCategoria
            // 
            this.lblTipoCategoria.AutoSize = true;
            this.lblTipoCategoria.Location = new System.Drawing.Point(5, 47);
            this.lblTipoCategoria.Name = "lblTipoCategoria";
            this.lblTipoCategoria.Size = new System.Drawing.Size(91, 13);
            this.lblTipoCategoria.TabIndex = 26;
            this.lblTipoCategoria.Text = "Tipo da Categoria";
            // 
            // txtCodTipoCategoria
            // 
            this.txtCodTipoCategoria.Location = new System.Drawing.Point(8, 63);
            this.txtCodTipoCategoria.Name = "txtCodTipoCategoria";
            this.txtCodTipoCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodTipoCategoria.TabIndex = 25;
            this.txtCodTipoCategoria.TextChanged += new System.EventHandler(this.txtCodTipoCategoria_TextChanged);
            // 
            // txtDescTipoCategoria
            // 
            this.txtDescTipoCategoria.Location = new System.Drawing.Point(55, 63);
            this.txtDescTipoCategoria.Name = "txtDescTipoCategoria";
            this.txtDescTipoCategoria.Size = new System.Drawing.Size(231, 20);
            this.txtDescTipoCategoria.TabIndex = 24;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(211, 89);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 27);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(130, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(5, 5);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 29;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(8, 21);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodCategoria.TabIndex = 28;
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(55, 21);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(231, 20);
            this.txtDescCategoria.TabIndex = 27;
            // 
            // frmCategoriaNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 128);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCodCategoria);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.lblTipoCategoria);
            this.Controls.Add(this.txtCodTipoCategoria);
            this.Controls.Add(this.txtDescTipoCategoria);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmCategoriaNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar nova categoria";
            this.Load += new System.EventHandler(this.frmCategoriaNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoCategoria;
        private System.Windows.Forms.TextBox txtCodTipoCategoria;
        private System.Windows.Forms.TextBox txtDescTipoCategoria;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
    }
}