namespace Financial.Forms
{
    partial class frmEntradasNovo
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
            this.txtDescDevedor = new System.Windows.Forms.TextBox();
            this.txtCodDevedor = new System.Windows.Forms.TextBox();
            this.dtpDataBase = new System.Windows.Forms.DateTimePicker();
            this.cbxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.txtDescLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.txtCodLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDevedor = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.chkDiasUteis = new System.Windows.Forms.CheckBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.lblLocalArmazenamento = new System.Windows.Forms.Label();
            this.chkBaixaAutomatica = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtDescDevedor
            // 
            this.txtDescDevedor.Location = new System.Drawing.Point(62, 24);
            this.txtDescDevedor.Name = "txtDescDevedor";
            this.txtDescDevedor.Size = new System.Drawing.Size(367, 20);
            this.txtDescDevedor.TabIndex = 0;
            // 
            // txtCodDevedor
            // 
            this.txtCodDevedor.Location = new System.Drawing.Point(12, 24);
            this.txtCodDevedor.Name = "txtCodDevedor";
            this.txtCodDevedor.Size = new System.Drawing.Size(44, 20);
            this.txtCodDevedor.TabIndex = 1;
            // 
            // dtpDataBase
            // 
            this.dtpDataBase.Location = new System.Drawing.Point(12, 63);
            this.dtpDataBase.Name = "dtpDataBase";
            this.dtpDataBase.Size = new System.Drawing.Size(230, 20);
            this.dtpDataBase.TabIndex = 2;
            // 
            // cbxFormaPagamento
            // 
            this.cbxFormaPagamento.FormattingEnabled = true;
            this.cbxFormaPagamento.Location = new System.Drawing.Point(12, 102);
            this.cbxFormaPagamento.Name = "cbxFormaPagamento";
            this.cbxFormaPagamento.Size = new System.Drawing.Size(230, 21);
            this.cbxFormaPagamento.TabIndex = 3;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 182);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(776, 138);
            this.txtObservacao.TabIndex = 6;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(438, 24);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodCategoria.TabIndex = 8;
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(488, 24);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(300, 20);
            this.txtDescCategoria.TabIndex = 7;
            // 
            // txtDescLocalArmazenamento
            // 
            this.txtDescLocalArmazenamento.Location = new System.Drawing.Point(62, 142);
            this.txtDescLocalArmazenamento.Name = "txtDescLocalArmazenamento";
            this.txtDescLocalArmazenamento.Size = new System.Drawing.Size(235, 20);
            this.txtDescLocalArmazenamento.TabIndex = 9;
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(248, 102);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(52, 20);
            this.txtParcelas.TabIndex = 10;
            // 
            // txtCodLocalArmazenamento
            // 
            this.txtCodLocalArmazenamento.Location = new System.Drawing.Point(12, 142);
            this.txtCodLocalArmazenamento.Name = "txtCodLocalArmazenamento";
            this.txtCodLocalArmazenamento.Size = new System.Drawing.Size(44, 20);
            this.txtCodLocalArmazenamento.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Observação";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(713, 326);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 30);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(632, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblDevedor
            // 
            this.lblDevedor.AutoSize = true;
            this.lblDevedor.Location = new System.Drawing.Point(12, 8);
            this.lblDevedor.Name = "lblDevedor";
            this.lblDevedor.Size = new System.Drawing.Size(48, 13);
            this.lblDevedor.TabIndex = 15;
            this.lblDevedor.Text = "Devedor";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(435, 9);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 16;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(9, 47);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(57, 13);
            this.lblDataBase.TabIndex = 17;
            this.lblDataBase.Text = "Data Base";
            // 
            // chkDiasUteis
            // 
            this.chkDiasUteis.AutoSize = true;
            this.chkDiasUteis.Location = new System.Drawing.Point(248, 65);
            this.chkDiasUteis.Name = "chkDiasUteis";
            this.chkDiasUteis.Size = new System.Drawing.Size(109, 17);
            this.chkDiasUteis.TabIndex = 18;
            this.chkDiasUteis.Text = "Apenas dias úteis";
            this.chkDiasUteis.UseVisualStyleBackColor = true;
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(9, 86);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(108, 13);
            this.lblFormaPagamento.TabIndex = 19;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(249, 86);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(48, 13);
            this.lblParcelas.TabIndex = 20;
            this.lblParcelas.Text = "Parcelas";
            // 
            // lblLocalArmazenamento
            // 
            this.lblLocalArmazenamento.AutoSize = true;
            this.lblLocalArmazenamento.Location = new System.Drawing.Point(12, 126);
            this.lblLocalArmazenamento.Name = "lblLocalArmazenamento";
            this.lblLocalArmazenamento.Size = new System.Drawing.Size(111, 13);
            this.lblLocalArmazenamento.TabIndex = 21;
            this.lblLocalArmazenamento.Text = "Local armazenamento";
            // 
            // chkBaixaAutomatica
            // 
            this.chkBaixaAutomatica.AutoSize = true;
            this.chkBaixaAutomatica.Location = new System.Drawing.Point(681, 159);
            this.chkBaixaAutomatica.Name = "chkBaixaAutomatica";
            this.chkBaixaAutomatica.Size = new System.Drawing.Size(107, 17);
            this.chkBaixaAutomatica.TabIndex = 22;
            this.chkBaixaAutomatica.Text = "Baixa automática";
            this.chkBaixaAutomatica.UseVisualStyleBackColor = true;
            // 
            // frmEntradasNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.chkBaixaAutomatica);
            this.Controls.Add(this.lblLocalArmazenamento);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.chkDiasUteis);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblDevedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodLocalArmazenamento);
            this.Controls.Add(this.txtParcelas);
            this.Controls.Add(this.txtDescLocalArmazenamento);
            this.Controls.Add(this.txtCodCategoria);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.cbxFormaPagamento);
            this.Controls.Add(this.dtpDataBase);
            this.Controls.Add(this.txtCodDevedor);
            this.Controls.Add(this.txtDescDevedor);
            this.Name = "frmEntradasNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova entrada";
            this.Load += new System.EventHandler(this.frmEntradasNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescDevedor;
        private System.Windows.Forms.TextBox txtCodDevedor;
        private System.Windows.Forms.DateTimePicker dtpDataBase;
        private System.Windows.Forms.ComboBox cbxFormaPagamento;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
        private System.Windows.Forms.TextBox txtDescLocalArmazenamento;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.TextBox txtCodLocalArmazenamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDevedor;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.CheckBox chkDiasUteis;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.Label lblLocalArmazenamento;
        private System.Windows.Forms.CheckBox chkBaixaAutomatica;
    }
}