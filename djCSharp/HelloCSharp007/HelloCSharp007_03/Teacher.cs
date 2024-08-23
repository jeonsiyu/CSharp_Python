using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp007_03
{
    public class Teacher
    {
        public string name { get; set; }
        public int age { get; set; }
        public string major { get; set; }


        //생성자(Constructor)가 생기게 되면
        //아까 언급했던 아무 것도 없는 (매개변수랑 내용이 없는) 생성자는 삭제됨
        //즉 public Teacher() {} 이 게 아래 생성자가 생기므로 인해서 삭제됨


        //alt enter -> 생성자 생성 클릭 -> 확인 클릭
        public Teacher(string name, int age, string major)
        {
            this.name = name;
            this.age = age;
            this.major = major;
        }
        //생성자도 오버로딩이 됨
        //따라서 매개변수 없이 인스턴스를 만들고 싶다면...
        //아래와 같이 추가해주면 됨
        public Teacher()
        {

        }



    }
}
