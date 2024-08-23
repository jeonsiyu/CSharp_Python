using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_03
{
    public class Cat : Animal
    {
        public override void cry()
        {
            base.cry(); //base = 조상 클래스
            Console.WriteLine("야옹");
        }
    }
}
