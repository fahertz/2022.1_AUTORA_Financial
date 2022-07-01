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
using static Financial.Entidade;
using static Financial.Classificacao;
using static Financial.Entidade_Classificacao;
namespace Financial.Forms
{
    public partial class frmEntidades : Form
    {
        public frmEntidades()
        {
            InitializeComponent();
        }

        


        private void frmEntidades_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            Formulario.configuracaoPadrao(this);



            Entidade.carregar(dgvDados);
            Classificacao.carregar(cbxClassificacao);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


     

        private void btnClassificacoes_Click(object sender, EventArgs e)
        {
            frmClassificacoes frmClassificacoes = new frmClassificacoes();
            frmClassificacoes.ShowDialog();            
            Classificacao.carregar(cbxClassificacao);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmEntidadesNovo form = new frmEntidadesNovo();
            form.ShowDialog();
            Entidade.carregar(dgvDados);

        }

        private void txtEntidades_TextChanged(object sender, EventArgs e)
        {
            cbxClassificacao_SelectedIndexChanged(cbxClassificacao, new EventArgs());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null) 
            {
                frmEntidadesEditar frmEditar = new frmEntidadesEditar();
                frmEditar.codEntidade = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.nomeEntidade = dgvDados.CurrentRow.Cells[1].Value.ToString();
                
                foreach (var item in Entidades)
                {
                    if (item.idEntidade == Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString()))
                    {
                        frmEditar.telefoneEntidade = item.telefoneEntidade;
                        frmEditar.emailEntidade = item.emailEntidade;
                        frmEditar.obsEntidade = item.obsEntidade;
                    }
                }                                               
                frmEditar.ShowDialog();                
                Entidade.carregar(dgvDados);             
            }
        }

        private void cbxClassificacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtEntidades.Text) || row.Cells[0].Value.ToString().Contains(txtEntidades.Text))
                {
                    if (cbxClassificacao.SelectedItem != null) 
                    {
                        string[] Classificacao_Selecionada = cbxClassificacao.SelectedItem.ToString().Split('|');


                        var resultado = from class_Entidade in Entidades_Classificacoes
                                        where class_Entidade.idClassificacao == Convert.ToInt32(Classificacao_Selecionada[0].ToString())
                                        select new { class_Entidade.idEntidade };
                        List<int> filtro = new List<int>();
                        foreach (var item in resultado)
                        {
                            filtro.Add(item.idEntidade);
                        }

                        if (filtro.Contains(Convert.ToInt32(row.Cells[0].Value.ToString())) && (row.Cells[1].Value.ToString().Contains(txtEntidades.Text) || row.Cells[0].Value.ToString().Contains(txtEntidades.Text)))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    
                }
                else
                {
                    row.Visible = false;
                }
            }
            
        }
    }
}
