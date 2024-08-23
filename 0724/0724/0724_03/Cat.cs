using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_03
{
    //Cat은 name,age 속성이 있고
    //eat(),sleep() 기능이 있음
    //Cat은 Animal의 자손 클래스 혹은 서브 클래스
    // Animal은 Cat의 조상 클ㄹ스 혹은 슈퍼클래스
    //Java에서는 Animal을 Cat의 super클래스라고 함
    // C#에서는 Animal을 Cat의 base클래스라고 함
    public class Cat: Animal
    {
        public override void sleep()
        {
            Console.WriteLine("고양이처럼 잡니다.");
        }
        public string servantName { get; set; }
        public void meow()
        {
            Console.WriteLine("야옹"); ;
        }


    }
}
