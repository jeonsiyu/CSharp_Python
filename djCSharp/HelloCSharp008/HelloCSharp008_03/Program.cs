using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();//호출하지도 않은 Animal()이 호출됨
            //이유 : 자손 클래스를 이용해서 인스턴스 만들면
            //부모 클래스의 생성자도 같이 자동으로 호출이 됨
            Console.WriteLine(Animal.count);
            Console.WriteLine(Cat.count);
            Animal a = new Animal();
            Animal b = new Cat();
            Console.WriteLine(Animal.count);
            Console.WriteLine(Cat.count);
            //count가 공유되고 있음
            //클래스 변수, 클래스 메서드는 조상클래스, 자손 클래스가 서로 공유를 함
            a.name = "콩이";
            b.name = "랑이";
            c.name = "뭉치";
            //동물들 3마리의 이름은 각자 다 다름
            //그러나 count값은 전부 공유하고 있음
            Animal aa = new Animal();
            Animal cc = new Cat();
            Animal dd = new Dog();
            aa.cry();
            cc.cry();
            dd.cry();
            Cat cat = new Cat();
            Dog dog = new Dog();
            cat.cry();
            dog.cry();

        }
    }
}
