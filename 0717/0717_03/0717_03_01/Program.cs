using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0717_03_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1Inch 단위를 입력받아 cm단위를 구하는 코드 작성
            Console.WriteLine("1번 문제. inch를 입력하세요.");
            int inch = int.Parse(Console.ReadLine());
            Console.WriteLine($"{inch}inch = {2.54 * inch}cm");
            Console.WriteLine(inch + "inch = " + (2.54 * inch) + "cm");
            Console.WriteLine(string.Format("{0}inch = {1}cm", inch, (2.54 * inch)));

            //java 상수 final, c에서는 상수 const 혹은 readonly
            //상수는 보통 대문자로 표기하며, 가독성을 위해서 사용됨
            double POUND = 2.20462262; //2번 문제용
            double PI = 3.14; //3번 문제용
            Console.WriteLine("2번. kg을 입력하세요.");
            int kg = int.Parse(Console.ReadLine());
            Console.WriteLine($"{kg}kg = {kg * POUND}pound");
            Console.WriteLine("3번. 반지름(r)을 입력해주세요.");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine($"둘레={2 * PI * r}, 넓이={r * r * PI}");

            Console.WriteLine("첫 번째 숫자 입력");
            string num1 = Console.ReadLine();
            Console.WriteLine("두 번째 숫자 입력");
            string num2 = Console.ReadLine();

            //나머지와 나눗셈을 이용한 방법
            int n1 = int.Parse(num1);
            int n2 = int.Parse(num2);
            Console.WriteLine(n1 * (n2 % 10));
            Console.WriteLine(n1 * ((n2 / 10) % 10));
            Console.WriteLine(n1 * (n2 / 100));
            Console.WriteLine(n1 * n2);
            //ASCII코드를 이용하는 방법
            Console.WriteLine(n1 * (num2[2] - '0'));
            Console.WriteLine(n1 * (num2[1] - 48));
            Console.WriteLine(n1 * (num2[0] - 48));

            Console.WriteLine("마지막 문제");
            int a = int.Parse(Console.ReadLine());
            int b = (a * 5) % 7;
            int c = (b * 5) % 7;
            int d = (c * 5) % 7;
            int e = (d * 5) % 7;
            int f = (e * 5) % 7;
            Console.WriteLine($"{a} {b} {c} {d} {e} {f}");

        }
    }
}
