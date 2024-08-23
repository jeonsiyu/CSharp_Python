using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_04
{
    internal class Teacher
    {
        public string name {  get; set; }   
        public int age { get; set; }
        public string major { get; set; }

        // 생성자가 생기게되면
        // 아까 언급했던 아무것도 없는(매개변수랑 내용이 없는) 생성자는 삭제됨
        // 즉 public Teacher(){} 이게 아래 생상자가 생기므로 인해서 삭제됨

        // alt enter -> 생성자 생성 클릭 -> 확인 클릭
        public Teacher(string name, int age, string major)
        {
            Console.WriteLine("선생님께서 추가되셨습니다.");
            this.name = name;
            this.age = age;
            this.major = major;
        }

        // 생성자도 오버로딩이 됨
        // 따라서 매개변수 없이 인스턴스를 만들고 싶다면...
        // 아래와 같이 추가해주면 됨
        public Teacher()
        {
            Console.WriteLine("선생님께서 추가되셨습니다.");
        }
    }
}
