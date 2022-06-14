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
        private int carregarCodCategoria(String path)
        {
            //Se não houver nenhum cadastro, ele indica o código Inicial como 1
            if (!File.Exists(path))
            {
                return 1;
            }
            // C.C ele assume o último código já posto
            else
            {

                StreamReader reader = new StreamReader(path);

                string linhasDoArquivo = reader.ReadToEnd();

                try
                {
                    Categorias.Add((Categoria)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Categoria))));
                    reader.Close();
                    return Categorias[Categorias.Count - 1].idCategoria + 1;

                }
                catch
                {
                    try
                    {

                        DataTable dt = (DataTable)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(DataTable)));

                        DataRow[] oDataRow = dt.Select();
                        reader.Close();

                        return Categorias[Categorias.Count - 1].idCategoria + 1;

                    }
                    catch (Exception ex)
                    {
                        mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                        mm.Tittle = "Erro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Error;
                        mm.exibirMensagem();
                        this.Close();
                        return 1;
                    }
                }


            }
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

            //Carregar codigo
            txtCodCategoria.Text = carregarCodCategoria(wpath+folder+nome_Arquivo).ToString();
        }

        private void txtCodTipoCategoria_TextChanged(object sender, EventArgs e)
        {
            foreach (var tipos in Tipos_Categoria)
            {
                if (Convert.ToInt32(txtCodTipoCategoria.Text) == tipos.idTipo_Categoria )
                {
                    txtDescTipoCategoria.Text = tipos.descTipo_Categoria;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtCodCategoria)
                salvar_Categoria(Convert.ToInt32(txtCodCategoria.Text), txtDescCategoria.Text,Convert.ToInt32(txtCodTipoCategoria.Text));
        }

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
