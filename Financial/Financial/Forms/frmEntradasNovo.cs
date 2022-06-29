using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static Financial.Entidade;
using static Financial.CaixaDeTexto;
using static Financial.Mensagem;
using static Financial.Categoria_Financeira;
using static Financial.Local;

namespace Financial.Forms
{
    public partial class frmEntradasNovo : Form
    {

        public frmEntradasNovo()
        {
            InitializeComponent();
            txtCodEntidade.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodCategoria.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodLocalArmazenamento.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtParcelas.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;

            txtValor.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
        }


        Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        string folder_Operacoes = "\\" + "OPERACOES";                                                    //Nome do diretório das operações        
        string nome_Arquivo_Entradas = "\\OPE_ENTRADA.json";                                           //Nome do arquivo de entradas
        
        MovimentoFinanceiro entradaFinanceira = new MovimentoFinanceiro();        


        //Abrir categoria
        void abrirCategoria()
        {
            Application.Run(new frmCategoria());
            
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Thread tAbrirCategoria = new Thread(abrirCategoria);
            tAbrirCategoria.SetApartmentState(ApartmentState.STA);
            tAbrirCategoria.Start();
        }


        private void frmEntradasNovo_Load(object sender, EventArgs e)
        {
            //Carregar formas de pagamento
            cbxFormaPagamento.Items.Add("PIX");
            cbxFormaPagamento.Items.Add("Cartão Crédito");
            cbxFormaPagamento.Items.Add("Cartão Débito");
            cbxFormaPagamento.Items.Add("Dinheiro");


            //Carregar bloqueios iniciais
            txtDescEntidade.ReadOnly = true;            
            txtDescCategoria.ReadOnly = true;
            txtDescLocalArmazenamento.ReadOnly = true;



            Formulario.configuracaoPadrao(this);
        }

        private void btnEntidades_Click(object sender, EventArgs e)
        {
            frmEntidades frmEntidades = new frmEntidades();
            frmEntidades.ShowDialog();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            frmLocais frmLocais = new frmLocais();
            frmLocais.ShowDialog();
        }



        //Salvar entrada
        private void salvar_Entrada(int idEntidade, int idLocal, int idCategoria, int numParcelas, double valorTransacao, string formaPagamento, string obsMovimento, DateTime dataMovimento, char statusMovimento)
        {

        }

        //Filtros
        private string filtrarDescEntidade(dynamic _codEntidade)
        {            
            try
            {
                _codEntidade = Convert.ToInt32(_codEntidade);
                foreach (var entidade in Entidades)
                {
                    if (entidade.idEntidade == _codEntidade)
                    {
                        return entidade.nomeEntidade;
                        
                    }

                }
            }
            catch
            {
                return null;
            }
            return null;

        }

        private string filtrarDescClassificacao (dynamic _codCategoria)
        {
            try
            {
                _codCategoria = Convert.ToInt32(_codCategoria);
                foreach (var categoria in Categorias)
                {
                    if (categoria.idCategoria == _codCategoria)
                    {
                        return categoria.descCategoria;

                    }

                }
            }
            catch
            {
                return null;
            }
            return null;

        }

        private string filtrarDescLocal(dynamic _codLocal)
        {
            try
            {
                _codLocal = Convert.ToInt32(_codLocal);
                foreach (var local in Locais)
                {
                    if (local.idLocal == _codLocal)
                    {
                        return local.nameLocal;

                    }

                }
            }
            catch
            {
                return null;
            }
            return null;

        }


        private void txtCodEntidade_TextChanged(object sender, EventArgs e)
        {                     
            txtDescEntidade.Text = filtrarDescEntidade(txtCodEntidade.Text);                                
        }

        private void txtCodCategoria_TextChanged(object sender, EventArgs e)
        {
            txtDescCategoria.Text = filtrarDescClassificacao(txtCodCategoria.Text);
        }

        private void txtCodLocalArmazenamento_TextChanged(object sender, EventArgs e)
        {
            txtDescLocalArmazenamento.Text = filtrarDescLocal(txtCodLocalArmazenamento.Text);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Local.incremetar_Saldo(txtCodLocalArmazenamento.Text,txtValor.Text);
        }
    }
}
