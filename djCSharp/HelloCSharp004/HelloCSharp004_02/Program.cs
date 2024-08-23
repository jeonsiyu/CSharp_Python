using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp004_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //삼각형 모양 피라미드를 만드시오.
            int floor = 5;
            //Console.Write, Console.WriteLine
            for(int i = 0; i<floor; i++)
            {
                for(int j =floor-i-1; j>0; j--)
                    Console.Write(" ");
                for(int j = 0; j<2*i+1; j++)
                    Console.Write("*");

                Console.WriteLine();
            }

            int[] numbers = new int[5];
            for(int i = 0; i<numbers.Length; i++)
            {
                Console.WriteLine("정수 입력");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int max = numbers[0];
            int min = numbers[0];
            for(int i = 1; i<numbers.Length;i++)
            {
                //if (max < numbers[i])
                //    max = numbers[i];
                max = numbers[i] > max ? numbers[i] : max;
                //if (min > numbers[i])
                //    min = numbers[i];
                min = numbers[i]<min ? numbers[i] : min;
            }
            Console.WriteLine("최댓값 : " + max +", 최솟값 : " + min);

        }
    }
}
