using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ahkj;
            double badsfasdf;
            char csdafgasdfg;
            Product p  = new Product();
            Product p1 = new Product(8000);
            Product p2 = new Product("디아블로CD");
            Product p3 = new Product("컴퓨터",500000);

            Console.WriteLine(Product.marketName);
            Product.companyMotto("이동준");
            new Product("파", 50).printInfo();

            //new Product() = 인스턴스
            //a를 인스턴스라고 해도 되긴 함
            //Product a; 이렇게 쓰면 안 됨
            //Product() = 생성자, Product("감자",500) = 생성자
            //new+생성자 = 인스턴스
            //인스턴스 메서드는 인스턴스가 선언되서 나서(즉 만들어지고 나서) 호출할 수 있는 메서드
            Product a = new Product();
            Product aa = new Product("감자",500); //new Product("감자",500) = 인스턴스
            Product b;
            Product c=null;
            a.name = "고구마";
            a.price = 1000;
            a.printInfo();
            //b.name = "감자";
            Console.WriteLine(Product.marketName);
            Product.marketName = "시유마트";
            Console.WriteLine(Product.marketName);
        }
    }
}
