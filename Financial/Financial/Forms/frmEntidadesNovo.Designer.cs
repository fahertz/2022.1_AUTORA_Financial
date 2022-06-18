namespace Financial.Forms
{
    partial class frmEntidadesNovo
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
            this.lblEntidade = new System.Windows.Forms.Label();
            this.txtCodEntidade = new System.Windows.Forms.TextBox();
            this.txtDescEntidade = new System.Windows.Forms.TextBox();
            this.lblClassificacaoEntidade = new System.Windows.Forms.Label();
            this.txtCodClassificacao = new System.Windows.Forms.TextBox();
            this.txtDescClassificacao = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEntidade
            // 
            this.lblEntidade.AutoSize = true;
            this.lblEntidade.Location = new System.Drawing.Point(7, 6);
            this.lblEntidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntidade.Name = "lblEntidade";
            this.lblEntidade.Size = new System.Drawing.Size(61, 16);
            this.lblEntidade.TabIndex = 37;
            this.lblEntidade.Text = "Entidade";
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Location = new System.Drawing.Point(11, 26);
            this.txtCodEntidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Size = new System.Drawing.Size(57, 22);
            this.txtCodEntidade.TabIndex = 36;
            // 
            // txtDescEntidade
            // 
            this.txtDescEntidade.Location = new System.Drawing.Point(73, 26);
            this.txtDescEntidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescEntidade.Name = "txtDescEntidade";
            this.txtDescEntidade.Size = new System.Drawing.Size(307, 22);
            this.txtDescEntidade.TabIndex = 35;
            // 
            // lblClassificacaoEntidade
            // 
            this.lblClassificacaoEntidade.AutoSize = true;
            this.lblClassificacaoEntidade.Location = new System.Drawing.Point(7, 58);
            this.lblClassificacaoEntidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassificacaoEntidade.Name = "lblClassificacaoEntidade";
            this.lblClassificacaoEntidade.Size = new System.Drawing.Size(164, 16);
            this.lblClassificacaoEntidade.TabIndex = 34;
            this.lblClassificacaoEntidade.Text = "Classificação da Entidade";
            // 
            // txtCodClassificacao
            // 
            this.txtCodClassificacao.Location = new System.Drawing.Point(11, 78);
            this.txtCodClassificacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodClassificacao.Name = "txtCodClassificacao";
            this.txtCodClassificacao.Size = new System.Drawing.Size(57, 22);
            this.txtCodClassificacao.TabIndex = 33;
            // 
            // txtDescClassificacao
            // 
            this.txtDescClassificacao.Location = new System.Drawing.Point(73, 78);
            this.txtDescClassificacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescClassificacao.Name = "txtDescClassificacao";
            this.txtDescClassificacao.Size = new System.Drawing.Size(307, 22);
            this.txtDescClassificacao.TabIndex = 32;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(281, 110);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 33);
            this.btnSalvar.TabIndex = 31;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(173, 110);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 33);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEntidadesNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 152);
            this.Controls.Add(this.lblEntidade);
            this.Controls.Add(this.txtCodEntidade);
            this.Controls.Add(this.txtDescEntidade);
            this.Controls.Add(this.lblClassificacaoEntidade);
            this.Controls.Add(this.txtCodClassificacao);
            this.Controls.Add(this.txtDescClassificacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmEntidadesNovo";
            this.Text = "Nova Entidade";
            this.Load += new System.EventHandler(this.frmEntidadesNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntidade;
        private System.Windows.Forms.TextBox txtCodEntidade;
        private System.Windows.Forms.TextBox txtDescEntidade;
        private System.Windows.Forms.Label lblClassificacaoEntidade;
        private System.Windows.Forms.TextBox txtCodClassificacao;
        private System.Windows.Forms.TextBox txtDescClassificacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}