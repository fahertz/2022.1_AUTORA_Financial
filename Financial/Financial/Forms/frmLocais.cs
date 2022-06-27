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
using static Financial.Local;

namespace Financial.Forms
{
    public partial class frmLocais : Form
    {
        public frmLocais()
        {
            InitializeComponent();
           
        }

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_LOCAL.json";


        //Configuração da Grid
        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Local", "Cod. Local");
                _dgv.Columns.Add("Des_Local", "Local");                
            });
        }

        void carregarLocal(string path, DataGridView _dgv)
        {
            if (File.Exists(path))
            {
                Locais.Clear();
                StreamReader reader = new StreamReader(path);
                string linhasDoArquivo = reader.ReadToEnd();

                try
                {
                    Locais.Add((Local)JsonConvert.DeserializeObject(linhasDoArquivo, (typeof(Local)))); ;
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
                finally
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        foreach (var loc in Locais)
                        {                            
                            if (loc != null)
                                _dgv.Rows.Add(loc.idLocal, loc.nameLocal);
                        }
                    });
                }
            }
        }

       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmLocaisNovo frmNovo = new frmLocaisNovo();
            frmNovo.ShowDialog();
            dgvDados.Rows.Clear();
            carregarLocal(wpath + folder + nome_Arquivo, dgvDados);

        }

        private void frmLocais_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            Formulario.configuracaoPadrao(this);


            configuracao_Grid(dgvDados);
            carregarLocal(wpath + folder + nome_Arquivo, dgvDados);
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLocal_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtLocal.Text) || row.Cells[0].Value.ToString().Contains(txtLocal.Text) || row.Cells[3].Value.ToString().Contains(txtLocal.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmLocaisEditar frmEditar = new frmLocaisEditar();
                frmEditar.idLocal = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.nomeLocal = dgvDados.CurrentRow.Cells[1].Value.ToString();

                foreach (var item in Locais)
                {
                    if (item.idLocal == Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString()))
                    {
                        frmEditar.valorLocal = item.valorLocal;
                        frmEditar.obsLocal = item.observacaoLocal;
                        
                    }
                }
                frmEditar.ShowDialog();
                dgvDados.Rows.Clear();
                carregarLocal(wpath + folder + nome_Arquivo, dgvDados);                
            }
        }
    }
}
