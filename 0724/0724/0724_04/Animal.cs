using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_04
{
    public class Animal
    {
        public string name { get; set; } // 인스턴스 별로 모두 값이 다름
        public static int count = 0; // count 값은 cat과 공유를 함
        public Animal()
        {
            count++;
            Console.WriteLine("응애응애");
        }
         // 오버라이드 = 덮어쓰기
         // 조상 클래스의 메서드를 덮어씀

        public void eat()
        {
            Console.WriteLine("냠냠");
        }
        public virtual void cry()//동물마다 모두 우는 방식이 다르므로 오버라이드할 여지를 줄 수 있음
        {//java같은 경우엔 그냥 자손 클래스에 cry 추가하면 자동 오버라이드 됨
            //C#은 virtual이랑 override라는 키워드를 써야지만 오버라이드가 됨
            Console.WriteLine("엉엉ㅠㅠ");
        }
    }
}
