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
    public partial class frmClassificacoes : Form
    {
        public frmClassificacoes()
        {
            InitializeComponent();
        }


        //Load do form
        private void frmClassificacoes_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmClassificacoesNovo form = new frmClassificacoesNovo();
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmClassificacoesEditar form = new frmClassificacoesEditar();
            form.ShowDialog();
        }
    }
}
