using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724
{
    internal class Program
    {
        //그냥 재귀 함수 방식
        static long rec_fibo(int n)
        {
            if (n <= 0)
                return 0;
            if (n <= 2)
                return 1;
            return rec_fibo(n - 2) + rec_fibo(n - 1);
        }
        //Dictionary 활용한 방식
        static Dictionary<int, long> memo = new Dictionary<int, long>();
        static long fibo(int n)
        {
            if (n <= 0)
                return 0;
            if (n <= 2)
                return 1;
            else
            {
                if (memo.ContainsKey(n))
                    return memo[n];
                else
                {
                    long v = fibo(n - 2) + fibo(n - 1);
                    memo[n] = v;
                    return v;
                }
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string,string> student = new Dictionary<string,string>();
            student["이름"] = "이동준";
            student["학번"] = "2009038033";
            student["학과"] = "컴퓨터공학과";
            Console.WriteLine(student["이름"]);
            Dictionary<string, string> student2 = new Dictionary<string, string>();
            student2["이름"] = "이유나";
            student2["학번"] = "2020011022";

            Console.WriteLine(fibo(100));
            Console.WriteLine(rec_fibo(40)); //이게 더 오래걸림...
            Console.WriteLine("끝");

        }
    }
}
