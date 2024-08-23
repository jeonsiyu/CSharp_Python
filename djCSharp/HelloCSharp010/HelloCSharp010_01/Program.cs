using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloCSharp010_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=2714055500
            string url = "https://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=2714055500";
            //using System.Xml.Linq;
            XElement xe = XElement.Load(url);//url에서 xml을 가져옴 //public static XElement Load(string uri) 클래스 메서드
            Console.WriteLine(xe); //url의 xml 결과물을 출력 함
            Console.WriteLine("-----");
            //Descendants = 자손들

            var xQ = from item in xe.Descendants("data") select item;
            foreach(var item in xQ)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            foreach (var item in xQ) //<data> 태그 안에 있는 <temp> 태그랑 <wfKor> 태그에 있는 것만 출력
            {
                if(item.Element("day").Value.Equals("0")) //오늘에 대해서만 출력하고 싶다면...
                {
                    Console.WriteLine(item.Element("temp"));
                    Console.WriteLine(item.Element("hour").Value);
                    Console.WriteLine(item.Element("wfKor").Value);
                }
            }
        }
    }
}
