using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //다형성에도 인터페이스가 적용됨
            IPlant c = new Bulbasaur();
            //IPlant cc = new IPlant(); //인터페이스 단독으론 인스턴스 못 만듦
        }
    }
}
