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
            this.txtDescEntidade = new System.Windows.Forms.TextBox();
            this.txtCodEntidade = new System.Windows.Forms.TextBox();
            this.dtpDataBase = new System.Windows.Forms.DateTimePicker();
            this.cbxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.txtDescLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.txtCodLocalArmazenamento = new System.Windows.Forms.TextBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEntidade = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.lblLocalArmazenamento = new System.Windows.Forms.Label();
            this.btnEntidades = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.chkDiasUteis = new System.Windows.Forms.CheckBox();
            this.chkBaixaAutomatica = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtDescEntidade
            // 
            this.txtDescEntidade.Location = new System.Drawing.Point(62, 24);
            this.txtDescEntidade.Name = "txtDescEntidade";
            this.txtDescEntidade.Size = new System.Drawing.Size(408, 20);
            this.txtDescEntidade.TabIndex = 1;
            this.txtDescEntidade.TabStop = false;
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Location = new System.Drawing.Point(12, 24);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Size = new System.Drawing.Size(44, 20);
            this.txtCodEntidade.TabIndex = 0;
            this.txtCodEntidade.TextChanged += new System.EventHandler(this.txtCodEntidade_TextChanged);
            // 
            // dtpDataBase
            // 
            this.dtpDataBase.Location = new System.Drawing.Point(12, 63);
            this.dtpDataBase.Name = "dtpDataBase";
            this.dtpDataBase.Size = new System.Drawing.Size(230, 20);
            this.dtpDataBase.TabIndex = 3;
            // 
            // cbxFormaPagamento
            // 
            this.cbxFormaPagamento.FormattingEnabled = true;
            this.cbxFormaPagamento.ItemHeight = 13;
            this.cbxFormaPagamento.Location = new System.Drawing.Point(151, 102);
            this.cbxFormaPagamento.Name = "cbxFormaPagamento";
            this.cbxFormaPagamento.Size = new System.Drawing.Size(230, 21);
            this.cbxFormaPagamento.TabIndex = 7;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 182);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(925, 138);
            this.txtObservacao.TabIndex = 11;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(498, 24);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodCategoria.TabIndex = 1;
            this.txtCodCategoria.TextChanged += new System.EventHandler(this.txtCodCategoria_TextChanged);
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(548, 24);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(308, 20);
            this.txtDescCategoria.TabIndex = 3;
            this.txtDescCategoria.TabStop = false;
            // 
            // txtDescLocalArmazenamento
            // 
            this.txtDescLocalArmazenamento.Location = new System.Drawing.Point(62, 142);
            this.txtDescLocalArmazenamento.Name = "txtDescLocalArmazenamento";
            this.txtDescLocalArmazenamento.Size = new System.Drawing.Size(235, 20);
            this.txtDescLocalArmazenamento.TabIndex = 10;
            this.txtDescLocalArmazenamento.TabStop = false;
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(93, 102);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(52, 20);
            this.txtParcelas.TabIndex = 5;
            // 
            // txtCodLocalArmazenamento
            // 
            this.txtCodLocalArmazenamento.Location = new System.Drawing.Point(12, 142);
            this.txtCodLocalArmazenamento.Name = "txtCodLocalArmazenamento";
            this.txtCodLocalArmazenamento.Size = new System.Drawing.Size(44, 20);
            this.txtCodLocalArmazenamento.TabIndex = 8;
            this.txtCodLocalArmazenamento.TextChanged += new System.EventHandler(this.txtCodLocalArmazenamento_TextChanged);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 166);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(65, 13);
            this.lblObs.TabIndex = 12;
            this.lblObs.Text = "Observação";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(862, 326);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 30);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(781, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblEntidade
            // 
            this.lblEntidade.AutoSize = true;
            this.lblEntidade.Location = new System.Drawing.Point(12, 8);
            this.lblEntidade.Name = "lblEntidade";
            this.lblEntidade.Size = new System.Drawing.Size(49, 13);
            this.lblEntidade.TabIndex = 10;
            this.lblEntidade.Text = "Entidade";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(495, 9);
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
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(148, 86);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(108, 13);
            this.lblFormaPagamento.TabIndex = 19;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(94, 86);
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
            // btnEntidades
            // 
            this.btnEntidades.Location = new System.Drawing.Point(870, 69);
            this.btnEntidades.Name = "btnEntidades";
            this.btnEntidades.Size = new System.Drawing.Size(67, 30);
            this.btnEntidades.TabIndex = 14;
            this.btnEntidades.Text = "Entidades";
            this.btnEntidades.UseVisualStyleBackColor = true;
            this.btnEntidades.Click += new System.EventHandler(this.btnEntidades_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(870, 102);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(67, 30);
            this.btnCategoria.TabIndex = 15;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(870, 138);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(67, 30);
            this.btnLocal.TabIndex = 16;
            this.btnLocal.Text = "Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 102);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(78, 20);
            this.txtValor.TabIndex = 4;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 86);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 23;
            this.lblValor.Text = "Valor";
            // 
            // chkDiasUteis
            // 
            this.chkDiasUteis.AutoSize = true;
            this.chkDiasUteis.Location = new System.Drawing.Point(248, 65);
            this.chkDiasUteis.Name = "chkDiasUteis";
            this.chkDiasUteis.Size = new System.Drawing.Size(109, 17);
            this.chkDiasUteis.TabIndex = 10;
            this.chkDiasUteis.Text = "Apenas dias úteis";
            this.chkDiasUteis.UseVisualStyleBackColor = true;
            // 
            // chkBaixaAutomatica
            // 
            this.chkBaixaAutomatica.AutoSize = true;
            this.chkBaixaAutomatica.Location = new System.Drawing.Point(363, 63);
            this.chkBaixaAutomatica.Name = "chkBaixaAutomatica";
            this.chkBaixaAutomatica.Size = new System.Drawing.Size(107, 17);
            this.chkBaixaAutomatica.TabIndex = 11;
            this.chkBaixaAutomatica.Text = "Baixa automática";
            this.chkBaixaAutomatica.UseVisualStyleBackColor = true;
            this.chkBaixaAutomatica.CheckedChanged += new System.EventHandler(this.chkBaixaAutomatica_CheckedChanged);
            // 
            // frmEntradasNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 365);
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
            this.Name = "frmEntradasNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova entrada";
            this.Load += new System.EventHandler(this.frmEntradasNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescEntidade;
        private System.Windows.Forms.TextBox txtCodEntidade;
        private System.Windows.Forms.DateTimePicker dtpDataBase;
        private System.Windows.Forms.ComboBox cbxFormaPagamento;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.TextBox txtDescCategoria;
        private System.Windows.Forms.TextBox txtDescLocalArmazenamento;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.TextBox txtCodLocalArmazenamento;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEntidade;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.Label lblLocalArmazenamento;
        private System.Windows.Forms.Button btnEntidades;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.CheckBox chkDiasUteis;
        private System.Windows.Forms.CheckBox chkBaixaAutomatica;
    }
}