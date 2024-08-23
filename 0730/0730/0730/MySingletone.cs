using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0730
{
    public class MySingletone
    {
        private MySingletone() { Console.WriteLine("Test"); }
        private static MySingletone instance;
        public static MySingletone getlnstance()
        {
            if (instance == null)   
                instance = new MySingletone();  
            return instance;
        }
    }
}
