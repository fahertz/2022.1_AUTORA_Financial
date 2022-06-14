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

namespace Financial.Forms
{
    public partial class frmCategoriaEditar : Form
    {
        public frmCategoriaEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_CATEGORIA.json";                                     //Nome do arquivo
        


        //Instância dos dados
        public int CodCategoria { get; set; }
        public string DesCategoria { get; set; }
        public int CodTipCategoria { get; set; }


        //Salvar categoria
        void salvar_Categoria(int Codigo, string Descricao, int CodTipCategoria, string DescTipCategoria)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblCategoria.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Error;
                mm.exibirMensagem();
                txtDescCategoria.Focus();
                return;
            }

            if (DescTipCategoria.Equals(String.Empty))
            {
                mm.Message = "O campo " + lblCategoria.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Error;
                mm.exibirMensagem();
                txtDescTipoCategoria.Focus();
                return;
            }

            for (int x = 0; x < Categorias.Count; x++)
            {
                if (Codigo == Categorias[x].idCategoria)
                {
                    Categorias[x].descCategoria = Descricao;
                    Categorias[x].idTipo_Categoria = CodTipCategoria;
                    break;
                }
            }

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Categorias.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Categorias, Formatting.Indented), Encoding.UTF8);
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
        void deletar_Categoria(int Codigo)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            for (int x = 0; x < Categorias.Count; x++)
            {
                if (Codigo == Categorias[x].idCategoria)
                {
                    Categorias.Remove(Categorias[x]);
                    break;
                }
            }

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Categorias.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Categorias, Formatting.Indented), Encoding.UTF8);
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
                if (Categorias.Count == 0)
                    File.Delete(_folder + nome_Arquivo);
                mm.Message = "Registro deletado com sucesso!";
                mm.Tittle = "Deletar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }




        private void frmCategoriaEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodCategoria.ReadOnly = true;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);


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
                salvar_Categoria(Convert.ToInt32(txtCodCategoria.Text), txtDescCategoria.Text,Convert.ToInt32(txtCodTipoCategoria.Text),txtDescTipoCategoria.Text);
                this.Close();
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
                

                deletar_Categoria(Convert.ToInt32(txtCodCategoria.Text));
                this.Close();
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
