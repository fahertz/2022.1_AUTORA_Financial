using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial
{
    public class Categoria_Financeira
    {

        static Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        static string nome_Arquivo = "\\CAD_CATEGORIA.json";                                           //Nome do arquivo

        public class Tipo_Categoria : Categoria_Financeira
        {
            public int idTipo_Categoria { get; set; }
            public string descTipo_Categoria { get; set; }

        }

        public class Categoria : Categoria_Financeira
        {
         


            public int idCategoria { get; set; }
             public string descCategoria { get; set; }
             public int idTipo_Categoria { get; set; }

            
            public static int getLastCode()
            {
                if (Categorias.Count > 0)
                    return Categorias[Categorias.Count - 1].idCategoria + 1;
                else
                    return 1;
            }

            public static void adicionar_Categoria(dynamic Codigo, dynamic Descricao, dynamic codTpCat)
            {
                //Caminho da aplicação + nome da pasta
                string _folder = wpath + folder;
                try
                {
                    StreamWriter writer_Produtos = new StreamWriter(_folder + nome_Arquivo);
                    writer_Produtos.Close();
                    if (Categorias.Count > 0)
                    {
                        Categorias.Add(new Categoria { idCategoria = Codigo, descCategoria = Descricao, idTipo_Categoria = codTpCat});
                        File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Categorias, Formatting.Indented), Encoding.UTF8);
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
            }

        }

        public static List<Categoria> Categorias = new List<Categoria>();

        public static List<Tipo_Categoria> Tipos_Categoria = new List<Tipo_Categoria>();

        

    }
}
