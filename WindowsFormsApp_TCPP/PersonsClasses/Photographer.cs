using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class Photographer
    {
        public Photographer() { }
        public static Photographer instance = null;
        public static Photographer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Photographer();
                }
                return instance;
            }
        }
        public string Name, Password;
    }
}
