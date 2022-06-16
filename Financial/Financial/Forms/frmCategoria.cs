using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using static Financial.Categoria_Financeira;
using Newtonsoft.Json;
using System.Drawing;

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
                            Categorias.Add(new Categoria { idCategoria      = Convert.ToInt32(dr["idCategoria"].ToString())
                                                          ,descCategoria    = dr["descCategoria"].ToString()
                                                          ,idTipo_Categoria = Convert.ToInt32(dr["idTipo_Categoria"].ToString()) });
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
        
        private void btnTipoCategoria_Click(object sender, EventArgs e)
        {
            frmTipoCategoria frmTipoCategoria = new frmTipoCategoria();
            frmTipoCategoria.ShowDialog();
            dgvDados.Rows.Clear();
            carregarCategoria(wpath+folder+nome_Arquivo,dgvDados);
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
            //Configurações da Tela
            
            this.MaximizeBox = false;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);


            configuracao_Grid(dgvDados);
            carregarCategoria(wpath+folder+nome_Arquivo,dgvDados);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null) 
            {
                frmCategoriaEditar frmEditar = new frmCategoriaEditar();
                frmEditar.CodCategoria = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.DesCategoria = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.CodTipCategoria = Convert.ToInt32(dgvDados.CurrentRow.Cells[2].Value.ToString());
                frmEditar.ShowDialog();
                dgvDados.Rows.Clear();
                carregarCategoria(wpath + folder + nome_Arquivo, dgvDados);
            }
        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtCategoria.Text) || row.Cells[0].Value.ToString().Contains(txtCategoria.Text) || row.Cells[3].Value.ToString().Contains(txtCategoria.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }
    }
}

