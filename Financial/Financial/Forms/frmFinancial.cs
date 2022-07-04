using Financial.Forms;
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
using static Financial.Classificacao;
using static Financial.Entidade;
using static Financial.Entidade_Classificacao;
using static Financial.Local;
using static Financial.Categoria_Financeira.Tipo_Categoria;
using static Financial.Categoria_Financeira.Categoria;
using static Financial.EntradaFinanceira;


namespace Financial
{
    public partial class frmFinancial : Form
    {
        public frmFinancial()
        {
            InitializeComponent();
        }



        //Instancia
        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        



        //Criar pastas necessárias
        void criarPastas(string Folder)
        {
            //Cria a pasta se ela não existir            
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
        }

        //Carregar tabelas do sistema
        private void carregar_TipoCategoria(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Tipos_Categoria.Add((Tipo_Categoria)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Tipo_Categoria))));
                    reader.Close();

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

                    }
                    catch
                    {
                        throw;

                    }
                }

            }

        }
        private void carregar_Categoria(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Categorias.Add((Categoria)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Categoria))));
                    reader.Close();

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
                            Categorias.Add(new Categoria { idCategoria = Convert.ToInt32(dr["idCategoria"].ToString()), descCategoria = dr["descCategoria"].ToString(), idTipo_Categoria = Convert.ToInt32(dr["idTipo_Categoria"].ToString()) });
                        }

                    }
                    catch
                    {
                        throw;

                    }
                }

            }

        }
        private void carregar_Classificacao(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Classificacoes.Add((Classificacao)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Classificacao))));
                    reader.Close();

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
                            Classificacoes.Add(new Classificacao { idClassificacao = Convert.ToInt32(dr["idClassificacao"].ToString()), nomeClassificacao = dr["nomeClassificacao"].ToString()});
                        }

                    }
                    catch
                    {
                        throw;

                    }
                }

            }

        }
        private void carregar_Entidade(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Entidades.Add((Entidade)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Entidade))));
                    reader.Close();

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
                            Entidades.Add(new Entidade { idEntidade = Convert.ToInt32(dr["idEntidade"].ToString())
                                                       , nomeEntidade = dr["nomeEntidade"].ToString() 
                                                       , telefoneEntidade = dr["telefoneEntidade"].ToString()
                                                       , emailEntidade = dr["emailEntidade"].ToString()
                                                       , obsEntidade = dr["obsEntidade"].ToString()
                            });
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }

            }
        }
        private void carregar_Entidade_Classificacao(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Entidades_Classificacoes.Add((Entidade_Classificacao)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Entidade_Classificacao))));
                    reader.Close();

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
                            Entidades_Classificacoes.Add(new Entidade_Classificacao { idEntidade = Convert.ToInt32(dr["idEntidade"].ToString())
                                                                                    , idClassificacao = Convert.ToInt32(dr["idClassificacao"].ToString()) });
                        }

                    }
                    catch
                    {
                        throw;

                    }
                }

            }
        }
        private void carregar_Local(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Locais.Add((Local)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Local))));
                    reader.Close();

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
                            Locais.Add(new Local
                            {
                                idLocal = Convert.ToInt32(dr["idLocal"].ToString())                                                                                    
                                ,nameLocal = dr["nameLocal"].ToString()
                                ,valorLocal = Convert.ToDouble(dr["valorLocal"].ToString())
                                ,observacaoLocal = dr["observacaoLocal"].ToString()
                            });
                        }

                    }
                    catch
                    {
                        throw;

                    }
                }

            }
        }

        private void carregar_Entrada(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {

                    Entradas_Financeiras.Add((EntradaFinanceira)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(EntradaFinanceira))));
                    reader.Close();

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
                            Entradas_Financeiras.Add(new EntradaFinanceira
                            {
                                tipoMovimento = dr["tipoMovimento"].ToString()
                               ,idOperacao = Convert.ToInt32(dr["idOperacao"].ToString())
                            });
                        }

                    }
                    catch
                    {
                        throw;

                    }
                }

            }
        }
        //Load do form
        private void frmFinancial_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
            Task.Factory.StartNew(() => criarPastas(wpath + "\\CADASTROS"));
            Task.Factory.StartNew(() => criarPastas(wpath + "\\OPERACOES"));
            Task.Factory.StartNew(() => carregar_TipoCategoria(wpath + "\\CADASTROS" + "\\CAD_TIPO_CATEGORIA.json"));
            Task.Factory.StartNew(() => carregar_Categoria(wpath + "\\CADASTROS" + "\\CAD_CATEGORIA.json"));
            Task.Factory.StartNew(() => carregar_Classificacao(wpath + "\\CADASTROS" + "\\CAD_CLASSIFICACAO.json"));
            Task.Factory.StartNew(() => carregar_Entidade(wpath + "\\CADASTROS" + "\\CAD_ENTIDADE.json"));
            Task.Factory.StartNew(() => carregar_Entidade_Classificacao(wpath + "\\CADASTROS" + "\\CAD_ENTIDADE_CLASSIFICACAO.json"));
            Task.Factory.StartNew(() => carregar_Local(wpath + "\\CADASTROS" + "\\CAD_LOCAL.json"));
            Task.Factory.StartNew(() => carregar_Entrada(wpath + "\\OPERACOES" + "\\OPE_ENTRADA.json"));
        }





        private void abrir_Entradas()
        {
            Application.Run(new frmEntradas());            
        }

        //Abrir tela de entradas
        private void btnEntradas_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(abrir_Entradas);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
      
    
        private void abrirCadastros()
        {
            Application.Run(new frmCadastros());
        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            Thread tAbrirCadastros = new Thread(abrirCadastros);
            tAbrirCadastros.SetApartmentState(ApartmentState.STA);
            tAbrirCadastros.Start();
        }


        //Encerrar Aplicação
        private void btnFechar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja encerrar a aplicação?";
            mm.Tittle = "Fechar aplicação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}
