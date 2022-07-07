using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Financial.SaidaFinanceira;
using static Financial.Entidade;
using static Financial.Categoria_Financeira.Categoria;
using static Financial.Local;
using System.Windows.Forms;
using System.Threading;

namespace Financial.Forms
{
    public partial class frmSaidasEditar : Form
    {
        public frmSaidasEditar()
        {
            InitializeComponent();
            txtCodEntidade.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodCategoria.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodLocalArmazenamento.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtParcelas.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtValor.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
            txtValor.Validating += CaixaDeTexto.txt_convertDouble_Validated;
        }

        private void frmSaidasEditar_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
            carregar_Saida(idOperacao);

            //Bloqueios
            txtDescEntidade.ReadOnly = true;
            txtDescCategoria.ReadOnly = true;
            txtCodLocalArmazenamento.ReadOnly = true;
            txtDescLocalArmazenamento.ReadOnly = true;
            txtObservacao.ReadOnly = true;

            //Carregar
            lblID.Text = lblID.Text + idOperacao.ToString();
        }

        //Instância local
        Mensagem mm = new Mensagem();
        SaidaFinanceira saida = new SaidaFinanceira();

        //Instância pública
        public int idOperacao { get; set; }

        //Load do form
        private void carregar_Saida(int idOperacao)
        {
            var select_Saida_Campos = from saidas in Saidas_Financeiras
                                        join entidade in Entidades
                                        on saidas.idEntidade equals entidade.idEntidade
                                        join categoria in Categorias
                                        on saidas.idCategoria equals categoria.idCategoria
                                        join local in Locais
                                        on saidas.idLocal equals local.idLocal


                                        where saidas.idOperacao == idOperacao
                                        select new
                                        {
                                            saidas.idOperacao
                                                    ,
                                            entidade.idEntidade
                                                    ,
                                            entidade.nomeEntidade
                                                    ,
                                            categoria.idCategoria
                                                    ,
                                            categoria.descCategoria
                                                    ,
                                            saidas.dataMovimento
                                                    ,
                                            saidas.valorTransacao
                                                    ,
                                            saidas.numParcela
                                                    ,
                                            saidas.formaMovimento
                                                    ,
                                            saidas.idLocal
                                                    ,
                                            local.nameLocal
                                                    ,
                                            saidas.obsMovimento
                                                    ,
                                            saidas.statusMovimento
                                                    ,
                                            saidas.dataBaixa
                                        };
            var select_Saida_Anterior = from saidas in Saidas_Financeiras
                                          where saidas.idOperacao == idOperacao
                                          select saidas;

            foreach (var saida_anterior in select_Saida_Anterior)
            {
                saida = saida_anterior;
            }


            foreach (var saida in select_Saida_Campos)
            {
                txtCodEntidade.Text = saida.idEntidade.ToString();
                txtDescEntidade.Text = saida.nomeEntidade;
                txtCodCategoria.Text = saida.idCategoria.ToString();
                txtDescCategoria.Text = saida.descCategoria;
                dtpDataBase.Value = saida.dataMovimento;
                txtValor.Text = saida.valorTransacao.ToString("C");
                txtParcelas.Text = saida.numParcela.ToString();
                cbxFormaPagamento.Text = saida.formaMovimento;
                txtCodLocalArmazenamento.Text = saida.idLocal.ToString();
                txtDescLocalArmazenamento.Text = saida.nameLocal;
                txtObservacao.Text = saida.obsMovimento;
                if (saida.statusMovimento == 'A')
                {
                    lblStatus.Text = "Status: " + saida.statusMovimento;
                    lblStatus.ForeColor = Color.OrangeRed;
                }
                else
                {
                    txtCodEntidade.Enabled = false;
                    txtCodCategoria.Enabled = false;
                    dtpDataBase.Enabled = false;
                    txtValor.Enabled = false;
                    txtParcelas.Enabled = false;
                    cbxFormaPagamento.Enabled = false;
                    txtCodLocalArmazenamento.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnDeletar.Enabled = false;
                    btnBaixarcSaldo.Enabled = false;
                    btnBaixarsSaldo.Enabled = false;
                    lblStatus.Text = "Status: " + saida.statusMovimento + " | " + saida.dataBaixa.ToShortDateString();
                }
            }
        }
        
        //Botões e suas configurações
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
        private void abrirLocal()
        {
            Application.Run(new frmLocais());
        }
        private void btnLocal_Click(object sender, EventArgs e)
        {
            Thread tAbrirLocal = new Thread(abrirLocal);
            tAbrirLocal.SetApartmentState(ApartmentState.STA);
            tAbrirLocal.Start();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (
                   saida.idEntidade.ToString().Equals(txtCodEntidade.Text)
                && saida.idLocal.ToString().Equals(txtCodLocalArmazenamento.Text)
                && saida.idCategoria.ToString().Equals(txtCodCategoria.Text)
                && saida.numParcela.ToString().Equals(txtParcelas.Text)
                && saida.valorTransacao.ToString().Equals(txtValor.Text)
                && saida.formaMovimento.ToString().Equals(cbxFormaPagamento.SelectedItem.ToString())
                )
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
        private void btnBaixar_Click(object sender, EventArgs e)
        {


            mm.Message = "Tem certeza que deseja dar baixa nesse recebimento?";
            mm.Tittle = "Baixar recebimento";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();

            if (result == DialogResult.Yes)
            {
                try
                {
                    saida.statusMovimento = 'F';
                    saida.dataBaixa = DateTime.Now;
                    SaidaFinanceira.editar(saida);
                    Local.incremetar_Saldo(saida.idLocal, saida.valorTransacao);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    mm.Message = "Registro baixado com sucesso!";
                    mm.Tittle = "Salvar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            mm.Message = "Salvar edições?";
            mm.Tittle = "Editar recebimento";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();

            if (result == DialogResult.Yes)
            {
                try
                {
                    SaidaFinanceira.editar(saida);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    mm.Message = "Registro editado com sucesso!";
                    mm.Tittle = "Salvar registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            mm.Message = "Deletar registro?";
            mm.Tittle = "Deletar recebimento";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();

            if (result == DialogResult.Yes)
            {
                try
                {
                    SaidaFinanceira.deletar(saida.idOperacao);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    mm.Message = "Registro excluído com sucesso!";
                    mm.Tittle = "Excluir registro";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Information;
                    mm.exibirMensagem();
                    this.Close();
                }
            }
        }
        private void btnBaixarsSaldo_Click(object sender, EventArgs e)
        {
            mm.Message = "Tem certeza que deseja dar baixa nesse recebimento?";
            mm.Tittle = "Baixar recebimento";
            mm.Buttons = MessageBoxButtons.YesNo;
            mm.Icon = MessageBoxIcon.Question;
            DialogResult result = mm.exibirMensagem();

            if (result == DialogResult.Yes)
            {
                frmSaidasEditarObs frmObs = new frmSaidasEditarObs();
                frmObs.ShowDialog();
                if (frmObs.flg_Obs == 1)
                {
                    try
                    {
                        txtObservacao.Text = frmObs.txtObservacao.Text;
                        saida.statusMovimento = 'F';
                        saida.dataBaixa = DateTime.Now;
                        saida.obsMovimento = txtObservacao.Text;
                        SaidaFinanceira.editar(saida);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        mm.Message = "Registro baixado com sucesso!";
                        mm.Tittle = "Salvar registro";
                        mm.Buttons = MessageBoxButtons.OK;
                        mm.Icon = MessageBoxIcon.Information;
                        mm.exibirMensagem();
                        this.Close();
                    }
                }
            }
        }
    }
}
