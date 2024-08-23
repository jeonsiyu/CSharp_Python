using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_05
{ // 추상 클래스를 상속받은 클래스는 반드시 오버라이드 해야함
    internal class Dog : Animal
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
