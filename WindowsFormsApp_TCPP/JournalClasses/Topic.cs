using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP.JournalClasses
{
    public sealed class Topic
    {
        private static Topic instance = null;
        public static Topic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Topic();
                }
                return instance;
            }
        }

        public string topicName, topicContent;
        public bool readyContent, readyPhotos, readyForEdit;
        //public List<>
    }
}