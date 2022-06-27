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
using static Financial.CaixaDeTexto;
using System.Windows;

namespace Financial.Forms
{
    public partial class frmLocaisNovo : Form
    {

        
        public frmLocaisNovo()
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
        string nome_Arquivo = "\\CAD_LOCAL.json";                                           //Nome do arquivo

        Local local = new Local();


        //Carrega o último código adicionado
        private int carregarCodLocal()
        {
            if (Locais.Count > 0)
                return Locais[Locais.Count - 1].idLocal + 1;
            else
                return 1;
        }

        //Salvar local
        void salvar_Local(int Codigo, string Descricao, double Valor, string Observacao)
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;

            if (Descricao.Trim().Equals(String.Empty))
            {
                mm.Message = "O campo " + lblLocal.Text + " não pode estar vazio.";
                mm.Tittle = "Validação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Warning;
                mm.exibirMensagem();
                txtNameLocal.Focus();
                this.Close();

            }

            //Preenchendo os dados da classe
            local.idLocal = Codigo;
            local.nameLocal = Descricao;
            local.valorLocal = Valor;
            local.observacaoLocal = Observacao;

            try
            {
                StreamWriter writer_Local = new StreamWriter(_folder + nome_Arquivo);
                writer_Local.Close();
                if (Locais.Count > 0)
                {
                    Locais.Add(local);
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Locais, Formatting.Indented), Encoding.UTF8);
                }
                else
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(local, Formatting.Indented), Encoding.UTF8);
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
                mm.Message = "Registro salvo com sucesso!";
                mm.Tittle = "Salvar registro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }




        //Load do form
        private void frmLocaisNovo_Load(object sender, EventArgs e)
        {
            //Configurações do Form
            txtIdLocal.ReadOnly = true;

            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = carregarCodLocal()));
            txtIdLocal.Text = lastCode.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtIdLocal)
            {
                if (txtNameLocal.Text.Equals(String.Empty))
                {
                    mm.Message = "O tipo de categoria não pode estar vazio";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }
                
                salvar_Local(Convert.ToInt32(txtIdLocal.Text),txtNameLocal.Text,Convert.ToDouble(txtValorLocal.Text),txtObservacao.Text);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtIdLocal.Text.Trim().Equals(String.Empty))
            {
                mm.Message = "Você deseja cancelar a operação?";
                mm.Tittle = "Cancelar a operação";
                mm.Buttons = MessageBoxButtons.YesNo;
                mm.Icon = MessageBoxIcon.Warning;
                DialogResult result = mm.exibirMensagem();
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }      
    }
}
