using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial
{
    public class Mensagem
    {
        public string Message { get; set; }
        public string Tittle { get; set; }
        public MessageBoxIcon Icon { get; set; }
        public MessageBoxButtons Buttons { get; set; }



        public DialogResult exibirMensagem()
        {
           return MessageBox.Show(Message, Tittle, Buttons, Icon);
        }

    }
}
