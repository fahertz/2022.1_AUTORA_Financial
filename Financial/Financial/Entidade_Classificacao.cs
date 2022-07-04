using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Classificacao;

namespace Financial
{
    public class Entidade_Classificacao : ICloneable
    {

        static Mensagem mm = new Mensagem();
        
        //Instância de atributos privados
        private static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        private static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        private static string nome_Arquivo = "\\CAD_CLASSIFICACAO_ENTIDADE.json";                             //Nome do arquivo

        //Instância de atributos públicos
        public int idEntidade { get; set; }
        public int idClassificacao { get; set; }        

        //Instância de dados
        public static List<Entidade_Classificacao> Entidades_Classificacoes = new List<Entidade_Classificacao>();

        //Clone para manipulação via Classe
        public object Clone()
        {
            return new Entidade_Classificacao() { idEntidade = this.idEntidade, idClassificacao = this.idClassificacao };
        }

        //Métodos de manipulação
        private static void salvar()
        {
            try
            {
                //Abre o Writer para escrever o arquivo no caminho especificado
                StreamWriter writer_EntidadeClassificacao = new StreamWriter(wpath + folder + nome_Arquivo);
                writer_EntidadeClassificacao.Close();

                //Se a quantidade de item não estiver vazia, ele cria o arquivo, a trava existe para que não haja brechas para gerar um arquivo vazio
                if (Entidades_Classificacoes.Count > 0)
                    File.WriteAllText(wpath + folder + nome_Arquivo, JsonConvert.SerializeObject(Entidades_Classificacoes, Formatting.Indented), Encoding.UTF8);
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
        public static void adicionar(dynamic Codigo_Entidade, dynamic Codigo_Classificacao)
        {
            Entidades_Classificacoes.Add(new Entidade_Classificacao { idEntidade =  Convert.ToInt32(Codigo_Entidade), idClassificacao = Convert.ToInt32(Codigo_Classificacao) });
            salvar();
        }
        public static void editar (dynamic Codigo_Entidade, object _obj)
        {
         
            if (_obj is DataGridView)
            {
                DataGridView _dgv = (DataGridView)_obj;
               Entidade_Classificacao.deletar(Codigo_Entidade);

                foreach (DataGridViewRow _row in _dgv.Rows)
                {
                    Entidade_Classificacao.adicionar(Codigo_Entidade,_row.Cells[0].Value);
                }
            }


        }
        public static int deletar(dynamic Codigo_Entidade)
        {

            List <Entidade_Classificacao> remover = new List <Entidade_Classificacao>();
            foreach (var item in Entidades_Classificacoes)
            {
                if (item.idEntidade == Convert.ToInt32(Codigo_Entidade))
                {
                    remover.Add(item);
                }
            }

            foreach (var item in remover)
                Entidades_Classificacoes.Remove(item);

            if (Entidades_Classificacoes.Count > 0)
            {
                salvar();
                return 1;
            }
            else
            {
                File.Delete(wpath + folder + nome_Arquivo);
                return 1;
            }

        }

    }

}
