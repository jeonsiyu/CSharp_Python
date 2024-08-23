using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp007_04
{
    internal class Program
    {
        static void swap(int a, int b) //단순 값 복사이므로  Main에 영향을 주지 않음
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //C#의 ref가 C++의 &와 같다고 보면 됨
        //ref int = int&
        static void swap(ref int a, ref int b)//ref = 참조자, 참조자는 그 변수의 값과 위치 모두 가지고 있음
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void fillMoney(BankAccount account, long money)
        {
            account.money += money;
        }
        static void Main(string[] args)
        {
            int a = 3;
            int b = 5;
            swap(a, b); //값 활용, call by value, 단순 복사
            Console.WriteLine("a="+a+",b="+b);
            swap(ref a, ref b); //참조자 활용, call by reference, 위치와 값이 복사됨
            Console.WriteLine("a=" + a + ",b=" + b);

            //깊은 복사, 얕은 복사
            b = a;
            b = 1000;
            Console.WriteLine("a="+a+",b="+b);//a는 여전히 a값 그대로 갖고 있고 b만 바뀜
            //이런식의 복사를 깊은 복사(Deep Copy)라고 함, 즉 원본에 영향을 주지 않음

            BankAccount siyou = new BankAccount();
            siyou.name = "전시유"; 
            siyou.gender = "여성";
            siyou.money = long.MaxValue;

            //얕은 복사(Shallow Copy)
            //복사를 주의해야 하는 것 : ArrayList, List, 배열이 이 것에 해당됨
            //struct나 int같은 것들은 여기 해당이 안 됨
            BankAccount yuna = siyou;//yuna와 siyou는 같은 메모리 공간을 가리킴
            yuna.money = int.MinValue;
            //siyou, yuna 포인터의 일종이라고 이해하면 됨
            Console.WriteLine(siyou.money);
            fillMoney(siyou, long.MaxValue); //이 경우... yuna.money도 똑같은 값일 것임;;;
            Console.WriteLine(siyou.money);
            Console.WriteLine(yuna.money);
            BankAccount djlee = new BankAccount(); //복사할 때 주의해야 함
            djlee.gender = siyou.gender;
            djlee.name = "이동준";
            djlee.money = 0;
            Console.WriteLine(djlee.money);
            Console.WriteLine(siyou.money);

            LoLAccount hjAhn = new LoLAccount();
            hjAhn.tier = "챌린저";
            hjAhn.name = "이동준의 제자";
            hjAhn.cashMoney = int.MaxValue;
            LoLAccount ldj = hjAhn; //구조체는 이렇게 복사해도 됨, 원본에 영향X
            ldj.tier = "심해";
            ldj.name = "이동준";
            ldj.cashMoney = 0;
            Console.WriteLine(hjAhn.tier);
            Console.WriteLine(hjAhn.cashMoney);
            Console.WriteLine(ldj.tier);
            Console.WriteLine(ldj.cashMoney);

        }
    }
}
