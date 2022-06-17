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

        ////Armazenamento utilizado pela tela        
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_TIPO_CATEGORIA.json";                                     //Nome do arquivo


        //Tipo Categoria
        Tipo_Categoria categoria = new Tipo_Categoria();

        private int carregar_Cod_TipoCategoria()
        {

            if (Tipos_Categoria.Count > 0)
            {
                return Tipos_Categoria[Tipos_Categoria.Count - 1].idTipo_Categoria + 1;
            }
            else
                return 1;
        }
        

        //Salvar categoria
        void salvar_TipoCategoria(int Codigo, string Descricao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            // 
            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo "+lblTipoCategoria.Text+" não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Warning;
                mm.exibirMensagem();
                txtDescCategoria.Focus();
                this.Close();

            }


            //Preenchendo os dados da classe
            categoria.idTipo_Categoria = Codigo;
            categoria.descTipo_Categoria = Descricao;

            

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Tipos_Categoria.Count > 0)
                {
                    Tipos_Categoria.Add(categoria);
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Tipos_Categoria, Formatting.Indented), Encoding.UTF8);
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

        
                                

        //Load do form
        private void frmTipoCategoriaNovo_Load(object sender, EventArgs e)
        {
            //Nome do arquivo completop
            string complete_Archive = wpath + folder + nome_Arquivo;

            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);
            txtCodTipoCategoria.ReadOnly = true;
            
            //Definindo o código Inicial do processo            
            int lastCode = 0;            
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = carregar_Cod_TipoCategoria()));
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
            lock(txtCodTipoCategoria)
            salvar_TipoCategoria(Convert.ToInt32(txtCodTipoCategoria.Text),txtDescCategoria.Text);
            
        }
    }
}
