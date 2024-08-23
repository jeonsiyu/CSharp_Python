using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_03
{
    // 1. Rectangle class를 만들고 width, height 멤버(=인스턴스 변수) 만든다.
    public class Rectangle
    {
        public int width { get; set; }
        public int height{ get; set; }

        //2. getArea() 메서드(=인스턴스 메서드)
        //getArea(int w, int h) 메서드(=클래스 메서드) 두 개 만든다.
        //둘 다 반환형은 int이다.
        // 인스턴스 메소드
       public int getArea()
        {
            return width * height;
        }
    
        public static int getArea(int w, int h)
        {
            return w * h;
        }
        
        static void main(string[] args)
        {
            Rectangle r = new Rectangle();  
        }
    
    }
}
