using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0717_03_goto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("프로그램 시작");
            START:
            string text = Console.ReadLine();
            Console.WriteLine(text);
            goto START; // 무한 반복되는 코드
                        // 문자열을 입력받고 그 것을 출력하는 동작을 무한 반복
                        // 내가 원하는 지점으로 가는 것

            // 1. 1부터 100까지의 합을 구해보세요.
          
            // 2. a부터 b까지의 합을 구해보세요.

            // 참고 1부터 n까지의 합공식 n(n+1)/2
        }
    }
}
