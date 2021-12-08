using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Forma.Files
{
    public class Validacija
    {
        public static bool ValidirajKontrolu(Control kontrola, string poruka, ErrorProvider errorP)
        {
            if (string.IsNullOrWhiteSpace(kontrola.Text))
            {
                errorP.SetError(kontrola, poruka);
                return false;
            }
            errorP.Clear();
            return true;
        }
    }
}
