using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("안녕"[0]);
            Console.WriteLine("안녕"+"하세요");
            Console.WriteLine(1+2+3); //ctrl d 코드 한 줄 복사&붙여넣기
            Console.WriteLine(1+2+"3");
            Console.WriteLine("1"+2+3);
            Console.WriteLine('1'+2+3);
            Console.WriteLine("안녕 내 나이는 " +1989+"년 생이야");
            Console.WriteLine($"안녕 내 나이는 {2024-1989}살이야");
            Console.WriteLine
                (string.Format("내 나이는 {0}살이야, {1}년생!",2024-1989,1989));

            int a = int.MaxValue; //2147483647
            Console.WriteLine(a);
            a = a + 1;
            Console.WriteLine(a); //오버 플로우
            long b = 2147483647;
            b = b + 1;
            Console.WriteLine( b);

            //int aa = 0;
            //int bb = 1;
            //Console.WriteLine(++aa + b++ + ++a);
            //aa = 0;
            //aa++;
            //Console.WriteLine( aa);
            //if(a==10)
            //{
            //    Console.WriteLine(  "a는 10이다!");
            //}

            Console.WriteLine("당신의 이름은?");
            string name = Console.ReadLine();
            Console.WriteLine("당신이 태어난 달은?");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine( $"내 이름은 {name}, 나는 {month}월에 태어남" );

        }
    }
}
