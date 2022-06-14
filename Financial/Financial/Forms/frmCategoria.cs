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




        //Abrir tipo de Categoria
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


        //Botão novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCategoriaNovo frmNovo = new frmCategoriaNovo();
            frmNovo.ShowDialog();

        }


        //Fechar form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

