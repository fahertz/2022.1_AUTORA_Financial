using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Entidade_Classificacao;
using static Financial.Classificacao;
using static Financial.Entidade;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Financial.Forms
{
    public partial class frmEntidadesEditar : Form
    {
        public frmEntidadesEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_ArquivoEntidade = "\\CAD_ENTIDADE.json";                                           //Nome do arquivo
        string nome_ArquivoEntidade_Classificacao = "\\CAD_ENTIDADE_CLASSIFICACAO.json";                            //Nome do arquivo 2

        Entidade entidade = new Entidade();
        Entidade_Classificacao ent_class = new Entidade_Classificacao();

        public int codEntidade { get; set; }
        public string nomeEntidade { get; set; }
        public string telefoneEntidade { get; set; }
        public string emailEntidade { get; set; }
        public string obsEntidade { get; set; }

        List<int> lCod_Classificacao = new List<int>();
        
        private void configurar_Grid(DataGridView _dgv)
        {
            _dgv.Rows.Clear();
            _dgv.Columns.Clear();
            _dgv.Columns.Add("idClassificacao", "Cod. Classificação");
            _dgv.Columns.Add("descClassificacao", "Classificação");
        }

        private void salvar_Entidade(int idEntidade, string nomeEntidade, [Optional] DataGridView _dgvClassificacoes, [Optional] string telefoneEntidade, [Optional] string emailEntidade, [Optional] string obsEntidade)
        {

            //Flag usada para controalr as validações
            int insert = 0;
            if (dgvDados.Rows.Count == 0)
            {
                mm.Message = "Adicione pelo menos uma classificação a entidade.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Exclamation;
                mm.exibirMensagem();
                return;
            }

            if (txtDescEntidade.Text.ToString().Trim().Equals(String.Empty))
            {
                mm.Message = "A entidade não pode estar sem descrição.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Exclamation;
                mm.exibirMensagem();
                return;
            }

            if (mtxTelefone.Text.Trim().Equals(String.Empty) || txtEmail.Text.ToString().Trim().Equals(String.Empty)
                || txtObservacao.Text.ToString().Trim().Equals(String.Empty))
            {
                mm.Message = "Existem campos que não estão devidamente preenchidos, deseja salvar mesmo assim?";
                mm.Tittle = "Campos não preenchidos";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                {
                    insert = 1;
                }
                else
                    return;
            }
            else
            {
                insert = 1;

            }

            if (insert == 1)
            {
                //Caminho da aplicação + nome da pasta
                string _folder = wpath + folder;

                //Inserção entidade
                try
                {
                    //Preenchendo os dados da classe
                    entidade.idEntidade = idEntidade;
                    entidade.nomeEntidade = nomeEntidade;
                    entidade.telefoneEntidade = telefoneEntidade;
                    entidade.emailEntidade = emailEntidade;
                    entidade.obsEntidade = obsEntidade;

                    StreamWriter writerEntidade = new StreamWriter(_folder + nome_ArquivoEntidade);
                    writerEntidade.Close();


                    if (Entidades.Count > 0)
                    {
                        Entidades.Add(entidade);
                        File.WriteAllText(_folder + nome_ArquivoEntidade, JsonConvert.SerializeObject(Entidades, Formatting.Indented), Encoding.UTF8);
                    }
                    else
                        File.WriteAllText(_folder + nome_ArquivoEntidade, JsonConvert.SerializeObject(entidade, Formatting.Indented), Encoding.UTF8);
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

                //Inserção da Entidade_Classificacao
                try
                {
                    List<Entidade_Classificacao> transicaoEntidades_Classificacao = new List<Entidade_Classificacao>();
                    //Preenchendo os dados da classe
                    ent_class.idEntidade = idEntidade;
                    foreach (DataGridViewRow row in dgvDados.Rows)
                    {
                        ent_class.idClassificacao = Convert.ToInt32(row.Cells[0].Value.ToString());
                        transicaoEntidades_Classificacao.Add((Entidade_Classificacao)ent_class.Clone());
                    }
                    StreamWriter writer = new StreamWriter(_folder + nome_ArquivoEntidade_Classificacao);
                    writer.Close();

                    foreach (var item in transicaoEntidades_Classificacao)
                    {
                        Entidades_Classificacoes.Add(item);

                    }
                    File.WriteAllText(_folder + nome_ArquivoEntidade_Classificacao, JsonConvert.SerializeObject(Entidades_Classificacoes, Formatting.Indented), Encoding.UTF8);

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



                //Mensagem de entidade inserida com sucesso!
                mm.Message = "Entidade " + txtDescEntidade.Text + " inserida com sucesso!";
                mm.Tittle = "Informação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();

            }

        }

        void deletar_Entidade(int codigo)
        {
            string _folder = wpath + folder;
            for (int x=0; x<Entidades.Count;x++)
            {
                if (codigo == Entidades[x].idEntidade)
                {
                    Entidades.Remove(Entidades[x]);
                    break;
                }
            }

            try
            {
                StreamWriter writer_Entidade = new StreamWriter(_folder + nome_ArquivoEntidade);
                writer_Entidade.Close();
                if (Entidades.Count > 0)
                {
                    File.WriteAllText(_folder + nome_ArquivoEntidade, JsonConvert.SerializeObject(Entidades, Formatting.Indented), Encoding.UTF8);
                }
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
                if (Entidades.Count == 0)
                    File.Delete(_folder + nome_ArquivoEntidade);                                
            }

        }

        void deletar_Entidade_Classificacao(int codEntidade,List<int> codClassificacao)
        {
            string _folder = wpath + folder;
            for (int x = 0; x < Entidades_Classificacoes.Count; x++)
            {
                foreach (var item in codClassificacao) 
                {
                    if (codEntidade == Entidades_Classificacoes[x].idEntidade && item == Entidades_Classificacoes[x].idClassificacao)
                    {
                        Entidades_Classificacoes.Remove(Entidades_Classificacoes[x]);
                        break;
                    }
                }
            }

            try
            {
                StreamWriter writer_Entidades_Classificacao = new StreamWriter(_folder + nome_ArquivoEntidade_Classificacao);
                writer_Entidades_Classificacao.Close();
                if (Entidades_Classificacoes.Count > 0)
                {
                    File.WriteAllText(_folder + nome_ArquivoEntidade_Classificacao, JsonConvert.SerializeObject(Entidades_Classificacoes, Formatting.Indented), Encoding.UTF8);
                }
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
                if (Entidades_Classificacoes.Count == 0)
                    File.Delete(_folder + nome_ArquivoEntidade_Classificacao);
                mm.Message = "Registro deletado com sucesso!";
                mm.Tittle = "Deletar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }

        

        private void frmEntidadesEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodEntidade.ReadOnly = true;
            Formulario.configuracaoPadrao(this);


            //Dados herdados
            txtCodEntidade.Text = codEntidade.ToString();
            txtDescEntidade.Text = nomeEntidade;
            mtxTelefone.Text = telefoneEntidade;
            txtEmail.Text = emailEntidade;
            txtObservacao.Text = obsEntidade;

            //herdar dados de classificação
            foreach (var item in Entidades_Classificacoes)
            {
                if (item.idEntidade == codEntidade)
                lCod_Classificacao.Add(item.idClassificacao);
            }

            configurar_Grid(dgvDados);


            foreach (var classificacao in Classificacoes) 
            {
                foreach (var cod_Class_Entidade in lCod_Classificacao)
                {
                    if (classificacao.idClassificacao == cod_Class_Entidade)
                        dgvDados.Rows.Add(classificacao.idClassificacao,classificacao.nomeClassificacao);
                }
                
            }
             

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int flg_Divergente = 0;
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (!lCod_Classificacao.Contains(Convert.ToInt32(row.Cells[0].Value.ToString())))
                {
                    flg_Divergente = 1;
                }

            }



            if (txtDescEntidade.Text.Equals(nomeEntidade) && mtxTelefone.Text.Equals(telefoneEntidade) && txtEmail.Text.Equals(emailEntidade) && txtObservacao.Text.Equals(obsEntidade) && lCod_Classificacao.Count == dgvDados.Rows.Count && flg_Divergente == 0)
            {
                this.Close();
            }
            else
            {
                mm.Message = "Você deseja cancelar a operação?";
                mm.Tittle = "Cancelar a operação";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                    this.Close();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar_Entidade(Convert.ToInt32(txtCodEntidade.Text), txtDescEntidade.Text, dgvDados, mtxTelefone.Text, txtEmail.Text, txtObservacao.Text);
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {

            mm.Message = "Você deseja deletar o registro?";
            mm.Tittle = "Deletar registro";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                deletar_Entidade(codEntidade);
                deletar_Entidade_Classificacao(codEntidade, lCod_Classificacao);
                this.Close();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmClassificacoesAux form = new frmClassificacoesAux();
            foreach (var item in Classificacoes)
            {
                int flg_Check = 0;
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item.idClassificacao.ToString()))
                    {
                        form.clb_Back.Items.Add(item.idClassificacao + "|" + item.nomeClassificacao, true);
                        flg_Check = 1;
                    }
                }
                if (flg_Check != 1)
                    form.clb_Back.Items.Add(item.idClassificacao + "|" + item.nomeClassificacao, false);
            }
            form.ShowDialog();
            foreach (var item in form.clb_Back.CheckedItems)
            {
                string[] item_Split = item.ToString().Split('|');
                int flg_Block = 0;

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item_Split[0]))
                    {
                        flg_Block = 1;
                    }
                }
                if (flg_Block != 1)
                    dgvDados.Rows.Add(item_Split[0].ToString(), item_Split[1].ToString());
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows != null)
            {
                foreach (DataGridViewRow row in dgvDados.SelectedRows)
                {
                    dgvDados.Rows.Remove(row);
                }
            }
        }
    }
}
