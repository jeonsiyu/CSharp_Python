using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_02
{
    //Cat은 name, age 속성이 있고
    //eat(), sleep() 기능이 이미 있음
    //Cat은 Animal의 자손 클래스 혹은 서브클래스
    //Animal은 Cat의 조상 클래스 혹은 슈퍼클래스
    //java에서는 Animal을 Cat의 super 클래스라고 함
    //C#에서는 Animal을 Cat의 base 클래스라고 함
    public class Cat : Animal
    {
        public override void sleep()
        {
            Console.WriteLine("고양이처럼 잡니다.");
        }
        public string servantName { get; set; }
        public void meow()
        {
            charming();//고양이는 Animal을 상속받았으므로 charming 호출 가능함
            Console.WriteLine("야옹");
        }
    }
}
