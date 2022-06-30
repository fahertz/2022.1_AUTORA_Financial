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
using static Financial.Categoria_Financeira;
using static Financial.Categoria_Financeira.Categoria;
using static Financial.Categoria_Financeira.Tipo_Categoria;

namespace Financial.Forms
{
    public partial class frmCategoriaEditar : Form
    {
        public frmCategoriaEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();


        //Instância dos dados
        public int CodCategoria { get; set; }
        public string DesCategoria { get; set; }
        public int CodTipCategoria { get; set; }
  
        private void frmCategoriaEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodCategoria.ReadOnly = true;
            Formulario.configuracaoPadrao(this);


            //Dados herdados
            txtCodCategoria.Text = CodCategoria.ToString();
            txtDescCategoria.Text = DesCategoria;
            txtCodTipoCategoria.Text = CodTipCategoria.ToString();
        }

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja salvar a operação?";
            mm.Tittle = "Salvar a operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {   
                //Validações de campo
                if (txtDescCategoria.Text.Trim().Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblCategoria.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();
                    txtDescCategoria.Focus();
                    return;
                }
                if (txtDescTipoCategoria.Text.Equals(String.Empty))
                {
                    mm.Message = "O campo " + lblCategoria.Text + " não pode estar vazio.";
                    mm.Tittle = "Validação";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();
                    txtDescTipoCategoria.Focus();
                    return;
                }

                //Insert
                try
                {
                    Categoria.editar(txtCodCategoria.Text,txtDescCategoria.Text,txtCodTipoCategoria.Text);
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
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                try
                {
                    Categoria.deletar(txtCodCategoria.Text);
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
                    mm.Message = "Registro deletado com sucesso!";
                    mm.Tittle = "Deletar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }                
            }

        }

        private void txtCodTipoCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var tipos in Tipos_Categoria)
                {
                    if (Convert.ToInt32(txtCodTipoCategoria.Text) == tipos.idTipo_Categoria)
                    {
                        txtDescTipoCategoria.Text = tipos.descTipo_Categoria;
                        break;
                    }
                    else
                    {
                        txtDescTipoCategoria.Text = String.Empty;                        
                    }
                }
            }
            catch
            {
                txtCodTipoCategoria.Text = String.Empty;
                txtDescTipoCategoria.Text = String.Empty;
            }
        }
    }
}
