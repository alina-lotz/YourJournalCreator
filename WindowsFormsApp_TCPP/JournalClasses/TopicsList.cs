using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class TopicList
    {
        private static TopicList instance = null;
        public static TopicList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TopicList();
                }
                return instance;
            }
        }


        public List<Topic> Topics;
        public TopicList()
        {
            Topics = new List<Topic>();
        }

    }
}
