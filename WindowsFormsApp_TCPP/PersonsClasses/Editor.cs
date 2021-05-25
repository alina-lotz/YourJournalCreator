using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class Editor
    {
        public Editor() { }
        private static Editor instance = null;
        public static Editor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Editor();
                }
                return instance;
            }
        }
        public string Name, Password;
    }
}
