using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_02
{
    public class Dog : Animal
    {
        public string masterName { get; set; }
        public void bark()
        {
            Console.WriteLine("멍멍멍");
        }
    }
}
