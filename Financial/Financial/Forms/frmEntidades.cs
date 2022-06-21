using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial.Forms
{
    public partial class frmEntidades : Form
    {
        public frmEntidades()
        {
            InitializeComponent();
        }

        private void frmEntidades_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void abrirClassificacoes()
        {
            Application.Run(new frmClassificacoes());
        }

        private void btnClassificacoes_Click(object sender, EventArgs e)
        {
            Thread tAbrirClassificacoes = new Thread(abrirClassificacoes);
            tAbrirClassificacoes.SetApartmentState(ApartmentState.STA);
            tAbrirClassificacoes.Start();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmEntidadesNovo form = new frmEntidadesNovo();
            form.ShowDialog();
        }
    }
}
