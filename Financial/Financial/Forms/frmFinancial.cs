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

        private void frmFinancial_Load(object sender, EventArgs e)
        {

            Formulario.configuracaoPadrao(this);
            criarPastas(wpath+ "\\CADASTROS");
            carregar_TipoCategoria(wpath + "\\CADASTROS" + "\\CAD_TIPO_CATEGORIA.json");
            carregar_Categoria(wpath + "\\CADASTROS" + "\\CAD_CATEGORIA.json");
            carregar_Classificacao(wpath + "\\CADASTROS" + "\\CAD_CLASSIFICACAO.json");
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
    }
}
