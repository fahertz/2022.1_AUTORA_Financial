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
    public partial class frmLocaisEditar : Form
    {
        public frmLocaisEditar()
        {
            InitializeComponent();
            txtValorLocal.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
            txtValorLocal.Validating += CaixaDeTexto.txt_convertDouble_Validated;
        }

        Mensagem mm = new Mensagem();        

        //Instância dos dados
        public int idLocal { get; set; }
        public string nomeLocal { get; set; }
        public double valorLocal { get; set; }
        public string obsLocal { get; set; }
    
        private void frmLocaisEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtIdLocal.ReadOnly = true;
            Formulario.configuracaoPadrao(this);                                    
            
            //Dados herdados
            txtIdLocal.Text = idLocal.ToString();
            txtNameLocal.Text = nomeLocal;
            txtValorLocal.Text = valorLocal.ToString();
            txtObservacao.Text = obsLocal;
            txtValorLocal.Text = String.Format("{0:#0.00}", Convert.ToDouble(txtValorLocal.Text));            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja deletar o registro?";
            mm.Tittle = "Deletar registro";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                try
                {
                    Local.deletar_Local(txtIdLocal.Text);
                }
                catch (Exception ex)
                {
                    mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                    mm.Tittle = "Erro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();
                }
                finally
                {
                    mm.Message = "Registro alterado com sucesso!";
                    mm.Tittle = "Editar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }                
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja salvar a operação?";
            mm.Tittle = "Salvar a operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                try
                {
                    Local.editar_Local(txtIdLocal.Text, txtNameLocal.Text, txtValorLocal.Text, txtObservacao.Text);
                }
                catch (Exception ex)
                {
                    mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                    mm.Tittle = "Erro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();
                }
                finally
                {
                    mm.Message = "Registro alterado com sucesso!";
                    mm.Tittle = "Editar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();                    
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtNameLocal.Text.Equals(nomeLocal) && txtObservacao.Text.Equals(obsLocal) && txtValorLocal.Text.Equals(valorLocal))
            {
                this.Close();
            }
            else
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
    }
}
