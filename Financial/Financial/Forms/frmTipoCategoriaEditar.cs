using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial.Forms
{
    public partial class frmTipoCategoriaEditar : Form
    {
        public frmTipoCategoriaEditar()
        {
            InitializeComponent();
        }
        public int CodCategoria;
        public string DesCategoria;

        //Load do form
        private void frmTipoCategoriaEditar_Load(object sender, EventArgs e)
        {
            txtCodTipoCategoria.ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
