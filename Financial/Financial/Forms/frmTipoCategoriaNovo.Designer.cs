namespace Financial.Forms
{
    partial class frmTipoCategoriaNovo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblTipoCategoria = new System.Windows.Forms.Label();
            this.txtCodTipoCategoria = new System.Windows.Forms.TextBox();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(131, 50);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(212, 50);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 27);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblTipoCategoria
            // 
            this.lblTipoCategoria.AutoSize = true;
            this.lblTipoCategoria.Location = new System.Drawing.Point(6, 8);
            this.lblTipoCategoria.Name = "lblTipoCategoria";
            this.lblTipoCategoria.Size = new System.Drawing.Size(91, 13);
            this.lblTipoCategoria.TabIndex = 21;
            this.lblTipoCategoria.Text = "Tipo da Categoria";
            // 
            // txtCodTipoCategoria
            // 
            this.txtCodTipoCategoria.Location = new System.Drawing.Point(9, 24);
            this.txtCodTipoCategoria.Name = "txtCodTipoCategoria";
            this.txtCodTipoCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodTipoCategoria.TabIndex = 20;
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(56, 24);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(231, 20);
            this.txtDescCategoria.TabIndex = 19;
            // 
            // frmTipoCategoriaNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 92);
            this.Controls.Add(this.lblTipoCategoria);
            this.Controls.Add(this.txtCodTipoCategoria);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmTipoCategoriaNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo tipo de categoria";
            this.Load += new System.EventHandler(this.frmTipoCategoriaNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblTipoCategoria;
        private System.Windows.Forms.TextBox txtCodTipoCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
    }
}