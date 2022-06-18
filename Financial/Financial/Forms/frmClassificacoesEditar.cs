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
    public partial class frmClassificacoesEditar : Form
    {
        public frmClassificacoesEditar()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_CLASSIFICACAO.json";                                     //Nome do arquivo


        //Instância dos dados
        public string CodClassificacao { get; set; }
        public string DesClassificacao { get; set; }

        //Salvar categoria
        void salvar_Categoria(int Codigo, string Descricao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblClassificacao.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Warning;
                mm.exibirMensagem();
                txtClassificacao.Focus();
                return;
            }

            for (int x = 0; x < Classificacoes.Count; x++)
            {
                if (Codigo == Classificacoes[x].idClassificacao)
                {
                    Classificacoes[x].nomeClassificacao = Descricao;
                    break;
                }
            }

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Classificacoes.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Classificacoes, Formatting.Indented), Encoding.UTF8);
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
                mm.Message = "Registro alterado com sucesso!";
                mm.Tittle = "Editar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }

        //Remover classificação
        void deletar_Classificacao(int Codigo)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            for (int x = 0; x < Classificacoes.Count; x++)
            {
                if (Codigo == Classificacoes[x].idClassificacao)
                {
                    Classificacoes.Remove(Classificacoes[x]);
                    break;
                }
            }

            try
            {
                StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                writer_Produtos.Close();
                if (Classificacoes.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Classificacoes, Formatting.Indented), Encoding.UTF8);
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
                if (Classificacoes.Count == 0)
                    File.Delete(_folder + nome_Arquivo);
                mm.Message = "Registro deletado com sucesso!";
                mm.Tittle = "Deletar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }

        private void frmClassificacoesEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtCodClassificacao.ReadOnly = true;
            Formulario.configuracaoPadrao(this);


            //Dados herdados
            txtCodClassificacao.Text = CodClassificacao;
            txtClassificacao.Text = DesClassificacao;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja salvar a operação?";
            mm.Tittle = "Salvar a operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Warning;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                salvar_Categoria(Convert.ToInt32(txtCodClassificacao.Text), txtClassificacao.Text);
                this.Close();
            }
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
                foreach (var item in Classificacoes)
                {
                    if (Convert.ToInt32(txtCodClassificacao.Text) == item.idClassificacao)
                    {
                        mm.Message = "Impossível deletar, registro associado. Verifique a qual categoria o tipo está associado.";
                        mm.Tittle = "Deletar registro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Warning;
                        mm.exibirMensagem();
                        return;
                    }
                }
                deletar_Classificacao(Convert.ToInt32(txtCodClassificacao.Text));
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Equals(DesClassificacao))
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
    }
}
