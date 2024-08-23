using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 추상클래스는 단독으로 인스턴스 만들지 못함
            // Animal a = new Animal();
            // 대신에 다형성은 적용 가능함
            Animal cat = new Cat();
            Animal dog = new Dog();

            cat.name = "추운식";
            cat.age = 10;
            Console.WriteLine(cat);//HelloCSharp008_04.Cat
            Console.WriteLine(cat.ToString());//HelloCSharp008_04.Cat


            //AND(&&) , OR(||), XOR(^)  
            //AND : 모두 다 참이어야 참
            //OR : 단 하나라도 참이어 참
            //XOR :  모두 다 똑같으면 거짓, 하나라도 다른 게 있으면 참

            bool b1 = true;
            bool b2 = false;
            bool b3 = true;
            bool b4 = false;
            if (b1 && b2)
                Console.WriteLine("1---AND---");
            if (b1 && b3)
                Console.WriteLine("2---AND---");
            if (b1 || b2)
                Console.WriteLine("3---OR---");
            if (b1 ^ b2)
                Console.WriteLine("4---XOR---(하나라도 다른 게 있어야 함)");
            if (b1 ^ b3)
                Console.WriteLine("5---XOR---(하나라도 다른 게 있어야 함)");
            if (b2 ^ b4)
                Console.WriteLine("6---XOR---(하나라도 다른 게 있어야 함)");
            if (b1 ^ b2 ^ b4)
                Console.WriteLine("7---XOR---(하나라도 다른 게 있어야 함)");

        }
    }
}
