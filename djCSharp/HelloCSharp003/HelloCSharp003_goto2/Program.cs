using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp003_goto2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(  100*(100+1)/2);
            int sum = 0;
            int i = 1;
            MYSUM:
            sum += i;
            i++;
            if (i <= 100)
                goto MYSUM;
            Console.WriteLine(sum);

            int a = 3;
            int b = 10;
            int ii = a;
            int sumsum = 0;
        MYATOB:
            sumsum += ii;
            ii++;
            if (ii <= b)
                goto MYATOB;
            Console.WriteLine(sumsum);



        }
    }
}
