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
namespace Financial.Forms
{
    public partial class frmEntidadesNovo : Form
    {
        public frmEntidadesNovo()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_ENTIDADE.json";                                           //Nome do arquivo

        Entidade entidade = new Entidade();



        //Carrega o último código adicionado
        private int carregarCodEntidade()
        {
            if (Entidades.Count > 0)
                return Entidades[Entidades.Count - 1].idEntidade + 1;
            else
                return 1;
        }

        private void configurar_Grid(DataGridView _dgv)
        {
            _dgv.Rows.Clear();
            _dgv.Columns.Clear();
            _dgv.Columns.Add("idClassificacao", "Cod. Classificação");
            _dgv.Columns.Add("descClassificacao", "Classificação");
        }


        private void salvar_Entidade()
        {
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

            if (mtxTelefone.MaskFull || mtxTelefone.Text.Trim().Equals(String.Empty) || txtEmail.Text.ToString().Trim().Equals(String.Empty)
                || txtObservacao.Text.ToString().Trim().Equals(String.Empty))
            {              
                mm.Message = "Existem campos que não estão devidamente preenchidos, deseja salvar mesmo assim?";
                mm.Tittle = "Campos não preenchidos";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Information;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                    salvar_Entidade();
                else
                    return;
            }            

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
            salvar_Entidade();
        }

        private void frmEntidadesNovo_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
            configurar_Grid(dgvDados);
            carregarCodEntidade();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmClassificacoesAux form = new frmClassificacoesAux();
            foreach (var item in Classificacoes)            
                form.clb_Back.Items.Add(item.idClassificacao + "|" + item.nomeClassificacao);            
            form.ShowDialog();
            foreach(var item in form.clb_Back.CheckedItems)
            {
                string[] item_Split = item.ToString().Split('|');
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
