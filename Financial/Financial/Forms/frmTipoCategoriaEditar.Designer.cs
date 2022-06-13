namespace Financial.Forms
{
    partial class frmTipoCategoriaEditar
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
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTipoCategoria
            // 
            this.lblTipoCategoria.AutoSize = true;
            this.lblTipoCategoria.Location = new System.Drawing.Point(7, 9);
            this.lblTipoCategoria.Name = "lblTipoCategoria";
            this.lblTipoCategoria.Size = new System.Drawing.Size(91, 13);
            this.lblTipoCategoria.TabIndex = 26;
            this.lblTipoCategoria.Text = "Tipo da Categoria";
            // 
            // txtCodTipoCategoria
            // 
            this.txtCodTipoCategoria.Location = new System.Drawing.Point(10, 25);
            this.txtCodTipoCategoria.Name = "txtCodTipoCategoria";
            this.txtCodTipoCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodTipoCategoria.TabIndex = 25;
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(57, 25);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(231, 20);
            this.txtDescCategoria.TabIndex = 24;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(213, 51);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 27);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(51, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(132, 51);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 27);
            this.btnDeletar.TabIndex = 27;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // frmTipoCategoriaEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 88);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.lblTipoCategoria);
            this.Controls.Add(this.txtCodTipoCategoria);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmTipoCategoriaEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Tipo Categoria";
            this.Load += new System.EventHandler(this.frmTipoCategoriaEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoCategoria;
        private System.Windows.Forms.TextBox txtCodTipoCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDeletar;
    }
}