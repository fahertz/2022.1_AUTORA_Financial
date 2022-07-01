using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Classificacao;

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
            //Configurações do Form
            Formulario.configuracaoPadrao(this);

            
            Task.Factory.StartNew(() => Classificacao.carregar(dgvDados));
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmClassificacoesNovo form = new frmClassificacoesNovo();
            form.ShowDialog();            
            Classificacao.carregar(dgvDados);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmClassificacoesEditar frmEditar = new frmClassificacoesEditar();
                frmEditar.CodClassificacao = dgvDados.CurrentRow.Cells[0].Value.ToString();
                frmEditar.DesClassificacao = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.ShowDialog();                
                Classificacao.carregar(dgvDados);
            }
        }

        private void txtClassificacao_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtClassificacao.Text) || row.Cells[0].Value.ToString().Contains(txtClassificacao.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);

        }
    }
}
