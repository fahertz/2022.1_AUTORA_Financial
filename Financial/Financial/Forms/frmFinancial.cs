using Financial.Forms;
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

namespace Financial
{
    public partial class frmFinancial : Form
    {
        public frmFinancial()
        {
            InitializeComponent();
        }

        //Instancia
        Mensagem mm = new Mensagem();





        private void abrir_Entradas()
        {
            Application.Run(new frmEntradas());
            
        }


        //Abrir tela de entradas
        private void btnEntradas_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(abrir_Entradas);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }






        //Encerrar Aplicação
        private void btnFechar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja encerrar a aplicação?";
            mm.Tittle = "Fechar aplicação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            Application.Exit();
        }

       
    }
}
