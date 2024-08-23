using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0717_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문자열을 처리하는 다양한 방법
            Console.WriteLine("안녕"[0]);
            Console.WriteLine("안녕"+"하세요");
            Console.WriteLine(1+2+3);  // ctrl d 코드 한줄 복사& 붙여넣기
            Console.WriteLine(1+2+"3"); // 앞에 연산 후 문자열 "3"이 오는것 
            Console.WriteLine("1" + 2 + 3); // 앞에 문자열이 오면 뒤에오는 것들도 문자열로 받음
            Console.WriteLine('1' + 2 + 3); // 아스키코드에 의해서 '1'이 49로 나온것
            Console.WriteLine("안녕 내 나이는" + 1998 + "년 생이야");
            Console.WriteLine($"안녕 내 나이는 {2024-1998}살이야"); // 문자열과 숫자를 같이 쓰고싶을때 사용 
            Console.WriteLine(string.Format("내 나이는 {0}살이야, {1}년생!", 2024-1998,1989));

            int a = int.MaxValue; //2147483647
            Console.WriteLine(a);
            a = a + 1;
            Console.WriteLine(a); // 오버플로우 : 자료형이 가질 수 있는 최대한 값을 넘어설때는 이상한 값이 나옴

            long b = 2147483647;
            b = b + 1;
            Console.WriteLine(b);

            Console.WriteLine("당신의 이름은?");
            string name = Console.ReadLine();
            Console.WriteLine("당신이 태어난 달은?");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine($"내 이름은{name}, 나는 {month}월에 태어남");

            // 문제1) inch 단위를 입력 받아 cm 단위를 구하는 코드를 작성하시오 
            // 1inch = 2.54 cm
            Console.WriteLine("cm단위로 바꿀 숫자를 입력하시오");
            int number1 = int.Parse(Console.ReadLine());
            double total1 = number1 * 2.54;
            Console.WriteLine("cm 단위 :" + total1);

            // 문제2) 킬로그램(kg) 단위를 입력 받아 파운드(pound)단위를 구하는 코드를 작성하시오
            // 1kg = 2.20462262pound

            Console.WriteLine("kg을 입력하세요");
            int number2 = int.Parse(Console.ReadLine());
            double total2 = number2 * 2.20462262;
            Console.WriteLine("pound 단위 :" + total2);

            // 문제3) 원의 반지름을 입력 받아 원의 둘레와 넓이를 구하는 코드를 작성하시오
            // 둘레 = 2*pi*반지름
            // 넓이 = pi*반지름*반지름
            // pi = 3.14

            // 상수로 선언하면 가독성이 높아지고 활용도도 높을 것

            Console.WriteLine("원의 반지름을 입력해주세요");

            double number3 = double.Parse(Console.ReadLine());
            double c = 2 * number3 * 3.14;
            Console.WriteLine("원의 둘레 : " + c);

            double number4 = double.Parse(Console.ReadLine());
            double d = number4 * number4 * 3.14;
            Console.WriteLine("원의 넓이 : " + d);


            // 문제4) 정수 a와 b를 입력받는다.
            // ex) a = 472, b = 385
            // 출력
            // 2360
            // 3776
            // 1416
            // 181720

            Console.WriteLine("첫번째 정수를 입력하세요");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("두번째 정수를 입력하세요");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine(num1 * (num2 % 10));
            Console.WriteLine(num1 * (num2 % 100 / 10));
            Console.WriteLine(num1 * (num2 / 100));
            Console.WriteLine(num1 * num2);

            // 문제5) "5 4 6 2 3 1"
            // 5 4 6 2 3 1 5 4 6 2 3 1
            // 입력과 출력 예시
            // 입력 : 4 
            // 출력[4 6 2 3 1 5]
            // 입력 : 5
            // 출력[5 4 6 2 3 1]

            Console.WriteLine("숫자 입력: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(472 * "385"[0]);
            Console.WriteLine(472 * ("385"[0]-'0') );

        }
    }
}
