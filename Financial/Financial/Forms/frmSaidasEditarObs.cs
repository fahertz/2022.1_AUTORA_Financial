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
    public partial class frmSaidasEditarObs : Form
    {
        public frmSaidasEditarObs()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();
        public int flg_Obs = 0;

        private void frmSaidasEditarObs_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Close();
            flg_Obs = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtObservacao.Text.Trim().Equals(String.Empty))
            {
                this.Close();
            }
            else
            {
                mm.Tittle = "Cancelar operação";
                mm.Message = "Ao continuar a baixa sem saldo será cancelada.";
                mm.Buttons = MessageBoxButtons.OKCancel;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
