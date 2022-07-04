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
using static Financial.Local;

namespace Financial.Forms
{
    public partial class frmLocais : Form
    {
        public frmLocais()
        {
            InitializeComponent();
           
        }

       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmLocaisNovo frmNovo = new frmLocaisNovo();
            frmNovo.ShowDialog();
            Local.carregar(dgvDados);

        }

        private void frmLocais_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            Formulario.configuracaoPadrao(this);
            
            Local.carregar(dgvDados);
        }


    

        private void txtLocal_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtLocal.Text) || row.Cells[0].Value.ToString().Contains(txtLocal.Text) || row.Cells[3].Value.ToString().Contains(txtLocal.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmLocaisEditar frmEditar = new frmLocaisEditar();
                frmEditar.idLocal = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.nomeLocal = dgvDados.CurrentRow.Cells[1].Value.ToString();

                foreach (var item in Locais)
                {
                    if (item.idLocal == Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString()))
                    {
                        frmEditar.valorLocal = item.valorLocal;
                        frmEditar.obsLocal = item.observacaoLocal;                        
                    }
                }
                frmEditar.ShowDialog();
                Local.carregar(dgvDados);               
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
