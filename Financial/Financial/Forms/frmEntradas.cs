using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Financial.Forms
{
    public partial class frmEntradas : Form
    {
        public frmEntradas()
        {
            InitializeComponent();
        }


        private void abrirNovo()
        {
            Application.Run(new frmEntradasNovo());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Thread tAbrirNovo = new Thread(abrirNovo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBaixar_Saldo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }













        //Fechar tela
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
