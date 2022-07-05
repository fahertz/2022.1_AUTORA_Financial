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
using static Financial.Categoria_Financeira.Categoria;
using static Financial.Categoria_Financeira.Tipo_Categoria;
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
            txtValor.Validating += CaixaDeTexto.txt_convertDouble_Validated;



            txtDescEntidade.TextChanged += txtObservacaoTexto_TextChanged;
            txtDescCategoria.TextChanged += txtObservacaoTexto_TextChanged;
            txtValor.TextChanged += txtObservacaoTexto_TextChanged;
            txtParcelas.TextChanged += txtObservacaoTexto_TextChanged;
            txtDescLocalArmazenamento.TextChanged += txtObservacaoTexto_TextChanged;

            cbxFormaPagamento.TextChanged += txtObservacaoTexto_TextChanged;
            dtpDataBase.TextChanged += txtObservacaoTexto_TextChanged;
        }


        Mensagem mm = new Mensagem();

        EntradaFinanceira entradaFinanceira = new EntradaFinanceira();        


        



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
            cbxFormaPagamento.Items.Add("Cartão de Crédito");
            cbxFormaPagamento.Items.Add("Cartão de Débito");
            cbxFormaPagamento.Items.Add("Dinheiro");
            cbxFormaPagamento.Text = "PIX";

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
        private void salvar_Entrada(dynamic idEntidade, dynamic idLocal, dynamic idCategoria, dynamic numParcela, dynamic valorTransacao, string formaPagamento, string obsMovimento, DateTime dataMovimento, char statusMovimento)
        {
            entradaFinanceira.idOperacao = MovimentoFinanceiro.obterUltimoCodigo(entradaFinanceira.Clone());                        
            entradaFinanceira.idEntidade = Convert.ToInt32(idEntidade);
            entradaFinanceira.idLocal = Convert.ToInt32(idLocal);
            entradaFinanceira.idCategoria = Convert.ToInt32(idCategoria);            
            entradaFinanceira.valorTransacao = Convert.ToDouble(valorTransacao) / Convert.ToDouble(numParcela);
            entradaFinanceira.formaMovimento = formaPagamento;
            entradaFinanceira.obsMovimento = obsMovimento;
            entradaFinanceira.dataMovimento = dataMovimento;
            entradaFinanceira.tipoMovimento = "Entrada";
            entradaFinanceira.statusMovimento = statusMovimento;

            for (int x=0; x<Convert.ToInt32(numParcela);x++)
            {
                entradaFinanceira.numParcela = Convert.ToInt32(x+1);
                entradaFinanceira.idOperacao = entradaFinanceira.idOperacao + 1;






                if (chkDiasUteis.Checked) 
                {
                    if (dtpDataBase.Value.AddDays(x * 30).DayOfWeek.ToString() == "Sunday")
                    {
                        entradaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30).AddDays(1);
                    }
                    else if (dtpDataBase.Value.AddDays(x * 30).DayOfWeek.ToString() == "Saturday")
                    {
                        entradaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30).AddDays(2);
                    }
                    else                             
                    {                        
                        entradaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30);
                    }
                }
                else
                {
                    entradaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30);
                }

                if (chkBaixaAutomatica.Checked)
                {
                    EntradaFinanceira.adicionar((EntradaFinanceira)entradaFinanceira.Clone());
                    Local.incremetar_Saldo(idLocal,valorTransacao);
                }
                else
                {
                    EntradaFinanceira.adicionar((EntradaFinanceira)entradaFinanceira.Clone());
                }

            }
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
            
            try
                
            {
                if (!chkBaixaAutomatica.Checked)
                {
                    salvar_Entrada(txtCodEntidade.Text, txtCodLocalArmazenamento.Text, txtCodCategoria.Text, txtParcelas.Text, txtValor.Text, cbxFormaPagamento.SelectedItem.ToString(), txtObservacao.Text, Convert.ToDateTime(dtpDataBase.Value.ToShortDateString()), 'A');
                }
                else
                {
                    salvar_Entrada(txtCodEntidade.Text, txtCodLocalArmazenamento.Text, txtCodCategoria.Text, txtParcelas.Text, txtValor.Text, cbxFormaPagamento.SelectedItem.ToString(), txtObservacao.Text, Convert.ToDateTime(dtpDataBase.Value.ToShortDateString()), 'F');
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
            finally
            {                
                mm.Message = "Entrada inserida com sucesso!";
                mm.Tittle = "Informação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }

        
        //txt Descrição Entidade
        private void txtObservacaoTexto_TextChanged(object sender, EventArgs e)
        {
                txtObservacao.Text = "A Entidade {" + txtCodEntidade.Text + " | " + txtDescEntidade.Text + "}" +
                    ", para a Categoria {" + txtCodCategoria.Text + " | " + txtDescCategoria.Text + "} irá pagar R$ " + txtValor.Text + " a partir da "
                    + dtpDataBase.Value.ToLongDateString()+" em " + txtParcelas.Text + "x no " + cbxFormaPagamento.SelectedItem?.ToString() 
                    + ". O local movimentado será o {" + txtCodLocalArmazenamento.Text + " | " + txtDescLocalArmazenamento.Text + "}.";
            
        }

        private void chkBaixaAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox _chk = (CheckBox)sender;
                if (_chk.Checked)
                {
                    txtParcelas.Text = "1";
                    txtParcelas.ReadOnly = true;
                }
                else
                {
                    txtParcelas.ReadOnly = false;
                }                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
