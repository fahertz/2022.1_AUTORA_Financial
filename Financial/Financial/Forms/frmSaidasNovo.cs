using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Local;
using static Financial.Categoria_Financeira.Categoria;
using static Financial.Entidade;


namespace Financial.Forms
{
    public partial class frmSaidasNovo : Form
    {
        public frmSaidasNovo()
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


        //Instância local
        Mensagem mm = new Mensagem();
        SaidaFinanceira saidaFinanceira = new SaidaFinanceira();

        //Load do form
        private void frmSaidasNovo_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);

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
        }


        //Botões e suas configurações
        private void abrirCategoria()
        {
            Application.Run(new frmCategoria());
        }
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Thread tAbrirCategoria = new Thread(abrirCategoria);
            tAbrirCategoria.SetApartmentState(ApartmentState.STA);
            tAbrirCategoria.Start();
        }
        private void abrirEntidades()
        {
            Application.Run(new frmEntidades());
        }
        private void btnEntidades_Click(object sender, EventArgs e)
        {
            Thread tAbrirEntidades = new Thread(abrirEntidades);
            tAbrirEntidades.SetApartmentState(ApartmentState.STA);
            tAbrirEntidades.Start();
        }
        private void abrirLocal()
        {
            Application.Run(new frmLocais());
        }
        private void btnLocal_Click(object sender, EventArgs e)
        {
            Thread tAbrirLocais = new Thread(abrirLocal);
            tAbrirLocais.SetApartmentState(ApartmentState.STA);
            tAbrirLocais.Start();
        }
        private void salvar_Saida(dynamic idEntidade, dynamic idLocal
                                 , dynamic idCategoria, dynamic numParcela
                                 , dynamic valorTransacao, string formaPagamento
                                 , string obsMovimento
                                 , DateTime dataMovimento
                                 , char statusMovimento)
        {
            saidaFinanceira.idOperacao = MovimentoFinanceiro.obterUltimoCodigo(saidaFinanceira.Clone());
            saidaFinanceira.idEntidade = Convert.ToInt32(idEntidade);
            saidaFinanceira.idLocal = Convert.ToInt32(idLocal);
            saidaFinanceira.idCategoria = Convert.ToInt32(idCategoria);
            saidaFinanceira.valorTransacao = Convert.ToDouble(valorTransacao) / Convert.ToDouble(numParcela);
            saidaFinanceira.formaMovimento = formaPagamento;
            saidaFinanceira.obsMovimento = obsMovimento;
            saidaFinanceira.dataMovimento = dataMovimento;

            saidaFinanceira.tipoMovimento = "Saida";
            saidaFinanceira.statusMovimento = statusMovimento;

            for (int x = 0; x < Convert.ToInt32(numParcela); x++)
            {
                saidaFinanceira.numParcela = Convert.ToInt32(x + 1);
                saidaFinanceira.idOperacao = saidaFinanceira.idOperacao + 1;

                if (chkDiasUteis.Checked)
                {
                    if (dtpDataBase.Value.AddDays(x * 30).DayOfWeek.ToString() == "Sunday")
                    {
                        saidaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30).AddDays(1);
                    }
                    else if (dtpDataBase.Value.AddDays(x * 30).DayOfWeek.ToString() == "Saturday")
                    {
                        saidaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30).AddDays(2);
                    }
                    else
                    {
                        saidaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30);
                    }
                }
                else
                {
                    saidaFinanceira.dataMovimento = dtpDataBase.Value.AddDays(x * 30);
                }

                if (chkBaixaAutomatica.Checked)
                {
                    saidaFinanceira.dataBaixa = DateTime.Now;
                    SaidaFinanceira.adicionar((SaidaFinanceira)saidaFinanceira.Clone());
                    Local.decrementar_Saldo(idLocal, valorTransacao);
                }
                else
                {
                    SaidaFinanceira.adicionar((SaidaFinanceira)saidaFinanceira.Clone());
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try

            {
                if (!chkBaixaAutomatica.Checked)
                {
                    salvar_Saida(txtCodEntidade.Text, txtCodLocalArmazenamento.Text, txtCodCategoria.Text, txtParcelas.Text, txtValor.Text, cbxFormaPagamento.SelectedItem.ToString(), txtObservacao.Text, Convert.ToDateTime(dtpDataBase.Value.ToShortDateString()), 'A');
                }
                else
                {
                    salvar_Saida(txtCodEntidade.Text, txtCodLocalArmazenamento.Text, txtCodCategoria.Text, txtParcelas.Text, txtValor.Text, cbxFormaPagamento.SelectedItem.ToString(), txtObservacao.Text, Convert.ToDateTime(dtpDataBase.Value.ToShortDateString()), 'F');
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
                mm.Message = "Sa inserida com sucesso!";
                mm.Tittle = "Informação";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Information;
                mm.exibirMensagem();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mm.Message = "Deseja cancelar a operação?";
            mm.Tittle = "Cancelar operação";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //Texts boxes 
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
        private string filtrarDescClassificacao(dynamic _codCategoria)
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

        //Função genérica para preencher a observação
        private void txtObservacaoTexto_TextChanged(object sender, EventArgs e)
        {
            txtObservacao.Text = "Será pago a Entidade {" + txtCodEntidade.Text + " | " + txtDescEntidade.Text + "}" +
                ", para a Categoria {" + txtCodCategoria.Text + " | " + txtDescCategoria.Text + "}, o valor de R$ " + txtValor.Text + " a partir da "
                + dtpDataBase.Value.ToLongDateString() + " em " + txtParcelas.Text + "x no " + cbxFormaPagamento.SelectedItem?.ToString()
                + ". O local movimentado será o {" + txtCodLocalArmazenamento.Text + " | " + txtDescLocalArmazenamento.Text + "}.";
        }

        //Checked boxes
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

    }
}
