namespace Financial.Forms
{
    partial class frmSaidasNovo
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
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnEntidades = new System.Windows.Forms.Button();
            this.chkBaixaAutomatica = new System.Windows.Forms.CheckBox();
            this.lblLocalArmazenamento = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.chkDiasUteis = new System.Windows.Forms.CheckBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblEntidade = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtCodLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.txtDescLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.cbxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.dtpDataBase = new System.Windows.Forms.DateTimePicker();
            this.txtCodEntidade = new System.Windows.Forms.TextBox();
            this.txtDescEntidade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(4, 105);
            this.lblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(39, 16);
            this.lblValor.TabIndex = 49;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(4, 125);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(103, 22);
            this.txtValor.TabIndex = 29;
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(1148, 169);
            this.btnLocal.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(89, 37);
            this.btnLocal.TabIndex = 44;
            this.btnLocal.Text = "Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(1148, 125);
            this.btnCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(89, 37);
            this.btnCategoria.TabIndex = 42;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnEntidades
            // 
            this.btnEntidades.Location = new System.Drawing.Point(1148, 84);
            this.btnEntidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntidades.Name = "btnEntidades";
            this.btnEntidades.Size = new System.Drawing.Size(89, 37);
            this.btnEntidades.TabIndex = 41;
            this.btnEntidades.Text = "Entidades";
            this.btnEntidades.UseVisualStyleBackColor = true;
            this.btnEntidades.Click += new System.EventHandler(this.btnEntidades_Click);
            // 
            // chkBaixaAutomatica
            // 
            this.chkBaixaAutomatica.AutoSize = true;
            this.chkBaixaAutomatica.Location = new System.Drawing.Point(472, 77);
            this.chkBaixaAutomatica.Margin = new System.Windows.Forms.Padding(4);
            this.chkBaixaAutomatica.Name = "chkBaixaAutomatica";
            this.chkBaixaAutomatica.Size = new System.Drawing.Size(132, 20);
            this.chkBaixaAutomatica.TabIndex = 36;
            this.chkBaixaAutomatica.Text = "Baixa automática";
            this.chkBaixaAutomatica.UseVisualStyleBackColor = true;
            this.chkBaixaAutomatica.CheckedChanged += new System.EventHandler(this.chkBaixaAutomatica_CheckedChanged);
            // 
            // lblLocalArmazenamento
            // 
            this.lblLocalArmazenamento.AutoSize = true;
            this.lblLocalArmazenamento.Location = new System.Drawing.Point(4, 154);
            this.lblLocalArmazenamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalArmazenamento.Name = "lblLocalArmazenamento";
            this.lblLocalArmazenamento.Size = new System.Drawing.Size(140, 16);
            this.lblLocalArmazenamento.TabIndex = 48;
            this.lblLocalArmazenamento.Text = "Local armazenamento";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(113, 105);
            this.lblParcelas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(61, 16);
            this.lblParcelas.TabIndex = 47;
            this.lblParcelas.Text = "Parcelas";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(185, 105);
            this.lblFormaPagamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(138, 16);
            this.lblFormaPagamento.TabIndex = 46;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // chkDiasUteis
            // 
            this.chkDiasUteis.AutoSize = true;
            this.chkDiasUteis.Location = new System.Drawing.Point(319, 79);
            this.chkDiasUteis.Margin = new System.Windows.Forms.Padding(4);
            this.chkDiasUteis.Name = "chkDiasUteis";
            this.chkDiasUteis.Size = new System.Drawing.Size(136, 20);
            this.chkDiasUteis.TabIndex = 35;
            this.chkDiasUteis.Text = "Apenas dias úteis";
            this.chkDiasUteis.UseVisualStyleBackColor = true;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(0, 57);
            this.lblDataBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(71, 16);
            this.lblDataBase.TabIndex = 45;
            this.lblDataBase.Text = "Data Base";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(648, 10);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(66, 16);
            this.lblCategoria.TabIndex = 43;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblEntidade
            // 
            this.lblEntidade.AutoSize = true;
            this.lblEntidade.Location = new System.Drawing.Point(4, 9);
            this.lblEntidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntidade.Name = "lblEntidade";
            this.lblEntidade.Size = new System.Drawing.Size(61, 16);
            this.lblEntidade.TabIndex = 34;
            this.lblEntidade.Text = "Entidade";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1029, 400);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 37);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(1137, 400);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 37);
            this.btnSalvar.TabIndex = 40;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(4, 203);
            this.lblObs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(82, 16);
            this.lblObs.TabIndex = 39;
            this.lblObs.Text = "Observação";
            // 
            // txtCodLocalArmazenamento
            // 
            this.txtCodLocalArmazenamento.Location = new System.Drawing.Point(4, 174);
            this.txtCodLocalArmazenamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodLocalArmazenamento.Name = "txtCodLocalArmazenamento";
            this.txtCodLocalArmazenamento.Size = new System.Drawing.Size(57, 22);
            this.txtCodLocalArmazenamento.TabIndex = 32;
            this.txtCodLocalArmazenamento.TextChanged += new System.EventHandler(this.txtCodLocalArmazenamento_TextChanged);
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(112, 125);
            this.txtParcelas.Margin = new System.Windows.Forms.Padding(4);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(68, 22);
            this.txtParcelas.TabIndex = 30;
            // 
            // txtDescLocalArmazenamento
            // 
            this.txtDescLocalArmazenamento.Location = new System.Drawing.Point(71, 174);
            this.txtDescLocalArmazenamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescLocalArmazenamento.Name = "txtDescLocalArmazenamento";
            this.txtDescLocalArmazenamento.Size = new System.Drawing.Size(312, 22);
            this.txtDescLocalArmazenamento.TabIndex = 33;
            this.txtDescLocalArmazenamento.TabStop = false;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(652, 29);
            this.txtCodCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(57, 22);
            this.txtCodCategoria.TabIndex = 26;
            this.txtCodCategoria.TextChanged += new System.EventHandler(this.txtCodCategoria_TextChanged);
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(719, 29);
            this.txtDescCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(409, 22);
            this.txtDescCategoria.TabIndex = 28;
            this.txtDescCategoria.TabStop = false;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(4, 223);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(1232, 169);
            this.txtObservacao.TabIndex = 37;
            // 
            // cbxFormaPagamento
            // 
            this.cbxFormaPagamento.FormattingEnabled = true;
            this.cbxFormaPagamento.ItemHeight = 16;
            this.cbxFormaPagamento.Location = new System.Drawing.Point(189, 125);
            this.cbxFormaPagamento.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFormaPagamento.Name = "cbxFormaPagamento";
            this.cbxFormaPagamento.Size = new System.Drawing.Size(305, 24);
            this.cbxFormaPagamento.TabIndex = 31;
            // 
            // dtpDataBase
            // 
            this.dtpDataBase.Location = new System.Drawing.Point(4, 77);
            this.dtpDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataBase.Name = "dtpDataBase";
            this.dtpDataBase.Size = new System.Drawing.Size(305, 22);
            this.dtpDataBase.TabIndex = 27;
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Location = new System.Drawing.Point(4, 29);
            this.txtCodEntidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Size = new System.Drawing.Size(57, 22);
            this.txtCodEntidade.TabIndex = 24;
            this.txtCodEntidade.TextChanged += new System.EventHandler(this.txtCodEntidade_TextChanged);
            // 
            // txtDescEntidade
            // 
            this.txtDescEntidade.Location = new System.Drawing.Point(71, 29);
            this.txtDescEntidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescEntidade.Name = "txtDescEntidade";
            this.txtDescEntidade.Size = new System.Drawing.Size(543, 22);
            this.txtDescEntidade.TabIndex = 25;
            this.txtDescEntidade.TabStop = false;
            // 
            // frmSaidasNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 445);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnEntidades);
            this.Controls.Add(this.chkBaixaAutomatica);
            this.Controls.Add(this.lblLocalArmazenamento);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.chkDiasUteis);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblEntidade);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.txtCodLocalArmazenamento);
            this.Controls.Add(this.txtParcelas);
            this.Controls.Add(this.txtDescLocalArmazenamento);
            this.Controls.Add(this.txtCodCategoria);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.cbxFormaPagamento);
            this.Controls.Add(this.dtpDataBase);
            this.Controls.Add(this.txtCodEntidade);
            this.Controls.Add(this.txtDescEntidade);
            this.Name = "frmSaidasNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova saída";
            this.Load += new System.EventHandler(this.frmSaidasNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnEntidades;
        private System.Windows.Forms.CheckBox chkBaixaAutomatica;
        private System.Windows.Forms.Label lblLocalArmazenamento;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.CheckBox chkDiasUteis;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblEntidade;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtCodLocalArmazenamento;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.TextBox txtDescLocalArmazenamento;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.ComboBox cbxFormaPagamento;
        private System.Windows.Forms.DateTimePicker dtpDataBase;
        private System.Windows.Forms.TextBox txtCodEntidade;
        private System.Windows.Forms.TextBox txtDescEntidade;
    }
}