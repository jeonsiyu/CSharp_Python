using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_05
{
    public class Cat : Animal
    {
        //object 클래스에 있는 메서드를 오버라이드
        //java에서도 똑같이 쓸 수 있음
        public override string ToString()
        {
            return "고양이의 이름 : " + name + ", 나이 : " + age;
            //return base.ToString(); //return GetType().ToString();
        }
        public override void eat()
        {
            Console.WriteLine("집사가 주는 밥을 맛있게 드신다.");
            // throw new NotImplementedException(); 구현하지 않았다는 이름의 예외(=오류))
        }

        public override void sleep()
        {
            Console.WriteLine("그릉 그릉 그릉...");
            //throw new NotImplementedException();
        }
    }
}
