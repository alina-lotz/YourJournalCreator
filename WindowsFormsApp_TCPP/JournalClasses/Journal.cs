using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public class Journal
    {
        public string journalName, author;
        public List<Topic> journalTopics;
        public DateTime date;
        public bool readyForPrint;

        public Journal()
        {
            journalTopics = new List<Topic>();
            readyForPrint = false;
        }
    }
}
