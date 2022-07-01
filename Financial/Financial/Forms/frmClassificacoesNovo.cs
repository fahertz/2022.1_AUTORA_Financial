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
    public partial class frmClassificacoesNovo : Form
    {
        public frmClassificacoesNovo()
        {
            InitializeComponent();
        }

        static Mensagem mm = new Mensagem();
                        

        private void frmClassificacoesNovo_Load(object sender, EventArgs e)
        {            
            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);
            txtCodClassificacao.ReadOnly = true;

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = Classificacao.retornarUltimoCodigo()));
            txtCodClassificacao.Text = lastCode.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtClassificacao.Text.Trim().Equals(String.Empty))
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtClassificacao)
            { 
                if (txtCodClassificacao.Text.Trim().Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblClassificacao.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    mm.exibirMensagem();
                    txtClassificacao.Focus();
                    this.Close();

                }

            
            try
            {
                Classificacao.adicionar(txtCodClassificacao.Text,txtClassificacao.Text);
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
                mm.Message = "Registro salvo com sucesso!";
                mm.Tittle = "Salvar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
            }
        }

 
    }
}
