using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Categoria_Financeira;
using static Financial.Categoria_Financeira.Tipo_Categoria;

namespace Financial.Forms
{
    public partial class frmTipoCategoria : Form
    {
        public frmTipoCategoria()
        {
            InitializeComponent();
        }
      
      
        //Iniciando nova instância para criar um Tipo de categoria
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTipoCategoriaNovo frmNovo = new frmTipoCategoriaNovo();
            frmNovo.ShowDialog();
            Tipo_Categoria.carregar(dgvDados);
        }


        //Editar um Tipo de categoria
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmTipoCategoriaEditar frmEditar = new frmTipoCategoriaEditar();
                frmEditar.CodCategoria = dgvDados.CurrentRow.Cells[0].Value.ToString();
                frmEditar.DesCategoria = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.ShowDialog();
                Tipo_Categoria.carregar(dgvDados);
            }
        }


        //Load do form
        private void frmTipoCategoria_Load(object sender, EventArgs e)
        {
            //Configurações do Form
            Formulario.configuracaoPadrao(this);
            
            Task.Factory.StartNew(() => Tipo_Categoria.carregar(dgvDados));
        }


       

        
        //Pesquisa por alteração de teste
        private void txtDescCategoria_TextChanged(object sender, EventArgs e)
        {
            
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                if (row.Cells[1].Value.ToString().Contains(txtDescCategoria.Text) || row.Cells[0].Value.ToString().Contains(txtDescCategoria.Text))                
                        row.Visible = true;                
                    else
                        row.Visible = false;
                }            
        }

        //Duplo clique para ativar
        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        //Fecha a tela
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
