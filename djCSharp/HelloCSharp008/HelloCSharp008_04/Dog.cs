using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_04
{
    //추상클래스를 상속받은 클래스는
    //조상 클래스의 메서드 중 abstract가 붙은 것에 대해
    //반드시 오버라이드를 해야 함
    public class Dog : Animal
    {
        public override void eat()
        {
            Console.WriteLine("얼굴을 밥 그릇에 두고 밥을 먹어요");
        }

        public override void sleep()
        {
            Console.WriteLine("주인의 팔에서 누워서 잡니다.");
        }
    }
}
