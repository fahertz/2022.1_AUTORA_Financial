using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }
    }
}
