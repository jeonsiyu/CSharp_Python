using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0718_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];// {0,0,0,0,0}
            int[] ns = { 1, 2, 3, 4, 5 };
            int[] ns2 = new int[] { 1, 2, 3, 4, 5 };

            numbers[0] = 10; // {10, 0,0,0,0}
            numbers[1] = 2; // {10, 2,0,0,0}
            for (int i = 2; i < 5; i++)
                numbers[i] = i * 10;
            // // {10, 2,20,30,40}
            //numbers.Length = 배열의 길이
            //sizeof(numbers)/sizeof(int) -> 자바스타일

            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(numbers[i]);

            foreach (var item in numbers)
                Console.WriteLine(item);
            //for(int item : numbers) //java style

            // 문제1. 삼각형 모양 피라미드를 만드시오


            // 문제2. 5개의 숫자를 입력받은 뒤 가장 작은 수와 가장 큰수를 출력하는 프로그램을 작성하시오.
            int[] numbers2 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("숫자를 입력하세요", i + 1);
                numbers2[i] = int.Parse(Console.ReadLine());
            }
            
            int maxNumber = numbers2[0];
            int minNumber = numbers2[0];

            for (int i = 1; i < 5; i++)
            {
                if (numbers2[i] > maxNumber)
                {
                    maxNumber = numbers2[i];
                }

                if (numbers2[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            Console.WriteLine($"가장 큰 수는 {maxNumber}입니다.");
            Console.WriteLine($"가장 작은 수는 {minNumber}입니다.");

            // 문제3. 아래의 규칙을 따르는 수열의 20번째 숫자를 프로그램을 만들어 찾으시오.
            // 1, 11, 12, 1121, 122111,112213
            // 첫번쨰 수열: 1
            // 두번째 수열: 1이 1개 = 11
            // 세번째 수열: 1이 2개 = 12
            // 네번째 수열: 1이 1개, 2가 1개 = 1121
            // 다섯 번째 수열: 1이 2개, 2개, 1이 1개 = 122111
            // 여섯 번째 수열: 1이 1개, 2가 2개 1이 3개 = 112213

            string[] sequece = new string[20];
            sequece[0] = "1";

            for (int i = 1; i< 20 ; i++)
            {
            }



            // 문제4. 반복문을 사용해서 1부터 100까지 합 구하기.
            int sum = 0;
            for (int i = 0; i < 100; i++ )
            {
                sum += i;
            }

            Console.WriteLine("1부터 100까지의 합: " + sum);

            // 문제5. 한글 전부 출력하기
            for (int i = 0xac00; i <= 0xd7A3; i++ )
            {
                char c = (Char)i;
                Console.WriteLine(c);
            }

            // 문제6. A~Z까지 a~z 모두 출력
            for (char i = 'a'; i <= 'z'; i++)
            {
         
                Console.WriteLine(i);
            }

            for (char i = 'A'; i <= 'Z'; i++)
            {

                Console.WriteLine(i);
            }
        }
    }
}
