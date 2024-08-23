using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_04
{
    //IComparable:c#에서 제공하는 인터페이스
    public class Product : IComparable<Product>
    {
        public string name { get; set; }
        public int price { get; set; }

        //비교 기준을 정해 줌, 즉 누가 더 큰지... 이런 걸 정함
        //어떤 값이 크냐에 따라서 음수, 0, 양수를 리턴하고
        //이걸 이용해서 Sort에서 정렬을 함
        //즉 Sort에서 내부적으로 CompareTo를 호출하여 정렬을 함
        public int CompareTo(Product other)
        {
            return price.CompareTo(other.price);
        }

        //public override string ToString()
        //{
        //    return "제품명:" + name + ",가격:" + price;
        //}
    }
}
