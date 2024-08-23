using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { name = "고구마", price = 1000 });
            products.Add(new Product() { name = "파", price = 500 });
            products.Add(new Product() { name = "감자", price = 700 });
            List<int> numbers = new List<int>() { 1, 10, 5, 0 };
            numbers.Sort();
            foreach (var item in numbers)
                Console.WriteLine(item);
            products.Sort(); //내부적으로 compareTo
            foreach (var item in products)
                Console.WriteLine(item.name);
        }

    }
}
