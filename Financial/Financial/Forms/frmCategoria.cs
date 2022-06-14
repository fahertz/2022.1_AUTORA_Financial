using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static Financial.Categoria_Financeira;
using Newtonsoft.Json;

namespace Financial.Forms
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_CATEGORIA.json";                                     //Nome do arquivo

        //Configuração da Grid
        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Categoria", "Cod. Categoria");
                _dgv.Columns.Add("Des_Categoria", "Categoria");
                _dgv.Columns.Add("Cod_TipoCategoria", "Cod. Tipo Categoria");
                _dgv.Columns.Add("Des_Categoria", "Tipo Categoria");
            });
        }

        void carregarCategoria(string path, DataGridView _dgv)
        {
            if (File.Exists(path))
            {
                Categorias.Clear();
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
                finally
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        foreach (var cat in Categorias)
                        {
                            string descTipo_Categoria= null;
                            foreach (var tip_cat in Tipos_Categoria)
                            {
                                if (cat.idTipo_Categoria == tip_cat.idTipo_Categoria)
                                {
                                    descTipo_Categoria = tip_cat.descTipo_Categoria;
                                }
                            }
                            if (cat != null)
                                _dgv.Rows.Add(cat.idCategoria, cat.descCategoria, cat.idTipo_Categoria, descTipo_Categoria);
                        }
                    });
                }
            }
            }


        //Abrir tipo de Categoria
        void abrirTipoCategoria()
        {
        Application.Run(new frmTipoCategoria());
        }
        private void btnTipoCategoria_Click(object sender, EventArgs e)
        {
            Thread tAbrirTipoCategoria = new Thread(abrirTipoCategoria);
            tAbrirTipoCategoria.SetApartmentState(ApartmentState.STA);
            tAbrirTipoCategoria.Start();
        }


        //Botão novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCategoriaNovo frmNovo = new frmCategoriaNovo();
            frmNovo.ShowDialog();
            dgvDados.Rows.Clear();
            carregarCategoria(wpath+folder+nome_Arquivo,dgvDados);

        }


        //Fechar form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            configuracao_Grid(dgvDados);
            carregarCategoria(wpath+folder+nome_Arquivo,dgvDados);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmCategoriaNovo frmEditar = new frmCategoriaNovo();

            frmEditar.ShowDialog();
            dgvDados.Rows.Clear();
            carregarCategoria(wpath + folder + nome_Arquivo, dgvDados);
        }
    }
}

