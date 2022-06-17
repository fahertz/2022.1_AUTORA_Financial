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
    public partial class frmTipoCategoria : Form
    {
        public frmTipoCategoria()
        {
            InitializeComponent();
        }
        
        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_TIPO_CATEGORIA.json";                                     //Nome do arquivo


        //Configuração da Grid
        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Categoria", "Cod. Categoria");
                _dgv.Columns.Add("Des_Categoria", "Categoria");
            });
        }

        //Carregando tipo da categoria
        void carregarTipoCategoria(string path, DataGridView _dgv)
        {
            if (File.Exists(path))
            {
                Tipos_Categoria.Clear();
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
                finally
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        foreach (var item in Tipos_Categoria)
                        {
                            if (item != null)
                                _dgv.Rows.Add(item.idTipo_Categoria.ToString(), item.descTipo_Categoria);
                        }
                    });
                }
            }
        }


        //Iniciando nova instância para criar um Tipo de categoria
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTipoCategoriaNovo frmNovo = new frmTipoCategoriaNovo();

            frmNovo.ShowDialog();
            dgvDados.Rows.Clear();            
            carregarTipoCategoria(wpath + folder + nome_Arquivo, dgvDados);
        }


        //Editar um Tipo de categoria
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmTipoCategoriaEditar frmEditar = new frmTipoCategoriaEditar();
                frmEditar.CodCategoria = dgvDados.CurrentRow.Cells[0].Value.ToString();
                frmEditar.DesCategoria = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.ShowDialog();
                dgvDados.Rows.Clear();
                carregarTipoCategoria(wpath + folder + nome_Arquivo, dgvDados);
            }
        }


        //Load do form
        private void frmTipoCategoria_Load(object sender, EventArgs e)
        {
            //Configurações do Form
            Formulario.configuracaoPadrao(this);

            configuracao_Grid(dgvDados);
            Task.Factory.StartNew(() => carregarTipoCategoria(wpath + folder + nome_Arquivo, dgvDados));
        }


       

        
        //Pesquisa por alteração de teste
        private void txtDescCategoria_TextChanged(object sender, EventArgs e)
        {
            
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                if (row.Cells[1].Value.ToString().Contains(txtDescCategoria.Text) || row.Cells[0].Value.ToString().Contains(txtDescCategoria.Text))                
                        row.Visible = true;                
                    else
                        row.Visible = false;
                }            
        }

        //Duplo clique para ativar
        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        //Fecha a tela
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
