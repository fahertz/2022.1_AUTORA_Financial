using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Financial.Forms
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        void abrirTipoCategoria()
        {
            Application.Run(new frmTipoCategoria());
        }


        private void btnTipoCategoria_Click(object sender, EventArgs e)
        {
            Thread tAbrirTipoCategoria = new Thread(abrirTipoCategoria);
            tAbrirTipoCategoria.SetApartmentState(ApartmentState.STA);
            tAbrirTipoCategoria.Start();
        }
    }
}

