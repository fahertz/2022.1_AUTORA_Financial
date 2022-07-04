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
using static Financial.CaixaDeTexto;
using System.Windows;

namespace Financial.Forms
{
    public partial class frmLocaisNovo : Form
    {
        
        public frmLocaisNovo()
        {
            InitializeComponent();
            txtValorLocal.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
            txtValorLocal.Validating += CaixaDeTexto.txt_convertDouble_Validated;
        }      

        Mensagem mm = new Mensagem();
           
        //Load do form
        private void frmLocaisNovo_Load(object sender, EventArgs e)
        {
            //Configurações do Form
            txtIdLocal.ReadOnly = true;

            txtValorLocal.Text = "0,00";

            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = Local.obterUltimoCodigo()));
            txtIdLocal.Text = lastCode.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtIdLocal)
            {
                if (txtNameLocal.Text.Equals(String.Empty))
                {
                    mm.Message = "O tipo de categoria não pode estar vazio";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }

                try
                {
                    Local.adicionar(txtIdLocal.Text, txtNameLocal.Text, txtValorLocal.Text, txtObservacao.Text);
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
                    mm.Message = "Registro adicionado com sucesso!";
                    mm.Tittle = "Salvar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtIdLocal.Text.Trim().Equals(String.Empty))
            {
                mm.Message = "Você deseja cancelar a operação?";
                mm.Tittle = "Cancelar a operação";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }      
    }
}
