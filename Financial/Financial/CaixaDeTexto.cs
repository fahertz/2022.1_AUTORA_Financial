using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial
{
    public class CaixaDeTexto
    {

        
        public static void txt_justDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                // temporary invalid inputs like "1," are allowed
                if ((e.KeyChar < 32) || (e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ','))
                    return;

                // only evident errors (like 'A' or '&') are restricted
                e.Handled = true;
            }
        }

        public static void txt_justInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                // temporary invalid inputs like "1," are allowed
                if ((e.KeyChar < 32) || (e.KeyChar >= '0') && (e.KeyChar <= '9'))
                    return;

                // only evident errors (like 'A' or '&') are restricted
                e.Handled = true;
            }
        }

        public static void txt_convertDouble_Validated (object sender, CancelEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox ss = (TextBox)sender;
                try
                {
                    ss.Text = String.Format("{0:#0.00}", Convert.ToDouble(ss.Text));                                        
                }
                catch 
                {
                    ss.Text = String.Format("{0:#0.00}", 0);
                }
            }
        }


    }
}
