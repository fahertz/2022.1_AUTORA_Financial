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
    public partial class frmTipoCategoria : Form
    {
        public frmTipoCategoria()
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


        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Categoria", "Cod. Categoria");
                _dgv.Columns.Add("Des_Categoria", "Categoria");
            });
        }

        void carregarTipoCategoria(string path,DataGridView _dgv)
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
                catch (Exception ex)
                {
                    mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                    mm.Tittle = "Erro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Error;
                    mm.exibirMensagem();                                        
                }                
            }
            finally
            {
                _dgv.Invoke((MethodInvoker)delegate
                {
                    foreach (var item in Tipos_Categoria)
                    {
                        _dgv.Rows.Add(item.idTipo_Categoria.ToString(), item.descTipo_Categoria);
                    }
                });
            }


        }

        private void abrirTipoCategoriaNovo()
        {
            Application.Run(new frmTipoCategoriaNovo());
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            Thread tAbrirTipoCategoriaNovo = new Thread(abrirTipoCategoriaNovo);
            tAbrirTipoCategoriaNovo.SetApartmentState(ApartmentState.STA);
            tAbrirTipoCategoriaNovo.Start();
        }

        private void abrirTipoCategoriaEditar()
        {
            Application.Run(new frmTipoCategoriaEditar());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow.Selected)
            {
                Thread tAbrirTipoCategoriaEditar = new Thread(abrirTipoCategoriaEditar);
                tAbrirTipoCategoriaEditar.SetApartmentState(ApartmentState.STA);
                tAbrirTipoCategoriaEditar.Start();
            }
        }



        //Fechar aplicação
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTipoCategoria_Load(object sender, EventArgs e)
        {
            configuracao_Grid(dgvDados);
            Task.Factory.StartNew(() => carregarTipoCategoria(wpath+folder+nome_Arquivo,dgvDados));
        }

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

        
    }
}
