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
using static Financial.Entidade_Classificacao;
using static Financial.Classificacao;
namespace Financial.Forms
{
    public partial class frmClassificacoesAux : Form
    {
        public frmClassificacoesAux()
        {
            InitializeComponent();
        }
        
        Mensagem mm = new Mensagem();



        //Instancia
        public int flg_Editar = 0;

        
        public CheckedListBox clb_Back = new CheckedListBox(); 


        private void filtrar_Classificacao(String filter, CheckedListBox _clbBack, CheckedListBox _clbFront)
        {
            _clbFront.Items.Clear();
            
            
            for (int x=0; x < _clbBack.Items.Count;x++)
            {

                if (_clbBack.Items[x].ToString().ToUpper().Contains(filter.ToUpper()))
                {                    
                    _clbFront.Items.Add(_clbBack.Items[x].ToString(), _clbBack.GetItemCheckState(x));
                }
            }                                  
        }


      




        private void frmClassificacoesAux_Load(object sender, EventArgs e)
        {
            this.Text = "Adicionar Classificação";
            Formulario.configuracaoPadrao(this);
            carregarClassificacoes(clb_Back,Classificacoes);
            filtrar_Classificacao(txtClassificacao.Text, clb_Back, clbClassificacoes);
        }

        private void txtClassificacao_TextChanged(object sender, EventArgs e)
        {
            filtrar_Classificacao(txtClassificacao.Text,clb_Back, clbClassificacoes);
        }        

        private void clbClassificacoes_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            try
            {
                if (clbClassificacoes.SelectedItem != null)
                {
                    if (clbClassificacoes.GetItemCheckState(clbClassificacoes.Items.IndexOf(clbClassificacoes.SelectedItem.ToString())) == CheckState.Checked)
                        clb_Back.SetItemCheckState(clb_Back.Items.IndexOf(clbClassificacoes.SelectedItem.ToString()), CheckState.Unchecked);
                    else
                        clb_Back.SetItemCheckState(clb_Back.Items.IndexOf(clbClassificacoes.SelectedItem.ToString()), CheckState.Checked);
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {                        
            if (clb_Back.CheckedItems.Count > 0)
            {
                mm.Message = "Existem classificações selecionadas para a entidade, tem certeza que deseja cancelar?";
                mm.Tittle = "Cancelar a operação";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                {
                    clb_Back.Items.Clear();
                    this.Close();
                }
                else
                    return;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
