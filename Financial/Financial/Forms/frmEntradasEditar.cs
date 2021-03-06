using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.EntradaFinanceira;
using static Financial.Entidade;
using static Financial.Categoria_Financeira.Categoria;
using static Financial.Local;
using System.Threading;

namespace Financial.Forms
{
    public partial class frmEntradasEditar : Form
    {
        public frmEntradasEditar()
        {
            InitializeComponent();
            
            txtCodEntidade.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodCategoria.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtCodLocalArmazenamento.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtParcelas.KeyPress += CaixaDeTexto.txt_justInt_KeyPress;
            txtValor.KeyPress += CaixaDeTexto.txt_justDouble_KeyPress;
            txtValor.Validating += CaixaDeTexto.txt_convertDouble_Validated;
        }

        //Instância local
        Mensagem mm = new Mensagem();        
        EntradaFinanceira entrada = new EntradaFinanceira();

        //Instância pública
        public int idOperacao { get; set; }

        //Load do form
        private void carregar_Entrada(int idOperacao)
        {
            var select_Entrada_Campos = from entradas in Entradas_Financeiras
                                        join entidade in Entidades
                                        on entradas.idEntidade equals entidade.idEntidade
                                        join categoria in Categorias
                                        on entradas.idCategoria equals categoria.idCategoria
                                        join local in Locais
                                        on entradas.idLocal equals local.idLocal


                                        where entradas.idOperacao == idOperacao
                                        select new
                                        {
                                            entradas.idOperacao
                                                    ,
                                            entidade.idEntidade
                                                    ,
                                            entidade.nomeEntidade
                                                    ,
                                            categoria.idCategoria
                                                    ,
                                            categoria.descCategoria
                                                    ,
                                            entradas.dataMovimento
                                                    ,
                                            entradas.valorTransacao
                                                    ,
                                            entradas.numParcela
                                                    ,
                                            entradas.formaMovimento
                                                    ,
                                            entradas.idLocal
                                                    ,
                                            local.nameLocal
                                                    ,
                                            entradas.obsMovimento
                                                    ,
                                            entradas.statusMovimento
                                                    ,
                                            entradas.dataBaixa
                                        };
            var select_Entrada_Anterior = from entradas in Entradas_Financeiras
                                          where entradas.idOperacao == idOperacao
                                          select entradas;

            foreach (var entrada_anterior in select_Entrada_Anterior)
            {
                entrada = entrada_anterior;
            }


            foreach (var entrada in select_Entrada_Campos)
            {
                txtCodEntidade.Text = entrada.idEntidade.ToString();
                txtDescEntidade.Text = entrada.nomeEntidade;
                txtCodCategoria.Text = entrada.idCategoria.ToString();
                txtDescCategoria.Text = entrada.descCategoria;
                dtpDataBase.Value = entrada.dataMovimento;
                txtValor.Text = entrada.valorTransacao.ToString("C");
                txtParcelas.Text = entrada.numParcela.ToString();
                cbxFormaPagamento.Text = entrada.formaMovimento;
                txtCodLocalArmazenamento.Text = entrada.idLocal.ToString();
                txtDescLocalArmazenamento.Text = entrada.nameLocal;
                txtObservacao.Text = entrada.obsMovimento;
                if (entrada.statusMovimento == 'A')
                {
                    lblStatus.Text = "Status: " + entrada.statusMovimento;
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
                    lblStatus.Text = "Status: " + entrada.statusMovimento + " | " + entrada.dataBaixa.ToShortDateString();
                }
            }
        }
        private void frmEntradaNovo_Load(object sender, EventArgs e)
        {
            Formulario.configuracaoPadrao(this);
            carregar_Entrada(idOperacao);

            //Bloqueios
            txtDescEntidade.ReadOnly = true;
            txtDescCategoria.ReadOnly = true;
            txtCodLocalArmazenamento.ReadOnly = true;
            txtDescLocalArmazenamento.ReadOnly = true;
            txtObservacao.ReadOnly = true;

            //Carregar
            lblID.Text = lblID.Text + idOperacao.ToString();

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
                   entrada.idEntidade.ToString().Equals(txtCodEntidade.Text)
                && entrada.idLocal.ToString().Equals(txtCodLocalArmazenamento.Text)
                && entrada.idCategoria.ToString().Equals(txtCodCategoria.Text)
                && entrada.numParcela.ToString().Equals(txtParcelas.Text)
                && entrada.valorTransacao.ToString().Equals(txtValor.Text)
                && entrada.formaMovimento.ToString().Equals(cbxFormaPagamento.SelectedItem.ToString())                 
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
                    entrada.statusMovimento = 'F';
                    entrada.dataBaixa = DateTime.Now;                    
                    EntradaFinanceira.editar(entrada);
                    Local.incremetar_Saldo(entrada.idLocal, entrada.valorTransacao);
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
                    EntradaFinanceira.editar(entrada);
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
                    EntradaFinanceira.deletar(entrada.idOperacao);
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
                frmEntradasEditarObs frmObs = new frmEntradasEditarObs();
                frmObs.ShowDialog();
                if (frmObs.flg_Obs == 1)
                {
                    try
                    {                                            
                        txtObservacao.Text = frmObs.txtObservacao.Text;
                        entrada.statusMovimento = 'F';
                        entrada.dataBaixa = DateTime.Now;
                        entrada.obsMovimento = txtObservacao.Text;
                        EntradaFinanceira.editar(entrada);
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
