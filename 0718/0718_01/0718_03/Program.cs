using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0718_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문제 풀이
            //문제1. 삼각형 모양 피라미드를 만드시오
            int floor = 5;
            //Consile.Write, Console.WriteLine 
            for (int i = 0; i< floor; i++) 
            {
                for(int j=floor-i-1; j>0; j--)
                    Console.Write("");
                for(int j= 0; j < 2*i+1;j++)
                    Console.Write("*");

                Console.WriteLine();
            }

            // 문제2. 5개의 숫자를 입력받은 뒤 가장 작은 수와 가장 큰수를 출력하는 프로그램을 작성하시오.
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("정수 입력");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int max = numbers[0];
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                //if (max < numbers[i])
                //    max = numbers[i];
                max = numbers[i] > max ? numbers[i] : max;
                //if (min > numbers[i])
                //    min = numbers[i];
                min = numbers[i] < min ? numbers[i] : min;
            }
            Console.WriteLine("최댓값 : " + max + ", 최솟값 : " + min);

            // 문제3. 아래의 규칙을 따르는 수열의 20번째 숫자를 프로그램을 만들어 찾으시오.
            // 1, 11, 12, 1121, 122111,112213
            // 첫번쨰 수열: 1
            // 두번째 수열: 1이 1개 = 11
            // 세번째 수열: 1이 2개 = 12
            // 네번째 수열: 1이 1개, 2가 1개 = 1121
            // 다섯 번째 수열: 1이 2개, 2개, 1이 1개 = 122111
            // 여섯 번째 수열: 1이 1개, 2가 2개 1이 3개 = 112213
            string start = "1"; // 처음에는 주어지는 읽은 수열(문자열이라봐도)
            for (int i = 0; i<20; i++)
            {
                Console.WriteLine(start);
                string end = ""; // 일정의 누적 변수 
                int count = 0;  // 읽은 숫자의 개수 
                char num = start[0];
                for(int j=0; j<start.Length; j++)
                {
                    if (num == start[j])
                    count++;
                    else
                    {
                        end = end + num + count;
                        count = 1;
                        num = start[j];
                    }
                }
                end = end + num + count;
                start = end;
            }

            // 문제4. 반복문을 사용해서 1부터 100까지 합 구하기.
           
            // 1부터 n구하는 공식, n(n+1)/2
            Console.WriteLine(100*101/2);

            int sum = 0;
            for (int i = 1; i <= 100; i++)
                sum += i;
            Console.WriteLine(sum);

            // 문제5. 한글 전부 출력하기
            for(char c = '가'; c <= '힣'; c++)
                Console.WriteLine(c);

            // 문제6, A~Z, a~z 출력
            for(char a = 'A'; a <='z'; a++)
            {
                if (a > 'z' && a <= 'a')
                continue;
                Console.WriteLine(a);
            }

        }

    }
   }
