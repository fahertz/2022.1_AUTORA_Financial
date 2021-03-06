namespace Financial.Forms
{
    partial class frmEntradas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.chkFechado = new System.Windows.Forms.CheckBox();
            this.chkAberto = new System.Windows.Forms.CheckBox();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.lblInicial = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(951, 506);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 33);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(951, 11);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 33);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(951, 54);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 33);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(16, 146);
            this.dgvDados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(1035, 352);
            this.dgvDados.TabIndex = 22;
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(16, 31);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(372, 22);
            this.txtFiltro.TabIndex = 24;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Filtro";
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.chkFechado);
            this.gpbStatus.Controls.Add(this.chkAberto);
            this.gpbStatus.Location = new System.Drawing.Point(16, 63);
            this.gpbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Padding = new System.Windows.Forms.Padding(4);
            this.gpbStatus.Size = new System.Drawing.Size(139, 76);
            this.gpbStatus.TabIndex = 26;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Status";
            // 
            // chkFechado
            // 
            this.chkFechado.AutoSize = true;
            this.chkFechado.Location = new System.Drawing.Point(8, 48);
            this.chkFechado.Margin = new System.Windows.Forms.Padding(4);
            this.chkFechado.Name = "chkFechado";
            this.chkFechado.Size = new System.Drawing.Size(83, 20);
            this.chkFechado.TabIndex = 1;
            this.chkFechado.Text = "Fechado";
            this.chkFechado.UseVisualStyleBackColor = true;
            this.chkFechado.CheckedChanged += new System.EventHandler(this.chkFechado_CheckedChanged);
            // 
            // chkAberto
            // 
            this.chkAberto.AutoSize = true;
            this.chkAberto.Location = new System.Drawing.Point(8, 20);
            this.chkAberto.Margin = new System.Windows.Forms.Padding(4);
            this.chkAberto.Name = "chkAberto";
            this.chkAberto.Size = new System.Drawing.Size(69, 20);
            this.chkAberto.TabIndex = 0;
            this.chkAberto.Text = "Aberto";
            this.chkAberto.UseVisualStyleBackColor = true;
            this.chkAberto.CheckedChanged += new System.EventHandler(this.chkAberto_CheckedChanged);
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(163, 82);
            this.dtpInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(108, 22);
            this.dtpInicial.TabIndex = 27;
            this.dtpInicial.ValueChanged += new System.EventHandler(this.dtpInicial_ValueChanged);
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Location = new System.Drawing.Point(159, 63);
            this.lblInicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(41, 16);
            this.lblInicial.TabIndex = 28;
            this.lblInicial.Text = "Inicial";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(276, 63);
            this.lblFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(36, 16);
            this.lblFinal.TabIndex = 30;
            this.lblFinal.Text = "Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(280, 82);
            this.dtpFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(108, 22);
            this.dtpFinal.TabIndex = 29;
            this.dtpFinal.ValueChanged += new System.EventHandler(this.dtpFinal_ValueChanged);
            // 
            // frmEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 545);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.lblInicial);
            this.Controls.Add(this.dtpInicial);
            this.Controls.Add(this.gpbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnFechar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.frmEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.CheckBox chkFechado;
        private System.Windows.Forms.CheckBox chkAberto;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.DateTimePicker dtpFinal;
    }
}