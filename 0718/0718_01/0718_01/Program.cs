using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0718_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 사용자에게 태어난 년도를 입력받아 그 해의 때를 출력하는 프로그램을 작성(if)
            Console.WriteLine("태어난 년도를 입력해주세요");
            int year = int.Parse(Console.ReadLine());
            // year %= 12;
            int checkYear = year % 12;
            if (checkYear == 9)
                Console.WriteLine("뱀띠");
            else if (checkYear == 10)
                Console.WriteLine("말띠");
            else if (checkYear == 11)
                Console.WriteLine("양띠");
            else if (checkYear == 0)
                Console.WriteLine("원숭이띠");
            else if (checkYear == 1)
                Console.WriteLine("닭띠");
            else if (checkYear == 2)
                Console.WriteLine("개띠");
            else if (checkYear == 3)
                Console.WriteLine("돼지띠");
            else if (checkYear == 4)
                Console.WriteLine("쥐띠");
            else if (checkYear == 5)
                Console.WriteLine("소띠");
            else if (checkYear == 6)
                Console.WriteLine("호랑이띠");
            else if (checkYear == 7)
                Console.WriteLine("토끼띠");
            else if (checkYear == 8)
                Console.WriteLine("용띠");
            else
                Console.WriteLine("?????");

            // 현재 년도가 무슨 띠인지 구하는 프로그램을 작성하시오(switch)
            int nowYear = DateTime.Now.Year;
            int checkNow = nowYear % 12;
            switch (checkNow)
            {
                case 0:
                    Console.WriteLine("원숭이");
                    break;
                case 1:
                    Console.WriteLine("닭");
                    break;
                case 2:
                    Console.WriteLine("개");
                    break;
                case 3:
                    Console.WriteLine("돼지");
                    break;
                case 4:
                    Console.WriteLine("쥐");
                    break;
                case 5:
                    Console.WriteLine("소");
                    break;
                case 6:
                    Console.WriteLine("호랑이");
                    break;
                case 7:
                    Console.WriteLine("토끼");
                    break;
                case 8:
                    Console.WriteLine("용");
                    break;
                case 9:
                    Console.WriteLine("뱀");
                    break;
                case 10:
                    Console.WriteLine("말");
                    break;
                case 11:
                    Console.WriteLine("양");
                    break;
                default:
                    Console.WriteLine("여기로 올 일은 아마 없을 듯?");
                    break;
            }

            // 사용자에게 현재 월을 입력받아 계절을 출력하는 프로그램을 작성하시오.
            // if문 사용 - 12,1,2 겨울/ 3,4,5 봄/ 6,7,8 여름/ 9,10,11 가을
            Console.WriteLine("현재 월(달)을 입력해주세요");
            int month = int.Parse(Console.ReadLine());
            if (month >= 3 && month <= 5)
            {
                Console.WriteLine(month + "은 봄 입니다.");
            }
            else if (month >= 6 && month <= 8)
            {
                Console.WriteLine(month + "은 여름 입니다.");
            }
            else if (month >= 9 && month <= 11)
            {
                Console.WriteLine(month + "은 가을 입니다");
            }
            else if (month == 12 || month == 1 || month == 2)
            {
                Console.WriteLine(month + "은 겨울 입니다");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요!");
            }
            // 현재 월이 무슨 계절인지 구한는 프로그램을 작성하시오(switch)
            int nowMonth = DateTime.Now.Month;
            switch (nowMonth)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("겨울");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("봄");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("여름");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("가을");
                    break;
                default:
                    Console.WriteLine("!?");
                    break;

                    // 필요 자료형(2,4번 문제에서 쓴다.)
                    // DateTime.Now.Year
                    // DateTime.Now.Month

            }
        }
    }
}
