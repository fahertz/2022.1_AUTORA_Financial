using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Categoria_Financeira.Tipo_Categoria;
using static Financial.Categoria_Financeira;

namespace Financial.Forms
{
    public partial class frmCategoriaNovo : Form
    {
        public frmCategoriaNovo()
        {
            InitializeComponent();
        }

        Mensagem mm = new Mensagem();
         
        private void frmCategoriaNovo_Load(object sender, EventArgs e)
        {
             //Configurações do Form
            txtCodCategoria.ReadOnly = true;

            //Caracteristicas do form
            Formulario.configuracaoPadrao(this);

            //Definindo o código Inicial do processo            
            int lastCode = 0;
            Task.WaitAny(Task.Factory.StartNew(() => lastCode = Categoria.obterUltimoCodigo()));
            txtCodCategoria.Text = lastCode.ToString();            
        }


        //Carrega o tipo de categoria ao digitar
        private void txtCodTipoCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var tipos in Tipos_Categoria)
                {
                    if (Convert.ToInt32(txtCodTipoCategoria.Text) == tipos.idTipo_Categoria)
                    {
                        txtDescTipoCategoria.Text = tipos.descTipo_Categoria;
                        break;
                    }
                    else
                    {
                        txtDescTipoCategoria.Text = String.Empty;                       
                    }
                }
            }
            catch
            {
                txtCodTipoCategoria.Text = String.Empty;
                txtDescTipoCategoria.Text = String.Empty;
            }
        }


        //Botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar informações
            lock (txtCodCategoria)
            {
                if (txtDescTipoCategoria.Text.Equals(String.Empty))
                {
                    mm.Message = "O tipo de categoria não pode estar vazio";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }

                int block = 1;
                foreach (var tipo in Tipos_Categoria)
                {
                    if (tipo.descTipo_Categoria.ToUpper().Equals(txtDescTipoCategoria.Text.ToUpper()))
                        block = 0;
                }

                if (block == 1)
                {
                    mm.Message = "Tipo de categoria inválida";
                    mm.Tittle = "Tipo categoria";
                    mm.Buttons = MessageBoxButtons.OK;
                    mm.Icon = MessageBoxIcon.Warning;
                    DialogResult result = mm.exibirMensagem();
                    return;
                }
                try
                {
                    Categoria.adicionar(txtCodCategoria.Text, txtDescCategoria.Text, txtCodTipoCategoria.Text);
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
        }

        //Botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!txtDescCategoria.Text.Trim().Equals(String.Empty))
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
