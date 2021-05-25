using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_TCPP
{
    public struct Person
    {
        public string Name;
        public string Password;
        public string Role;
    }

    public static class PersonsList
    {
        public static List<Person> persons = new List<Person>();
    } 
}