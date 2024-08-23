using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_03
{
    public class Dog : Animal
    {
        public string masterName {  get; set; } 
        public void bark()
        {
            Console.WriteLine("멍멍멍");
        }
        public override void cry()
        {
            Console.WriteLine("머머머머멍");
        }
    }
}
