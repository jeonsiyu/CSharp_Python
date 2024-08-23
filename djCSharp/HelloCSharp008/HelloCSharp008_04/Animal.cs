using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_04
{
    public abstract class Animal
    {
        public string name { get; set; }
        public int age { get; set; }
        public abstract void sleep();//내가 직접 구현하지 않음
                                                     //다만 이걸 상속받은 클래스는 꼭! 구현해야 함
                                                     //오버라이드를 꼭 해야 한다는 의미!
        public abstract void eat();
        public void die()
        {
            Console.WriteLine("..... 생체 반응이 멈췄습니다....");
        }
    }
}
