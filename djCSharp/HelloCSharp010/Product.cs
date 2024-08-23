using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp010
{
    public class Product
    {
        public int price { get; set; }
        public string name { get; set; }
        public override string ToString()//object 클래스에 있는 메서드
        {
            //public virtual string ToString()
            return name + ",가격:" + price;
        }
    }
}
