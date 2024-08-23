using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car();
            c1.carNum = "8512" ;
            c1.kg = 1123.554;
            c1.length = 210;
            c1.category = "세단";

            Car c2 = new Car();
            c2.carNum = "7722";
            c2.kg = 1523.554;
            c2.length = 150;
            c2.category = "SUV";

            Student s1 = new Student();
            s1.hakbeon = "033";
            s1.name = "이동준";
            s1.car = c1;
            Student s2 = new Student();
            s2.hakbeon = "001";
            s2.name = "박상신";
            s2.car = c2;
            Student s3 = new Student();
            s3.hakbeon = "002";
            s3.name = "이유나";
            Console.WriteLine(s3.car);

            //Car의 carNum, kg, length, category,
            //Student의 hakbeon, name, car 이런 것들은 인스턴스 변수이다.
            //Math.PI 이런 것들은 클래스 변수이다.
            //인스턴스 변수 : 인스턴스별로 값이 다를 수 있고, 인스턴스가 선언이 되어야 값을 정할 수 있음
            //무슨 소리냐면... new Student()를 해야 학번을 정할 수 있다.

            // 클래스 변수 = static이 들어가 있어야 함
            // 공통된 값, 공유되는 값이라고 함
            // PI값 같은 경우엔 수학적으로 봤을 때 변하지 않으므로 공용이 됨

            //Student를 예로 들자면, 경북산업직업전문학교의 Student라고 하면
            //학교 위치 값은 모두 공유함 

            Random r = new Random();
            Console.WriteLine(r.Next(1,10)); // 1~9까지 출력
            Console.WriteLine(new Random().Next(1,10));
            Console.WriteLine(Math.PI);//3.14159265358979

        }
    }
}
