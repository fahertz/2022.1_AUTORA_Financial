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
    public partial class frmLocaisEditar : Form
    {
        public frmLocaisEditar()
        {
            InitializeComponent();
            txtValorLocal.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
            txtValorLocal.Validating += CaixaDeTexto.txt_convertDouble_Validated;
        }


        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        string nome_Arquivo = "\\CAD_LOCAL.json";                                     //Nome do arquivo


        //Instância dos dados
        public int idLocal { get; set; }
        public string nomeLocal { get; set; }
        public double valorLocal { get; set; }
        public string obsLocal { get; set; }


        //Salvar categoria
        void salvar_Local(int Codigo, string Descricao, double Valor, string Observacao )
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblLocal.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Error;
                mm.exibirMensagem();
                txtNameLocal.Focus();
                return;
            }

            

            for (int x = 0; x < Locais.Count; x++)
            {
                if (Codigo == Locais[x].idLocal)
                {
                    Locais[x].nameLocal = Descricao;
                    Locais[x].valorLocal = Valor;
                    Locais[x].observacaoLocal = Observacao;
                    break;
                }
            }

            try
            {
                StreamWriter writer_Locais = new StreamWriter(_folder + nome_Arquivo);
                writer_Locais.Close();
                if (Locais.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Locais, Formatting.Indented), Encoding.UTF8);
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
        //Remover categoria
        void deletar_Categoria(int Codigo)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            for (int x = 0; x < Locais.Count; x++)
            {
                if (Codigo == Locais[x].idLocal)
                {
                    Locais.Remove(Locais[x]);
                    break;
                }
            }

            try
            {
                StreamWriter writer_Locais = new StreamWriter(_folder + nome_Arquivo);
                writer_Locais.Close();
                if (Locais.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Locais, Formatting.Indented), Encoding.UTF8);
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
                if (Locais.Count == 0)
                    File.Delete(_folder + nome_Arquivo);
                mm.Message = "Registro deletado com sucesso!";
                mm.Tittle = "Deletar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }


        private void frmLocaisEditar_Load(object sender, EventArgs e)
        {
            //Configurações da Tela
            txtIdLocal.ReadOnly = true;
            Formulario.configuracaoPadrao(this);                                    
            
            //Dados herdados
            txtIdLocal.Text = idLocal.ToString();
            txtNameLocal.Text = nomeLocal;
            txtValorLocal.Text = valorLocal.ToString();
            txtObservacao.Text = obsLocal;
            txtValorLocal.Text = String.Format("{0:#0.00}", Convert.ToDouble(txtValorLocal.Text));
            //String.Format("{0:00.00}", Convert.ToDouble(ss.Text));
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja deletar o registro?";
            mm.Tittle = "Deletar registro";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                deletar_Categoria(Convert.ToInt32(txtIdLocal.Text));
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mm.Message = "Você deseja salvar a operação?";
            mm.Tittle = "Salvar a operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();
            if (result == DialogResult.Yes)
            {
                salvar_Local(Convert.ToInt32(txtIdLocal.Text), txtNameLocal.Text, Convert.ToDouble(txtValorLocal.Text), txtObservacao.Text);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtNameLocal.Text.Equals(nomeLocal) && txtObservacao.Text.Equals(obsLocal) && txtValorLocal.Text.Equals(valorLocal))
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
