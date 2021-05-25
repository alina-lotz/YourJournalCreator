using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_TCPP
{
    public sealed class FormsManager
    {
        private static FormsManager instance = null;
        public static FormsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormsManager();
                }
                return instance;
            }
        }

        public List<Form> Forms;

        private FormsManager()
        {
            Forms = new List<Form>();
        }
        
    }
}
