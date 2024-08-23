using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_04
{
    public class Dog : Animal
    {

        public override void cry()
        {
            Console.WriteLine("멍멍~~~");
            //base.cry();
        }
    }
}
