using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Financial;
using System.Windows.Forms;
using static Financial.Categoria_Financeira;
using static Financial.Categoria_Financeira.Tipo_Categoria;
using static Financial.Categoria_Financeira.Categoria;
namespace Financial.Forms
{
    public partial class frmTipoCategoriaEditar : Form
    {
        public frmTipoCategoriaEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        //Instância dos dados
        public string CodCategoria { get; set; }
        public string DesCategoria { get; set; }




        //Load do form
        private void frmTipoCategoriaEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodTipoCategoria.ReadOnly = true;
            Formulario.configuracaoPadrao(this);


            //Dados herdados
            txtCodTipoCategoria.Text = CodCategoria;
            txtDescCategoria.Text = DesCategoria;



        }

        //Cancelar operação
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtDescCategoria.Text.Equals(DesCategoria))
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

        //Botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            mm.Message = "Você deseja salvar a operação?";
            mm.Tittle = "Salvar a operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                if (txtDescCategoria.Text.Trim().Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblTipoCategoria.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    mm.exibirMensagem();
                    txtDescCategoria.Focus();
                    return;
                }
                try
                {
                    Tipo_Categoria.editar(txtCodTipoCategoria.Text, txtDescCategoria.Text);
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
        //Botão deletar
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
                    deletar = Tipo_Categoria.deletar(txtCodTipoCategoria.Text);
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


                    if (deletar == 0)
                    {
                        mm.Message = "Impossível deletar, registro associado. Verifique a qual categoria o tipo está associado.";
                        mm.Tittle = "Deletar registro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Warning;
                        mm.exibirMensagem();
                    }
                }
            }
        }
    }
}
