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
using static Financial.Classificacao;

namespace Financial.Forms
{
    public partial class frmClassificacoes : Form
    {
        public frmClassificacoes()
        {
            InitializeComponent();
        }
        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_CLASSIFICACAO.json";                                     //Nome do arquivo


        //Configuração da Grid
        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Classificacao", "Cod. Classificação");
                _dgv.Columns.Add("Des_Classificação", "Classificação");
            });
        }

        //Carregando Classificação
        void carregarClassificacoes(string path, DataGridView _dgv)
        {
            if (File.Exists(path))
            {
                Classificacoes.Clear();
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
                            Classificacoes.Add(new Classificacao { idClassificacao = Convert.ToInt32(dr["idClassificacao"].ToString()), nomeClassificacao = dr["nomeClassificacao"].ToString() });
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
                        foreach (var item in Classificacoes)
                        {
                            if (item != null)
                                _dgv.Rows.Add(item.idClassificacao.ToString(), item.nomeClassificacao);
                        }
                    });
                }
            }
        }


        //Load do form
        private void frmClassificacoes_Load(object sender, EventArgs e)
        {
            //Configurações do Form
            Formulario.configuracaoPadrao(this);

            configuracao_Grid(dgvDados);
            Task.Factory.StartNew(() => carregarClassificacoes(wpath + folder + nome_Arquivo, dgvDados));
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmClassificacoesNovo form = new frmClassificacoesNovo();
            form.ShowDialog();
            dgvDados.Rows.Clear();
            carregarClassificacoes(wpath + folder + nome_Arquivo, dgvDados);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                frmClassificacoesEditar frmEditar = new frmClassificacoesEditar();
                frmEditar.CodClassificacao = dgvDados.CurrentRow.Cells[0].Value.ToString();
                frmEditar.DesClassificacao = dgvDados.CurrentRow.Cells[1].Value.ToString();
                frmEditar.ShowDialog();
                dgvDados.Rows.Clear();
                carregarClassificacoes(wpath + folder + nome_Arquivo, dgvDados);
            }
        }

        private void txtClassificacao_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtClassificacao.Text) || row.Cells[0].Value.ToString().Contains(txtClassificacao.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);

        }
    }
}
