using System.Drawing;
using System.Windows.Forms;

namespace Financial
{
    public static class Formulario
    {
        public static void configuracaoPadrao(Form form)
        {                        
            form.MaximizeBox = false;
            form.MinimumSize = new Size(form.Size.Width, form.Size.Height);
            form.MaximumSize = new Size(form.Size.Width, form.Size.Height);
        }      
    }
}
