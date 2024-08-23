using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_07
{
    public class Program
    {
        //delegate = 대리자
        //delegate, 무명 delegate, 람다
        //함수(=메서드)를 변수화시키는 것
        delegate void TestDelegate(); //TestDelegate라는 자료형이 새로 생긴 것
        delegate string productInfo(Product p);
        delegate string studentInfo(Student p);
        static void runFunc(TestDelegate t, int count)
        {
            for (int i = 0; i < count; i++)
                t();
        }
        static void helloWorld()
        {
            Console.WriteLine("안녕 세상!");
        }
        static void studentInformation(studentInfo a, Student s)
        {
            Console.WriteLine("학생의 정보를 출력합니다.");
            Console.WriteLine(a(s));
            Console.WriteLine("학생의 정보를 출력 완료합니다.");
        }
        static string getStudent(Student s)
        {
            return "이름 :" + s.name + ",나이:" + s.age;
        }
        static void Main(string[] args)
        {
            runFunc(helloWorld, 3);
            TestDelegate a = helloWorld;
            Console.WriteLine("--");
            a();
            Console.WriteLine("--");
            runFunc(a, 3);
            Console.WriteLine("---");
            runFunc(delegate () { Console.WriteLine("무명델리게이트"); }, 10); //무명델리게트
            Console.WriteLine("---");
            runFunc(() => { Console.WriteLine("람다~~"); }, 20);

            List<Product> products = new List<Product>();
            products.Add(new Product() { name = "감자", price = 500 });
            products.Add(new Product() { name = "고구마", price = 1500 });
            products.Add(new Product() { name = "파", price = 700 });
            List<Student> students = new List<Student>();
            students.Add(new Student() { name = "이동준", age = 35 });
            students.Add(new Student() { name = "이유나", age = 25 });
            students.Add(new Student() { name = "박상신", age = 45 });
            //각 클래스에 IComparable를 구현해줘야 함
            //그러나 델리게이트 개념을 활용하면 쉽게 정렬을 해줄 수 있음 
            products.Sort((p1, p2) =>
            {
                return p1.price.CompareTo(p2.price); //오름차순
            });

            productInfo stringProudct = delegate (Product myp)
            {
                return myp.name + "," + myp.price;
            };
            productInfo mystringProduct = (mypro) =>
            {
                return mypro.name + ", 가격은 " + mypro.price;
            };


            foreach (var item in products)
                Console.WriteLine(stringProudct(item)); //Console.WriteLine(item.name);

            products.Sort(delegate (Product p1, Product p2)
            {
                return p2.price.CompareTo(p1.price); //내림 차순 정렬
            });

            foreach (var item in products)
                Console.WriteLine(mystringProduct(item));//Console.WriteLine(item.name);

            students.Sort((s1, s2) => { return s1.age.CompareTo(s2.age); });
            studentInfo mystu = (s) =>
            {
                return s.name + "학생, 나이:" + s.age;
            };
            foreach (var item in students)
            {
                Console.WriteLine(mystu(item));
            }

            studentInformation(getStudent, students[0]);
            studentInformation(delegate (Student s) { return "나이:" + s.age + "이름:" + s.name; }, students[0]);
            studentInformation((s) => { return s.age + "이름:" + s.name; }, students[0]);
            studentInformation(getStudent, new Student() { name = "안경민", age = 20 });

        }
    }
}
