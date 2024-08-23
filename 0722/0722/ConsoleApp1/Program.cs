using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void IncreaseAge(int age)
        {
            age++;
        }
        static void IncreaseAge(Student a)
        {
            a.age++;
        }
        void test()
        {
            Console.WriteLine(  "ㅎㅇ");
        }

        static void Main(string[] args)
        {
            //test();
            Program p = new Program();
            Program p1 = new Program();
    

            Student student = new Student();
            student.Hakbeon = "038";
            student.name = "이동준";
            student.age = 100;
            IncreaseAge(student);
            Console.WriteLine(student.age);
            int age = 100;
            IncreaseAge(age);
            Console.WriteLine(age);



            //Student b = student;
            Student b = new Student();
            b.Hakbeon = student.Hakbeon;
            b.name = student.name;
            b.name = "전시유";
            Console.WriteLine(student.name);
            Console.WriteLine(b.name);

            Person p1 = new Person();
            p1.name = "이동준";
            p1.Id = 1;
            Person p2 = p1;
            p2.name = "전시유";

            Console.WriteLine(p1.name);
            Console.WriteLine(p1.Id);
            Console.WriteLine(p2.name);
            Console.WriteLine(p2.Id);


            Console.WriteLine(Math.Abs(-2));

            student.age = 50;
            b.age = 10;
            student.study();
            b.study();

        }
    }
}
