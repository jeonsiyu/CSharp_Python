using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp003_goto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("프로그램 시작");
            START:
            string text = Console.ReadLine();
            Console.WriteLine(text);
            goto START; //무한 반복되는 코드
            //문자열을 입력받고 그 것을 출력하는 동작을 무한 반복
        }
    }
}
