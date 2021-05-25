using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public sealed class Journalist
    {
        public Journalist() { }
        public static Journalist instance = null;
        public static Journalist Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Journalist();
                }
                return instance;
            }
        }
        public string Name, Password;
        public List<string> myTopics = new List<string>();
        public void addTopic()
        {

        }
        public void viewTopics()
        {

        }
    }
}
