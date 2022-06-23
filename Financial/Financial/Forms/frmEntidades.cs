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
using static Financial.Entidade;
namespace Financial.Forms
{
    public partial class frmEntidades : Form
    {
        public frmEntidades()
        {
            InitializeComponent();
        }

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_ENTIDADE.json";                                     //Nome do arquivo

        //Configuração da Grid
        void configuracao_Grid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Entidade", "Cod. Entidade");
                _dgv.Columns.Add("Des_Entidade", "Entidade");
                
            });
        }

        private void carregarEntidade(string path, DataGridView _dgv)
        {
            if (File.Exists(path))
            {
                Entidades.Clear();
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
                            Entidades.Add(new Entidade
                            {
                                idEntidade = Convert.ToInt32(dr["idEntidade"].ToString())
                               ,nomeEntidade = dr["nomeEntidade"].ToString()
                               ,telefoneEntidade = dr["telefoneEntidade"].ToString()
                               ,emailEntidade = dr["emailEntidade"].ToString()
                               ,obsEntidade = dr["obsEntidade"].ToString()
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
                        foreach (var ent in Entidades)
                        {                                     
                            if (ent != null)
                                _dgv.Rows.Add(ent.idEntidade, ent.nomeEntidade);
                        }
                    });
                }
            }
        }



        private void frmEntidades_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            Formulario.configuracaoPadrao(this);


            configuracao_Grid(dgvDados);
            carregarEntidade(wpath + folder + nome_Arquivo, dgvDados);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void abrirClassificacoes()
        {
            Application.Run(new frmClassificacoes());
        }

        private void btnClassificacoes_Click(object sender, EventArgs e)
        {
            Thread tAbrirClassificacoes = new Thread(abrirClassificacoes);
            tAbrirClassificacoes.SetApartmentState(ApartmentState.STA);
            tAbrirClassificacoes.Start();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmEntidadesNovo form = new frmEntidadesNovo();
            form.ShowDialog();
            dgvDados.Rows.Clear();
            carregarEntidade(wpath + folder + nome_Arquivo, dgvDados);

        }

        private void txtEntidades_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtEntidades.Text) || row.Cells[0].Value.ToString().Contains(txtEntidades.Text))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null) 
            {
                frmEntidadesEditar frmEditar = new frmEntidadesEditar();
                frmEditar.codEntidade = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEditar.nomeEntidade = dgvDados.CurrentRow.Cells[1].Value.ToString();
                
                foreach (var item in Entidades)
                {
                    if (item.idEntidade == Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString()))
                    {
                        frmEditar.telefoneEntidade = item.telefoneEntidade;
                        frmEditar.emailEntidade = item.emailEntidade;
                        frmEditar.obsEntidade = item.obsEntidade;
                    }
                }                                               
                frmEditar.ShowDialog();
            }
        }
    }
}
