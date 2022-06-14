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

namespace Financial.Forms
{
    public partial class frmTipoCategoriaEditar : Form
    {
        public frmTipoCategoriaEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_TIPO_CATEGORIA.json";                                     //Nome do arquivo

   
        //Instância dos dados
        public string CodCategoria { get; set; }
        public string DesCategoria { get; set; }

        //Salvar categoria
        void salvar_Categoria(int Codigo, string Descricao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;
                      
            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblTipoCategoria.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Warning;
                mm.exibirMensagem();
                txtDescCategoria.Focus();
                return;
            }

            for (int x = 0; x < Tipos_Categoria.Count; x++)
            {
                if (Codigo == Tipos_Categoria[x].idTipo_Categoria)
                {
                    Tipos_Categoria[x].descTipo_Categoria = Descricao;
                    break;
                }
            }
          
            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Tipos_Categoria.Count > 0)
                {                  
                        File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Tipos_Categoria, Formatting.Indented), Encoding.UTF8);                    
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
                mm.Message = "Registro alterado com sucesso!";
                mm.Tittle = "Editar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }

        //Remover categoria
        void deletar_Categoria(int Codigo, string Descricao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;
          
            for (int x = 0; x < Tipos_Categoria.Count; x++)
            {
                if (Codigo == Tipos_Categoria[x].idTipo_Categoria)
                {
                    Tipos_Categoria.Remove(Tipos_Categoria[x]);
                    break;
                }
            }

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Tipos_Categoria.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Tipos_Categoria, Formatting.Indented), Encoding.UTF8);
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
                if (Tipos_Categoria.Count == 0)
                    File.Delete(_folder + nome_Arquivo);
                mm.Message = "Registro deletado com sucesso!";
                mm.Tittle = "Deletar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }


        //Load do form
        private void frmTipoCategoriaEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodTipoCategoria.ReadOnly = true;            
            this.MaximizeBox = false;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);


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
                salvar_Categoria(Convert.ToInt32(txtCodTipoCategoria.Text), txtDescCategoria.Text);
                this.Close();
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
                deletar_Categoria(Convert.ToInt32(txtCodTipoCategoria.Text), txtDescCategoria.Text);
                this.Close();
            }
        }
    }
}
