using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public class Topic
    {
        public string topicName, topicContent;
        public bool readyPhotos, readyForEdit, readyForJournal;
        public DateTime date;
        public List<string> photos;
        public string author;

        public Topic() 
        {
            readyPhotos = false;
            readyForEdit = false;
            readyForJournal = false;
        }
    }
}
