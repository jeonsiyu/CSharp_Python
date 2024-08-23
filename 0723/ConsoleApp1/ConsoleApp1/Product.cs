using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public string code { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        //인스턴스 메서드는
        //new 키워드와 생성자가 쓰여야 호출할 수 있음
        //Product c = new Product();
        //c.printInfo();

        //new Product("파",50).printInfo();
        public void printInfo()
        {
            Console.WriteLine("제품명 : " + name+", 가격 :" + price +"원");
        }

        //생성자란?
        //리턴이 아예 없는 함수
        //함수이되 이름이 클래스 이름이랑 똑같은 것
        //생성자 = 함수 = 메서드 
        //오버로딩이 적용되서 여러 개 만들 수 있음
        public Product() { }
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public Product(int price)
        {
            this.price = price;
        }

        public Product(string name)
        {
            this.name = name;
        }

        public static string marketName = "대백마트";
        public static void companyMotto(string name)
        {
            Console.WriteLine(name+"고객님을 향하여 죽도록 충성하자"  );
        }
    }
}
