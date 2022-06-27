namespace Financial.Forms
{
    partial class frmEntidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lblEntidades = new System.Windows.Forms.Label();
            this.txtEntidades = new System.Windows.Forms.TextBox();
            this.btnClassificacoes = new System.Windows.Forms.Button();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.cbxClassificacao = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(708, 375);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 27);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(7, 50);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(776, 319);
            this.dgvDados.TabIndex = 37;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(707, 20);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 27);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(627, 20);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 27);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lblEntidades
            // 
            this.lblEntidades.AutoSize = true;
            this.lblEntidades.Location = new System.Drawing.Point(7, 8);
            this.lblEntidades.Name = "lblEntidades";
            this.lblEntidades.Size = new System.Drawing.Size(54, 13);
            this.lblEntidades.TabIndex = 34;
            this.lblEntidades.Text = "Entidades";
            // 
            // txtEntidades
            // 
            this.txtEntidades.Location = new System.Drawing.Point(7, 24);
            this.txtEntidades.Name = "txtEntidades";
            this.txtEntidades.Size = new System.Drawing.Size(399, 20);
            this.txtEntidades.TabIndex = 0;
            this.txtEntidades.TextChanged += new System.EventHandler(this.txtEntidades_TextChanged);
            // 
            // btnClassificacoes
            // 
            this.btnClassificacoes.Location = new System.Drawing.Point(7, 372);
            this.btnClassificacoes.Name = "btnClassificacoes";
            this.btnClassificacoes.Size = new System.Drawing.Size(123, 30);
            this.btnClassificacoes.TabIndex = 3;
            this.btnClassificacoes.Text = "Classificações";
            this.btnClassificacoes.UseVisualStyleBackColor = true;
            this.btnClassificacoes.Click += new System.EventHandler(this.btnClassificacoes_Click);
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Location = new System.Drawing.Point(409, 9);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(69, 13);
            this.lblClassificacao.TabIndex = 39;
            this.lblClassificacao.Text = "Classificação";
            // 
            // cbxClassificacao
            // 
            this.cbxClassificacao.FormattingEnabled = true;
            this.cbxClassificacao.Location = new System.Drawing.Point(412, 24);
            this.cbxClassificacao.Name = "cbxClassificacao";
            this.cbxClassificacao.Size = new System.Drawing.Size(209, 21);
            this.cbxClassificacao.TabIndex = 40;
            this.cbxClassificacao.SelectedIndexChanged += new System.EventHandler(this.cbxClassificacao_SelectedIndexChanged);
            // 
            // frmEntidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 407);
            this.Controls.Add(this.cbxClassificacao);
            this.Controls.Add(this.lblClassificacao);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblEntidades);
            this.Controls.Add(this.txtEntidades);
            this.Controls.Add(this.btnClassificacoes);
            this.Name = "frmEntidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entidades";
            this.Load += new System.EventHandler(this.frmEntidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblEntidades;
        private System.Windows.Forms.TextBox txtEntidades;
        private System.Windows.Forms.Button btnClassificacoes;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.ComboBox cbxClassificacao;
    }
}