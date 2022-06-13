namespace Financial.Forms
{
    partial class frmCategoria
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
            this.btnTipoCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTipoCategoria
            // 
            this.btnTipoCategoria.Location = new System.Drawing.Point(401, 41);
            this.btnTipoCategoria.Name = "btnTipoCategoria";
            this.btnTipoCategoria.Size = new System.Drawing.Size(123, 30);
            this.btnTipoCategoria.TabIndex = 25;
            this.btnTipoCategoria.Text = "Tipo Categoria";
            this.btnTipoCategoria.UseVisualStyleBackColor = true;
            this.btnTipoCategoria.Click += new System.EventHandler(this.btnTipoCategoria_Click);
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTipoCategoria);
            this.Name = "frmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTipoCategoria;
    }
}