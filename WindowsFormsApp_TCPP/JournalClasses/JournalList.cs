using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class JournalList
    {
        public JournalList() { }
        private static JournalList instance = null;
        public static JournalList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JournalList();
                }
                return instance;
            }
        }
        public List<Journal> Journals = new List<Journal>();
    }
}
