namespace Financial.Forms
{
    partial class frmEntradasEditar
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
            this.lblLocalArmazenamento = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnBaixarcSaldo = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnBaixarsSaldo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 85);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 49;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 101);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(78, 20);
            this.txtValor.TabIndex = 29;
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(789, 145);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(67, 30);
            this.btnLocal.TabIndex = 44;
            this.btnLocal.Text = "Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(789, 109);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(67, 30);
            this.btnCategoria.TabIndex = 42;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnEntidades
            // 
            this.btnEntidades.Location = new System.Drawing.Point(789, 76);
            this.btnEntidades.Name = "btnEntidades";
            this.btnEntidades.Size = new System.Drawing.Size(67, 30);
            this.btnEntidades.TabIndex = 41;
            this.btnEntidades.Text = "Entidades";
            this.btnEntidades.UseVisualStyleBackColor = true;
            this.btnEntidades.Click += new System.EventHandler(this.btnEntidades_Click);
            // 
            // lblLocalArmazenamento
            // 
            this.lblLocalArmazenamento.AutoSize = true;
            this.lblLocalArmazenamento.Location = new System.Drawing.Point(12, 125);
            this.lblLocalArmazenamento.Name = "lblLocalArmazenamento";
            this.lblLocalArmazenamento.Size = new System.Drawing.Size(111, 13);
            this.lblLocalArmazenamento.TabIndex = 48;
            this.lblLocalArmazenamento.Text = "Local armazenamento";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(94, 85);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(48, 13);
            this.lblParcelas.TabIndex = 47;
            this.lblParcelas.Text = "Parcelas";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(148, 85);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(108, 13);
            this.lblFormaPagamento.TabIndex = 46;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(9, 46);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(57, 13);
            this.lblDataBase.TabIndex = 45;
            this.lblDataBase.Text = "Data Base";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(495, 8);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 43;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblEntidade
            // 
            this.lblEntidade.AutoSize = true;
            this.lblEntidade.Location = new System.Drawing.Point(12, 7);
            this.lblEntidade.Name = "lblEntidade";
            this.lblEntidade.Size = new System.Drawing.Size(49, 13);
            this.lblEntidade.TabIndex = 34;
            this.lblEntidade.Text = "Entidade";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(619, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(781, 325);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 30);
            this.btnSalvar.TabIndex = 40;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 165);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(65, 13);
            this.lblObs.TabIndex = 39;
            this.lblObs.Text = "Observação";
            // 
            // txtCodLocalArmazenamento
            // 
            this.txtCodLocalArmazenamento.Location = new System.Drawing.Point(12, 141);
            this.txtCodLocalArmazenamento.Name = "txtCodLocalArmazenamento";
            this.txtCodLocalArmazenamento.Size = new System.Drawing.Size(44, 20);
            this.txtCodLocalArmazenamento.TabIndex = 32;
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(93, 101);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(52, 20);
            this.txtParcelas.TabIndex = 30;
            // 
            // txtDescLocalArmazenamento
            // 
            this.txtDescLocalArmazenamento.Location = new System.Drawing.Point(62, 141);
            this.txtDescLocalArmazenamento.Name = "txtDescLocalArmazenamento";
            this.txtDescLocalArmazenamento.Size = new System.Drawing.Size(235, 20);
            this.txtDescLocalArmazenamento.TabIndex = 33;
            this.txtDescLocalArmazenamento.TabStop = false;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(498, 23);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(44, 20);
            this.txtCodCategoria.TabIndex = 26;
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(548, 23);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.Size = new System.Drawing.Size(308, 20);
            this.txtDescCategoria.TabIndex = 28;
            this.txtDescCategoria.TabStop = false;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 181);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(844, 138);
            this.txtObservacao.TabIndex = 37;
            // 
            // cbxFormaPagamento
            // 
            this.cbxFormaPagamento.FormattingEnabled = true;
            this.cbxFormaPagamento.ItemHeight = 13;
            this.cbxFormaPagamento.Location = new System.Drawing.Point(151, 101);
            this.cbxFormaPagamento.Name = "cbxFormaPagamento";
            this.cbxFormaPagamento.Size = new System.Drawing.Size(230, 21);
            this.cbxFormaPagamento.TabIndex = 31;
            // 
            // dtpDataBase
            // 
            this.dtpDataBase.Location = new System.Drawing.Point(12, 62);
            this.dtpDataBase.Name = "dtpDataBase";
            this.dtpDataBase.Size = new System.Drawing.Size(230, 20);
            this.dtpDataBase.TabIndex = 27;
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Location = new System.Drawing.Point(12, 23);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Size = new System.Drawing.Size(44, 20);
            this.txtCodEntidade.TabIndex = 24;
            // 
            // txtDescEntidade
            // 
            this.txtDescEntidade.Location = new System.Drawing.Point(62, 23);
            this.txtDescEntidade.Name = "txtDescEntidade";
            this.txtDescEntidade.Size = new System.Drawing.Size(408, 20);
            this.txtDescEntidade.TabIndex = 25;
            this.txtDescEntidade.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblStatus.Location = new System.Drawing.Point(248, 61);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 24);
            this.lblStatus.TabIndex = 51;
            this.lblStatus.Text = "Status";
            // 
            // btnBaixarcSaldo
            // 
            this.btnBaixarcSaldo.Location = new System.Drawing.Point(498, 145);
            this.btnBaixarcSaldo.Name = "btnBaixarcSaldo";
            this.btnBaixarcSaldo.Size = new System.Drawing.Size(140, 30);
            this.btnBaixarcSaldo.TabIndex = 50;
            this.btnBaixarcSaldo.Text = "Baixar c/ Saldo";
            this.btnBaixarcSaldo.UseVisualStyleBackColor = true;
            this.btnBaixarcSaldo.Click += new System.EventHandler(this.btnBaixar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(700, 325);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 30);
            this.btnDeletar.TabIndex = 52;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnBaixarsSaldo
            // 
            this.btnBaixarsSaldo.Location = new System.Drawing.Point(643, 145);
            this.btnBaixarsSaldo.Name = "btnBaixarsSaldo";
            this.btnBaixarsSaldo.Size = new System.Drawing.Size(140, 30);
            this.btnBaixarsSaldo.TabIndex = 53;
            this.btnBaixarsSaldo.Text = "Baixar s/ Saldo";
            this.btnBaixarsSaldo.UseVisualStyleBackColor = true;
            this.btnBaixarsSaldo.Click += new System.EventHandler(this.btnBaixarsSaldo_Click);
            // 
            // frmEntradasEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 363);
            this.Controls.Add(this.btnBaixarsSaldo);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBaixarcSaldo);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnEntidades);
            this.Controls.Add(this.lblLocalArmazenamento);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.lblFormaPagamento);
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
            this.Name = "frmEntradasEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar entrada";
            this.Load += new System.EventHandler(this.frmEntradaNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnEntidades;
        private System.Windows.Forms.Label lblLocalArmazenamento;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.Label lblFormaPagamento;
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
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBaixarcSaldo;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnBaixarsSaldo;
    }
}