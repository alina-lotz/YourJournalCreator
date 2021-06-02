using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP.JournalClasses
{
    public class Topic
    {
        public string topicName, topicContent;
        public bool readyContent, readyPhotos, readyForEdit;
        public DateTime date;
        public List<string> photos;
        public string author;

        public Topic() 
        {
            readyContent = false;
            readyPhotos = false;
            readyForEdit = false;
        }
    }
}