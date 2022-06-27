namespace Financial.Forms
{
    partial class frmLocaisNovo
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
            this.lblLocal = new System.Windows.Forms.Label();
            this.txtIdLocal = new System.Windows.Forms.TextBox();
            this.txtNameLocal = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValorLocal = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(12, 9);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(33, 13);
            this.lblLocal.TabIndex = 0;
            this.lblLocal.Text = "Local";
            // 
            // txtIdLocal
            // 
            this.txtIdLocal.Location = new System.Drawing.Point(12, 25);
            this.txtIdLocal.Name = "txtIdLocal";
            this.txtIdLocal.Size = new System.Drawing.Size(51, 20);
            this.txtIdLocal.TabIndex = 1;
            // 
            // txtNameLocal
            // 
            this.txtNameLocal.Location = new System.Drawing.Point(69, 25);
            this.txtNameLocal.Name = "txtNameLocal";
            this.txtNameLocal.Size = new System.Drawing.Size(202, 20);
            this.txtNameLocal.TabIndex = 3;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 48);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(54, 13);
            this.lblValor.TabIndex = 4;
            this.lblValor.Text = "Valor (R$)";
            // 
            // txtValorLocal
            // 
            this.txtValorLocal.Location = new System.Drawing.Point(12, 62);
            this.txtValorLocal.Name = "txtValorLocal";
            this.txtValorLocal.Size = new System.Drawing.Size(109, 20);
            this.txtValorLocal.TabIndex = 5;
            //this.txtValorLocal.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorLocal_Validating);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 101);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(259, 69);
            this.txtObservacao.TabIndex = 7;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(12, 85);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(65, 13);
            this.lblObservacao.TabIndex = 6;
            this.lblObservacao.Text = "Observação";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(196, 176);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 27);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(115, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmLocaisNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 211);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txtValorLocal);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtNameLocal);
            this.Controls.Add(this.txtIdLocal);
            this.Controls.Add(this.lblLocal);
            this.Name = "frmLocaisNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Local";
            this.Load += new System.EventHandler(this.frmLocaisNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.TextBox txtIdLocal;
        private System.Windows.Forms.TextBox txtNameLocal;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValorLocal;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}