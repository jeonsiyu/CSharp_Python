using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp008_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal mya = new Cat();
            mya.sleep();

            
            Animal a = new Animal();
            a.name = "동동이";
            a.age = 3;
            a.sleep();
            a.eat();
            Cat c = new Cat();
            c.name = "랑이";
            c.age = 4;
            c.servantName = "김준형";
            c.sleep();
            c.eat();
            c.meow();
            Dog d = new Dog();
            d.name = "뭉치";
            d.age = 7;
            d.masterName = "이동준";
            d.sleep();
            d.eat();
            d.bark();
            //문제점 1) Animal이 없으면 Cat과 Dog에 겹치는 코드가 많음
            //문제점 2) 이 동물들 각각이 모두 먹고 자고 각자가 할 수 있는 것들을 하게 하고 싶으나,
            //동물 종류가 늘어날수록 List랑 foreach 문이 늘어나고 있음...
            //한 장소 안에 동물들을 몰아넣었다고 가정했을 때
            //이 코드 역시 간결화가 필요함...(=다형성이 필요함)

            //다형성 : 다양한 형태로 변할 가능성
            //A is B가 성립되는 관계에서 볼 수 있는 형태
            //클래스의 기본적인 속성 중에 하나
            // "Galaxy S24" is Phone.
            // Phone is "Galaxy S24".

            //다형성이란? 왼쪽은 조상클래스, 오른쪽은 그 조상의 자손 클래스
            Animal ani = new Owl();//Owl is Animal
            Animal r = new Raccoon(); // Raccoon is Animal

            //다형성 활용하면 아래 코드처럼, 조상 클래스에 해당하는 타입의 List에
            //그 클래스를 상속받은 인스턴스들을 다 추가할 수 있음
            List<Animal> animals = new List<Animal>();
            animals.Add(a);
            animals.Add(c); //new Cat()
            animals.Add(d); //new Dog()
            animals.Add(ani);
            animals.Add(r);
            animals.Add(new Dog());
            animals.Add(new Cat());
            animals.Add(new Owl());
            animals.Add(new Raccoon());
            foreach(var item in animals)
            {
                item.eat();
                item.sleep();
                if (item is Dog) //is = new Dog()인지 체크함
                    (item as Dog).bark();
                if (item is Cat)
                    (item as Cat).meow();
                if (item is Owl)
                    (item as Owl).spinHead();
            }

            //c.charming();

            //Object랑 object는 같은 것
            Object aa = new Animal();
            object aaa = new Animal();
            List<object> testList = new List<object>();
            testList.Add(10);
            testList.Add("10");
            testList.Add(3.14);
            testList.Add('a');
            testList.Add(a);
            testList.Add(c);
            testList.Add(aa);
            ArrayList arrayList = new ArrayList();//java의 ArrayList랑 다르고... java의 ArrayList<Object>와 같다.
            arrayList.Add(10);
            arrayList.Add("10");
            arrayList.Add(3.14);
            arrayList.Add('a');
            arrayList.Add(a);
            arrayList.Add(c);
            arrayList.Add(aa);

            Animal a1 = new Dog();
            //a1은 일단 Animal 타입의 변수
            //따라서 Dog의 메서드를 쓸 수 없다
            //다만 Dog를 이용해서 인스턴스를 만들었기 때문에
            //형변환을 해주고 나면은 Dog에 있는 것들도 쓸 수 있습니다.
            (a1 as Dog).bark();
            Dog d1 = new Dog();
            d1.bark();


        }
    }
}
