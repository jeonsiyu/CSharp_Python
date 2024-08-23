using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp011
{
    public class MySingletone
    {
        private MySingletone() { Console.WriteLine("Test"); }
        private static MySingletone instance;
        public static MySingletone getInstance()
        {
            if(instance == null)
                instance = new MySingletone();
            return instance;
        }
    }
}
