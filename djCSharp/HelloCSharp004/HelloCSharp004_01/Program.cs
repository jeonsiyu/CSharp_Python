using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp004_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];// {0,0,0,0,0}
            int[] ns =  { 1, 2, 3, 4, 5 };
            int[] ns2 =  new int [] { 1, 2, 3, 4, 5 };




            numbers[0] = 10; // {10, 0,0,0,0}
            numbers[1] = 2; // {10, 2,0,0,0}
            for (int i = 2; i<5; i++)
                numbers[i] = i*10;
            // // {10, 2,20,30,40}
            //numbers.Length = 배열의 길이
            //sizeof(numbers)/sizeof(int)

            for (int i = 0; i<numbers.Length; i++)
                Console.WriteLine(numbers[i]);

            foreach(var item in numbers)
                Console.WriteLine(item);
            //for(int item : numbers) //java style

        }
    }
}
