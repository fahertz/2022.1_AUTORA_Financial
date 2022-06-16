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
    public partial class frmCategoriaNovo : Form
    {
        public frmCategoriaNovo()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_CATEGORIA.json";                                           //Nome do arquivo

        Categoria categoria = new Categoria();

        //Carrega o último código adicionado
        private int carregarCodCategoria()
        {
            if (Categorias.Count > 0)
                return Categorias[Categorias.Count - 1].idCategoria + 1;
            else
                return 1;
        }

        //Salvar categoria
        void salvar_Categoria(int Codigo, string Descricao, int codTpCat)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblCategoria.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Warning;
                mm.exibirMensagem();
                txtDescTipoCategoria.Focus();
                this.Close();

            }
            
            //Preenchendo os dados da classe
            categoria.idCategoria = Codigo;
            categoria.descCategoria = Descricao;
            categoria.idTipo_Categoria = codTpCat;

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Categorias.Count > 0)
                {
                    Categorias.Add(categoria);
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Categorias, Formatting.Indented), Encoding.UTF8);
                }
                else
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(categoria, Formatting.Indented), Encoding.UTF8);
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


        private void frmCategoriaNovo_Load(object sender, EventArgs e)
        {
             //Configurações do Form
            txtCodCategoria.ReadOnly = true;

            //Caracteristicas do form
            this.MaximizeBox = false;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = carregarCodCategoria()));
            txtCodCategoria.Text = lastCode.ToString();            
        }


        //Carrega o tipo de categoria ao digitar
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


        //Botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtCodCategoria)
            {
                if (txtDescTipoCategoria.Text.Equals(String.Empty))
                {
                    mm.Message = "O tipo de categoria não pode estar vazio";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }

                int block = 1;
                foreach (var tipo in Tipos_Categoria)
                {
                    if (tipo.descTipo_Categoria.ToUpper().Equals(txtDescTipoCategoria.Text.ToUpper()))
                        block = 0;
                }

                if (block == 1)
                {
                    mm.Message = "Tipo de categoria inválida";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }



                salvar_Categoria(Convert.ToInt32(txtCodCategoria.Text), txtDescCategoria.Text, Convert.ToInt32(txtCodTipoCategoria.Text));
            }
        }

        //Botão Cancelar
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
    }
}
