using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_02
{
    public class Animal
    {
        public string name { get; set; }
        public int age { get; set; }

        public virtual void sleep() //이건 오버라이드가 될 가능성이 있는 메서드야!
        {
            Console.WriteLine("잠을 잡니다...");
        }
        public void eat()
        {
            Console.WriteLine("밥을 먹습니다.");
        }

        //해당 클래스를 상속받은 클래스만 쓸 수 있음
        //private의 경우에는 자기 자신만 사용가능함
        //protected는 자기 자신과, 자신을 상속받은 클래스에서만 쓸 수 있음
        protected void charming()
        {
            Console.WriteLine("애교를 부립니다.");
        }

    }
}
