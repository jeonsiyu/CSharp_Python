using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp004_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //alt shift, alt ctrl 키 이용해서 여러 곳 선택 가능
            //for문으로 1부터 100까지 더하기

            //1부터 n 구하는 공식,    n(n+1)/2
            Console.WriteLine(  100*101/2 );
            int sum = 0;
            for (int i = 1; i <= 100; i++)
                sum += i;
            Console.WriteLine(sum);
            //한글 전부 출력     //alt키 누르고 화살표 위 아래 
            for (char c = '가'; c <= '힣'; c++)
                Console.Write(c);
            //A~Z, a~z 출력
            for(char a ='A'; a<='z'; a++)
            {
                if (a > 'Z' && a < 'a')
                    continue;

                Console.Write(a);
            }

            string start = "1"; //처음에 주어지는 읽을 수열(문자열이라봐도 됨)
            for(int i = 0; i<20; i++)
            {
                Console.WriteLine(start);
                string end = ""; //일종의 누적 변수
                int count = 0; //읽은 숫자의 개수
                char num = start[0];
                for(int j =0; j<start.Length;j++)
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


        }
    }
}
