using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_03
{
    public class Animal
    {
        public string name { get; set; }    
        public int age { get; set; }

        public virtual void sleep()
        {
            Console.WriteLine("잠을 잡니다.."); // 이건 오버라이드가 될 가능성이 있는 메서드야!
        }

        public void eat()
        {
            Console.WriteLine("밤을 먹습니다.");
        }
        public virtual void cry()
        {
            Console.WriteLine("ㅠㅠ");
        }

        private double kg;
        public double Kg
        {
            get { return kg; }
            set
            {
                if (value < 0)
                    kg = (value * -1);
                else
                    kg = value;
            }
        }
    }
}
