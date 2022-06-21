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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lblEntidades = new System.Windows.Forms.Label();
            this.txtEntidades = new System.Windows.Forms.TextBox();
            this.btnClassificacoes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(708, 375);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 27);
            this.btnFechar.TabIndex = 38;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.btnEditar.Location = new System.Drawing.Point(708, 17);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 27);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(627, 17);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 27);
            this.btnNovo.TabIndex = 35;
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
            this.txtEntidades.Size = new System.Drawing.Size(614, 20);
            this.txtEntidades.TabIndex = 33;
            // 
            // btnClassificacoes
            // 
            this.btnClassificacoes.Location = new System.Drawing.Point(7, 372);
            this.btnClassificacoes.Name = "btnClassificacoes";
            this.btnClassificacoes.Size = new System.Drawing.Size(123, 30);
            this.btnClassificacoes.TabIndex = 32;
            this.btnClassificacoes.Text = "Classificações";
            this.btnClassificacoes.UseVisualStyleBackColor = true;
            this.btnClassificacoes.Click += new System.EventHandler(this.btnClassificacoes_Click);
            // 
            // frmEntidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 407);
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
    }
}