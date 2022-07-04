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
    public partial class frmTipoCategoriaNovo : Form
    {
        public frmTipoCategoriaNovo()
        {
            InitializeComponent();
        }


        //Instância
        //Classe para emissão de mensagens de forma simplificada
        Mensagem mm = new Mensagem();   
                                                         
        //Load do form
        private void frmTipoCategoriaNovo_Load(object sender, EventArgs e)
        {
    
            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);
            txtCodTipoCategoria.ReadOnly = true;
            
            //Definindo o código Inicial do processo            
            int lastCode = 0;            
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = Tipo_Categoria.obterUltimoCodigo()));
            txtCodTipoCategoria.Text = lastCode.ToString();

        }


        //Cancelar operação
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtDescCategoria.Text.Trim().Equals(String.Empty)) 
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
            lock (txtCodTipoCategoria)
            {
                if (txtDescCategoria.Text.Trim().Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblTipoCategoria.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    mm.exibirMensagem();
                    txtDescCategoria.Focus();                    
                }

                try
                {
                    Tipo_Categoria.adicionar(txtCodTipoCategoria.Text, txtDescCategoria.Text);
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
