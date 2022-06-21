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

namespace Financial.Forms
{
    public partial class frmCadastros : Form
    {
        public frmCadastros()
        {
            InitializeComponent();
        }




        //Load do form
        private void frmCadastros_Load(object sender, EventArgs e)
        {
            //Classe estática para as configurações padrão do formulário
            Formulario.configuracaoPadrao(this);
        }


        //Fechar a tela
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void abrirTipoCategoria()
        {
            Application.Run(new frmTipoCategoria());
        }

        private void btnTipoCategoria_Click(object sender, EventArgs e)
        {
            Thread tTipoCategoria = new Thread(abrirTipoCategoria);
            tTipoCategoria.SetApartmentState(ApartmentState.STA);
            tTipoCategoria.Start();
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



        private void abrirClassificacoes()
        {
            Application.Run(new frmClassificacoes());
        }


        private void btnClassificacoes_Click(object sender, EventArgs e)
        {
            Thread tAbrirClassificacoes = new Thread(abrirClassificacoes);
            tAbrirClassificacoes.SetApartmentState(ApartmentState.STA);
            tAbrirClassificacoes.Start();
        }
    }
}
