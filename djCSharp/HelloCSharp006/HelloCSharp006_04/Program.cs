using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp006_04
{
    internal class Program
    {
        //1. 앞에다가 static을 붙인다.
        static void printName(string name)
        {
            Console.WriteLine("이름 : " + name);
        }
        //2. Program class를 이용해서 인스턴스를 만듦
        void printAge(int age)
        {
            Console.WriteLine("나이 : " + age);
        }
        static int myage = 100;
        string myname = "djlee";
        static void Main(string[] args)
        {
            //3. Main 안에 함수를 집어 넣는다(...)
            //void printName(string name)
            //{
            //    Console.WriteLine("이름 : " + name);
            //}
            myage++;
            printName("이동준");
            Program p = new Program(); //2번째 방법
            p.printAge(35);
            p.myname = "이동준이";
            new Program().myname = "이상길";

            Test t = new Test(); //메모리에 할당을 해야 쓸 수 있음
            //power, multi 이런 것들은 인스턴스 메서드로 적합하지 않음
            //어차피 매개변수에 따라서 값이나 모양이 달라지므로
            //클래스 변수쓰는 게 낫고, 굳이 인스턴스를 만들 필요도 없음...
            int a = t.power(10);
            int b = t.Multi(10, 5);
            t.print();
            Console.WriteLine(a);
            Console.WriteLine(b);

            //static 메서드 즉 클래스 메서드를 사용함
            //인스턴스 선언 안 하고 클래스에서 다이렉트로 쓸 수 있음
            //프로그램 시작하자마자 메모리에 할당되어 있으니까 가능함
            Console.WriteLine(Test2.power(10));
            Console.WriteLine(Test2.Multi(10,5));
            Test2.print();

            Circle c1 = new Circle();
            c1.r = 1;
            Circle c2 = new Circle();
            c2.r = 3;
            Console.WriteLine(c1.getArea()); //인스턴스 변수, 인스턴스 메서드는
            Console.WriteLine(c2.getArea());//인스턴스 별로 모양이나 값이 다름
            Console.WriteLine(Circle.getAreaWithR(100));//클래스 변수, 클래스 메서드는
            Console.WriteLine(Circle.getAreaWithR(10));//전부 다 똑같음
                                                      //클래스 메서드는 매개변수에 따라서 값이나 모양이 달라짐
        }
    }
}
