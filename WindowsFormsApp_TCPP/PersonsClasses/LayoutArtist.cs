using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class LayoutArtist
    {
        public LayoutArtist() { }
        public static LayoutArtist instance = null;
        public static LayoutArtist Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LayoutArtist();
                }
                return instance;
            }
        }
        public string Name, Password;
    }
}
