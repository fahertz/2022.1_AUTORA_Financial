using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Entidade;
using static Financial.Classificacao;
using static Financial.Entidade_Classificacao;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace Financial.Forms
{
    public partial class frmEntidadesNovo : Form
    {
        public frmEntidadesNovo()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        private void configurar_Grid(DataGridView _dgv)
        {
            _dgv.Rows.Clear();
            _dgv.Columns.Clear();
            _dgv.Columns.Add("idClassificacao", "Cod. Classificação");
            _dgv.Columns.Add("descClassificacao", "Classificação");
        }


      


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvDados.Rows.Count > 0 || txtDescEntidade.Text.Trim().Equals(String.Empty) || mtxTelefone.MaskFull || mtxTelefone.Text.Trim().Equals(String.Empty) || txtEmail.Text.ToString().Trim().Equals(String.Empty)
                || txtObservacao.Text.ToString().Trim().Equals(String.Empty))
            {
                mm.Message = "Você deseja cancelar a operação?";
                mm.Tittle = "Cancelar a operação";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                    this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Flag usada para controalr as validações
            int insert = 0;
            if (dgvDados.Rows.Count == 0)
            {
                mm.Message = "Adicione pelo menos uma classificação a entidade.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Exclamation;
                mm.exibirMensagem();
                return;
            }

            if (txtDescEntidade.Text.ToString().Trim().Equals(String.Empty))
            {
                mm.Message = "A entidade não pode estar sem descrição.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Exclamation;
                mm.exibirMensagem();
                return;
            }

            if (mtxTelefone.Text.Trim().Equals(String.Empty) || txtEmail.Text.ToString().Trim().Equals(String.Empty)
                || txtObservacao.Text.ToString().Trim().Equals(String.Empty))
            {
                mm.Message = "Existem campos que não estão devidamente preenchidos, deseja salvar mesmo assim?";
                mm.Tittle = "Campos não preenchidos";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                {
                    insert = 1;
                }
                else
                    return;
            }
            else
            {
                insert = 1;

            }

            if (insert == 1)
            {
                //Inserção entidade
                try
                {
                    Entidade.adicionar(txtCodEntidade.Text, txtDescEntidade.Text, mtxTelefone.Text, txtEmail.Text, txtObservacao.Text);
                    
                    foreach(DataGridViewRow row in dgvDados.Rows)
                    {
                        Entidade_Classificacao.adicionar(txtCodEntidade.Text, row.Cells[0].Value);
                    }
                }
                catch (Exception ex)
                {
                    mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                    mm.Tittle = "Erro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();
                    this.Close();
                }
                finally
                {
                    //Mensagem de entidade inserida com sucesso!
                    mm.Message = "Entidade " + txtDescEntidade.Text + " inserida com sucesso!";
                    mm.Tittle = "Informação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();

                }
            }
        }

        private void frmEntidadesNovo_Load(object sender, EventArgs e)
        {


            //Configurações do Form
            txtCodEntidade.ReadOnly = true;

            //Caracteristicas padrão do form
            Formulario.configuracaoPadrao(this);
            
            
            configurar_Grid(dgvDados);            

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = Entidade.retornarUltimoCodigo()));
            txtCodEntidade.Text = lastCode.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmClassificacoesAux form = new frmClassificacoesAux();
            foreach (var item in Classificacoes)
            {
                int flg_Check = 0;
                foreach (DataGridViewRow row in dgvDados.Rows) 
                {                    
                    if (row.Cells[0].Value.ToString().Equals(item.idClassificacao.ToString()))
                    {                        
                        form.clb_Back.Items.Add(item.idClassificacao + "|" + item.nomeClassificacao, true);
                        flg_Check = 1;
                    }                    
                }
                if (flg_Check != 1)
                form.clb_Back.Items.Add(item.idClassificacao + "|" + item.nomeClassificacao, false);
            }
            form.ShowDialog();
            foreach(var item in form.clb_Back.CheckedItems)
            {
                string[] item_Split = item.ToString().Split('|');
                int flg_Block = 0;
                
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item_Split[0]))
                    {
                        flg_Block = 1;
                    }
                }
                if (flg_Block != 1)
                dgvDados.Rows.Add(item_Split[0].ToString(),item_Split[1].ToString());
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows != null)
            {
                foreach (DataGridViewRow row in dgvDados.SelectedRows)
                {
                    dgvDados.Rows.Remove(row);
                }
            }
        }
    }
}
