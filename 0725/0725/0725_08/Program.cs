using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0725_08
{
    internal class Program
    {
    static void printA()
    {
        for(int i = 0; i < 100; i++)
        {
            Console.WriteLine('A');
        }
    }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(printA); //using System.Threading;
            Thread t2 = new Thread(delegate ()
            {
                for (int i = 0; i < 100; i++)
                    Console.Write('B');
            });
            Thread t3 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                    Console.Write('C');
            });
            //t1 t2 t3가 시간을 분할하므로 A와 B와 C가 뒤죽박죽 섞여서 출력이 될 것
            t1.Start();
            t2.Start();
            t3.Start();


        }
    }
}
