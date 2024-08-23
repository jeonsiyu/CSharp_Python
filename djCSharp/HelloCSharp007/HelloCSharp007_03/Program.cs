using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp007_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            //s.id = 1;
            //s.hakbeon = "?";
            s.setHakbeon("2009038033");
            Console.WriteLine(s.getHakbeon());
            s.Age = 10; //age 값에 10이 대입됨, Age를 통해서, 즉 여기선 10이 value
            s.BirthYear = 2014; //2014가 value에 해당함
            s.name = "이동준";
            Student s2 = new Student() { Age = 35, BirthYear = 1989, name = "djlee" };

            Teacher t1 = new Teacher("이유나", 20, "컴퓨터교육");
            Teacher t2 = new Teacher();

        }
    }
}
