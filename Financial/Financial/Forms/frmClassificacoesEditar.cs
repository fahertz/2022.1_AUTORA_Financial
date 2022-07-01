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
    public partial class frmClassificacoesEditar : Form
    {
        public frmClassificacoesEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();


        //Instância dos dados
        public string CodClassificacao { get; set; }
        public string DesClassificacao { get; set; }


        //Load do form          
        private void frmClassificacoesEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodClassificacao.ReadOnly = true;
            Formulario.configuracaoPadrao(this);


            //Dados herdados
            txtCodClassificacao.Text = CodClassificacao;
            txtClassificacao.Text = DesClassificacao;
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

                if (txtClassificacao.Text.Trim().Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblClassificacao.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    mm.exibirMensagem();
                    txtClassificacao.Focus();
                    return;
                }

                try
                {
                    Classificacao.editar(txtCodClassificacao.Text, txtClassificacao.Text);
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
                    mm.Message = "Registro alterado com sucesso!";
                    mm.Tittle = "Editar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }
            }
        }

        
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja deletar o registro?";
            mm.Tittle = "Deletar registro";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                int deletar = 0;
                try
                {
                    deletar = Classificacao.deletar(txtCodClassificacao.Text);
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
                    if (deletar == 1)
                    {
                        mm.Message = "Registro deletado com sucesso!";
                        mm.Tittle = "Deletar registro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Information;
                        mm.exibirMensagem();
                        this.Close();
                    }
                    else if (deletar == 0)
                    {
                        mm.Message = "Impossível deletar, registro associado.";
                        mm.Tittle = "Deletar registro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Error;
                        mm.exibirMensagem();
                    }

                }
            }
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Equals(DesClassificacao))
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
