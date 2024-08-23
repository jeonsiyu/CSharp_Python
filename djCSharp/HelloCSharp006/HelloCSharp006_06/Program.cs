using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp006_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle();
            r1.width = 10;
            r1.height = 3;

            Rectangle r2 = new Rectangle() { width=5,height=7};
            Console.WriteLine(r1.getArea());
            Console.WriteLine(r2.getArea());
            Console.WriteLine(Rectangle.getArea(8, 4)) ;
        }
    }
}
