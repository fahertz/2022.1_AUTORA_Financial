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
using static Financial.Categoria;

namespace Financial.Forms
{
    public partial class frmTipoCategoriaNovo : Form
    {
        public frmTipoCategoriaNovo()
        {
            InitializeComponent();
        }


        



        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_TIPO_CATEGORIA.json";                                     //Nome do arquivo


        //Tipo Categoria
        Tipo_Categoria categoria = new Tipo_Categoria();
        
        //Tipos de Categoria
        List<Tipo_Categoria> Tipos_Categoria = new List<Tipo_Categoria>();


        //Carrega o último código adicionado
        private int carregar_Cod_TipoCategoria(String path)
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
                    Tipos_Categoria.Add((Tipo_Categoria)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Tipo_Categoria))));                    
                    reader.Close();
                    return Tipos_Categoria[Tipos_Categoria.Count - 1].idTipo_Categoria + 1;
                }
                catch
                {
                    try
                    {

                        DataTable dt = (DataTable)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(DataTable)));
                        
                        DataRow[] oDataRow = dt.Select();
                        reader.Close();
                        
                        foreach (DataRow dr in oDataRow)
                        {                            
                            Tipos_Categoria.Add(new Tipo_Categoria { idTipo_Categoria = Convert.ToInt32(dr["idTipo_Categoria"].ToString()), descTipo_Categoria = dr["descTipo_Categoria"].ToString() });
                        }
                        
                        return Tipos_Categoria[Tipos_Categoria.Count - 1].idTipo_Categoria + 1;

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


        //Criar pastas necessárias
        void criarPastas(string Folder)
        {            
            //Cria a pasta se ela não existir            
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);                
            }            
        }

        //Salvar categoria
        void salvar_Categoria(int Codigo, string Descricao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;



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
            this.MaximizeBox = false;
            this.MinimumSize = new Size(313,131);
            this.MaximumSize = new Size(313, 131);
            txtCodTipoCategoria.ReadOnly = true;

            //Criando pastas necessárias para o processo
            Task.Factory.StartNew(() => criarPastas(wpath + folder));

            //Definindo o código Inicial do processo            
            int lastCode = 0;            
            Task.WaitAll(Task.Factory.StartNew(() => lastCode = carregar_Cod_TipoCategoria(complete_Archive)));
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
            salvar_Categoria(Convert.ToInt32(txtCodTipoCategoria.Text),txtDescCategoria.Text);
            
        }
    }
}
