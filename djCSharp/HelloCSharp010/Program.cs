using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //짝수만 가져오고 싶은 경우
            //o1, o2는 IEnumerable<int> 타입
            var o1 = from item in numbers where item % 2 == 0 select item;
            var o2 = from item in numbers where item % 2 == 0 orderby item descending select item;
            List<int> even_num = o1.ToList<int>();
            int[] even_num_desc = (from item in nums where item % 2 == 0 
                                  orderby item descending select item).ToArray<int>();
            foreach(var item in o1)
                Console.WriteLine(item); 
            foreach (var item in o2)
                Console.WriteLine(item);
            numbers.Add(-10);
            numbers.Add(-15);
            var mytest = from item in numbers
                         select new
                         {
                             val = item,
                             power_val = item * item,
                             double_val = item * 2,
                             isEven = item % 2 == 0,
                             isNegative = item < 0,
                             output = "값 : " + item
                         };
            foreach(var item in mytest)
            {
                Console.WriteLine(item.val);
                Console.WriteLine(item.power_val);
                Console.WriteLine(item.double_val);
                Console.WriteLine(item.isEven);
                Console.WriteLine(item.isNegative);
            }

            List<Product> products = new List<Product>();
            products.Add(new Product() { name = "김", price = 500 });
            products.Add(new Product() { name = "파", price = 200 });
            products.Add(new Product() { name = "쌀", price = 250 });

            //순서정렬방법들
            //1. Product에 IComparable<Product>, compareTo를 구현
            //2. 델리게이트나 람다를 이용한 방법( Sort에 정렬 메서드를 추가함 )
            //=>1,2의 경우 Sort를 호출하면서 원본 자체가 정렬이 됨
            //3. LINQ를 활용하는 방법
            //=> 원본이 정렬되는 게 아니고 정렬된 또 다른 복사본을 얻게 됨
            foreach(var item in products)
                Console.WriteLine(item);
            var products2 = from item in products orderby item.price select item;
            foreach(var item in products2)
                Console.WriteLine(item);
            List<Product> sortedProducts = (from item in products
                                            orderby item.price
                                            select item).ToList<Product>();
            foreach (var item in sortedProducts)
                Console.WriteLine(item);
            foreach (var item in products)
                Console.WriteLine(item);
        }
    }
}
