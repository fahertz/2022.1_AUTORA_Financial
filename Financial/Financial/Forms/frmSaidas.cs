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
    public partial class frmSaidas : Form
    {
        public frmSaidas()
        {
            InitializeComponent();
        }

        private void frmSaidas_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);

            SaidaFinanceira.carregar(dgvDados);

            //Configuração padrão dos componentes
            dtpInicial.Value = DateTime.Now.AddDays(-30);
            dtpFinal.Value = DateTime.Now.AddDays(30 * 6);

            chkAberto.Checked = true;
            chkFechado.Checked = true;
        }

        //Botoões e configurações
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmSaidasNovo frmNovo = new frmSaidasNovo();
            frmNovo.ShowDialog();
            SaidaFinanceira.carregar(dgvDados);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmSaidasEditar frmEditar = new frmSaidasEditar();
            frmEditar.idOperacao = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value);
            frmEditar.ShowDialog();
            SaidaFinanceira.carregar(dgvDados);
        }
        private void filtrar_Dados()
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (
                        (row.Cells[0].Value.ToString().Contains(txtFiltro.Text)
                        || row.Cells[1].Value.ToString().Contains(txtFiltro.Text)
                        || row.Cells[2].Value.ToString().Contains(txtFiltro.Text)
                        )
                      &&
                        (
                        chkAberto.Checked && chkAberto.Text.Substring(0, 1).Trim() == (row.Cells[5].Value.ToString().Trim())
                        || chkFechado.Checked && chkFechado.Text.Substring(0, 1).Trim() == (row.Cells[5].Value.ToString().Trim())
                        )
                    )
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrar_Dados();
        }
        private void dtpInicial_ValueChanged(object sender, EventArgs e)
        {
            filtrar_Dados();
        }
        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            filtrar_Dados();
        }
        private void chkFechado_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_Dados();
        }
        private void chkAberto_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_Dados();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Configurações em cima do datagridview
        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDados.CurrentRow.Cells != null)
            {
                btnEditar_Click(this, new EventArgs());
            }
        }
    }
     
}
