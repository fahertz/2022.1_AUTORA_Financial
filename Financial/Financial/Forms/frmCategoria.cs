using System;
using System.Windows.Forms;
using static Financial.Categoria_Financeira;

namespace Financial.Forms
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }


        private void frmCategoria_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            Formulario.configuracaoPadrao(this);
            Categoria.carregar(dgvDados);
        }


        //Abrir tipo de Categoria
        private void btnTipoCategoria_Click(object sender, EventArgs e)
        {
            frmTipoCategoria frmTipoCategoria = new frmTipoCategoria();
            frmTipoCategoria.ShowDialog();            
            
        }

        //Botão novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCategoriaNovo frmNovo = new frmCategoriaNovo();
            frmNovo.ShowDialog();
            Categoria.carregar(dgvDados);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmCategoriaEditar frmEditar = new frmCategoriaEditar();
                frmEditar.CodCategoria = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.DesCategoria = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.CodTipCategoria = Convert.ToInt32(dgvDados.CurrentRow.Cells[2].Value.ToString());
                frmEditar.ShowDialog();
                Categoria.carregar(dgvDados);
            }
        }

            
        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtCategoria.Text) || row.Cells[0].Value.ToString().Contains(txtCategoria.Text) || row.Cells[3].Value.ToString().Contains(txtCategoria.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        //Fechar form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

