using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Categoria_Financeira;
using static Financial.Categoria_Financeira.Tipo_Categoria;
using static Financial.Categoria_Financeira.Categoria;


namespace Financial
{
    public class Categoria_Financeira
    {

        static Mensagem mm = new Mensagem();
        
        //Caminhos de uso
        static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        public static string nome_Arquivo { get; set; }


        public class Tipo_Categoria : Categoria_Financeira
        {
            //Instância pública
            public int idTipo_Categoria { get; set; }
            public string descTipo_Categoria { get; set; }
            public static List<Tipo_Categoria> Tipos_Categoria = new List<Tipo_Categoria>();

            //Métodos de resgate
            public static int obterUltimoCodigo()
            {
                if (Tipos_Categoria.Count > 0)
                    return Tipos_Categoria[Tipos_Categoria.Count - 1].idTipo_Categoria + 1;
                else
                    return 1;
            }

            //Métodos de Manipulação
            private static void salvar()
            {
                //Nome do arquivo
                nome_Arquivo = "\\CAD_TIPO_CATEGORIA.json";            
                
                try
                {
                    StreamWriter writer_TipoCategoria = new StreamWriter(wpath + folder + nome_Arquivo);
                    writer_TipoCategoria.Close();
                    if (Tipos_Categoria.Count > 0)
                        File.WriteAllText(wpath + folder + nome_Arquivo, JsonConvert.SerializeObject(Tipos_Categoria, Formatting.Indented), Encoding.UTF8);                    
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
            public static void adicionar(dynamic Codigo, dynamic Descricao)
            {
                Tipos_Categoria.Add(new Tipo_Categoria { idTipo_Categoria = Convert.ToInt32(Codigo), descTipo_Categoria = Descricao});
                salvar();
            }
            public static void editar(dynamic Codigo, dynamic Descricao)
            {
                foreach (var item in Tipos_Categoria)
                {
                    if (item.idTipo_Categoria == Convert.ToInt32(Codigo))
                    {
                        item.descTipo_Categoria = Descricao;                        
                        break;
                    }
                }
                salvar();
            }
            public static int deletar(dynamic Codigo)
            {
                foreach (var item in Categorias)
                {                  
                    if (item.idTipo_Categoria == Convert.ToInt32(Codigo))
                        return 0;                    
                }

                foreach (var item in Tipos_Categoria)
                {
                    if (item.idTipo_Categoria == Convert.ToInt32(Codigo))
                    {
                        Tipos_Categoria.Remove(item);
                        break;
                    }
                }
                
                if (Tipos_Categoria.Count > 0)
                {
                    salvar();
                    return 1;
                }
                else
                {
                    File.Delete(folder + nome_Arquivo);
                    return 1;
                }
            }

            //Métodos de visualização
            private static void configurarGrid(DataGridView _dgv)
            {
                _dgv.Invoke((MethodInvoker)delegate
                {                    
                    _dgv.Columns.Add("Cod_TipoCategoria", "Cod. Tipo Categoria");
                    _dgv.Columns.Add("Des_Categoria", "Tipo Categoria");
                });
            }
            public static void carregar(DataGridView _dgv)
            {
                _dgv.Columns.Clear();
                _dgv.Rows.Clear();
                configurarGrid(_dgv);
                var query = from tipo_categoria in Tipos_Categoria                                                        
                            select new
                            {                                
                                tipo_categoria.idTipo_Categoria
                                ,tipo_categoria.descTipo_Categoria
                            };


                foreach (var item in query)
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        _dgv.Rows.Add(item.idTipo_Categoria, item.descTipo_Categoria);
                    });
                }

            }
        }

        public class Categoria : Categoria_Financeira
        {         

            //Instância pública
            public int idCategoria { get; set; }
            public string descCategoria { get; set; }
            public int idTipo_Categoria { get; set; }

            //Lista de dados estáticos
            public static List<Categoria> Categorias = new List<Categoria>();
            
            //Métodos de resgate
            public static int obterUltimoCodigo()
            {
                if (Categorias.Count > 0)
                    return Categorias[Categorias.Count - 1].idCategoria + 1;
                else
                    return 1;
            }

            //Métodos de Manipulação
            private static void salvar()
            {
                //Nome do arquivo
                nome_Arquivo = "\\CAD_CATEGORIA.json";                                           

                //Caminho da aplicação + nome da pasta
                string _folder = wpath + folder;                
                try
                {
                    StreamWriter writer_Categoria = new StreamWriter(_folder + nome_Arquivo);
                    writer_Categoria.Close();
                    if (Categorias.Count > 0)
                    {                        
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
            public static void adicionar(dynamic Codigo, dynamic Descricao, dynamic codTpCat)
            {
                Categorias.Add(new Categoria { idCategoria = Convert.ToInt32(Codigo), descCategoria = Descricao, idTipo_Categoria = Convert.ToInt32(codTpCat) });
                salvar();
            }
            public static void editar(dynamic Codigo, dynamic Descricao, dynamic codTpCat)
            {                
                foreach (var item in Categorias)
                {
                    if (item.idCategoria == Convert.ToInt32(Codigo))
                    {
                        item.descCategoria = Descricao;
                        item.idTipo_Categoria = Convert.ToInt32(codTpCat);
                        break;
                    }
                }
                salvar();                
            }
            public static void deletar(dynamic Codigo)
            {
                foreach (var item in Categorias)
                {
                    if (item.idCategoria == Convert.ToInt32(Codigo))
                    {
                        Categorias.Remove(item);
                        break;
                    }
                }
                if (Categorias.Count > 0)
                {
                    salvar();
                }
                else
                {
                    File.Delete(folder + nome_Arquivo);
                }                
            }

            //Métodos de visualização
            private static void configurarGrid(DataGridView _dgv)
            {
                _dgv.Invoke((MethodInvoker)delegate
                {
                    _dgv.Columns.Add("Cod_Categoria", "Cod. Categoria");
                    _dgv.Columns.Add("Des_Categoria", "Categoria");
                    _dgv.Columns.Add("Cod_TipoCategoria", "Cod. Tipo Categoria");
                    _dgv.Columns.Add("Des_Categoria", "Tipo Categoria");
                });
            }
            public static void carregar(Object _obj)
            {

                if (_obj is DataGridView)
                {
                    DataGridView _dgv = (DataGridView)_obj;

                    _dgv.Columns.Clear();
                    _dgv.Rows.Clear();

                    configurarGrid(_dgv);
                    var query_Categoria = 
                                from categoria in Categorias
                                join tipo_categoria in Tipos_Categoria
                                on new
                                {
                                    categoria.idTipo_Categoria
                                }
                                equals new
                                {
                                    tipo_categoria.idTipo_Categoria
                                }
                                select new
                                {
                                     categoria.idCategoria
                                    ,categoria.descCategoria
                                    ,categoria.idTipo_Categoria
                                    ,tipo_categoria.descTipo_Categoria
                                };


                    foreach (var item in query_Categoria)
                    {
                        _dgv.Invoke((MethodInvoker)delegate
                        {
                            _dgv.Rows.Add(item.idCategoria, item.descCategoria, item.idTipo_Categoria, item.descTipo_Categoria);
                        });
                    }

                }
            }
        }
    }
}
