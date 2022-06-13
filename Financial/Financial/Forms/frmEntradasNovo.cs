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
    public partial class frmEntradasNovo : Form
    {
        public frmEntradasNovo()
        {
            InitializeComponent();
        }

        private void frmEntradasNovo_Load(object sender, EventArgs e)
        {
            //Carregar formas de pagamento
            cbxFormaPagamento.Items.Add("PIX");
            cbxFormaPagamento.Items.Add("Cartão Crédito");
            cbxFormaPagamento.Items.Add("Cartão Débito");
            cbxFormaPagamento.Items.Add("Dinheiro");

        }
    }
}
