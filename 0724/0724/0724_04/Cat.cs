using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_04
{
    internal class Cat : Animal
    {
        public override void cry()
        {
            base.cry(); //base = 조상 클래스
            Console.WriteLine("야옹");
        }
    }
}
