using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_01
{
    internal class Test2
    {
        public static int power(int x) // 클래스 메서드임 -> 왜? static이 있음
        {
            return x * x;
        }
        public static int Multi(int x, int y)
        {
            return x * y;
        }
        public static void print()
        {
            Console.WriteLine("메시지를 출력합니다.");
        }
    }
}
