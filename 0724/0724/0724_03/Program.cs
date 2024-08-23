using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_03
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
            // 문제점 1) Animal이 없으면 cat과 Dog에 겹치는 코드가 많음
            // 문제점 2) 이 동물들 각각이 모두 먹고 자고 각자가 할 수 있는 것들을 하
            // 동물 종류가 늘어날수록 list랑 foreach문이 늘어나고 있음..
            // 한 장소 안에 동물들을 몰아 넣었다고 가정했을때
            // 이 코드 역시 간결화가 필요함..(다향성이 필요함)

            // 다향성 : 다양한 형태로 변할 가능성 
            // A is B가 성립되는 관계에서 볼 수 있는 형태
            // 클래스의 기본적인 속성 중에 하나
            // ex) "Galaxy S24 is Phone.
            // Phone is "Galaxy S24.

            // 다형성이란? 왼쪽은 조상 클래스, 오른쪽은 그 조상의 자손 클래스
            Animal ani = new Rabbit(); // Rabbis Animal
            Animal r = new Raccoon(); // Raccoon is Animal 

            //다향성 활용하면 아래 코드처럼, 조상클래스에 해당하는 타입의 List에
            //그 클래스를 상속받은 인스턴스들을 다 추가할 수 있음
            List<Animal> animals = new List<Animal>();
            animals.Add(a);
            animals.Add(c); //new Cat()
            animals.Add(d); //new Dog()
            animals.Add(ani);
            animals.Add(r);
            animals.Add(new Dog());
            animals.Add(new Cat());
            animals.Add(new Rabbit());
            animals.Add(new Raccoon());
            foreach (var item in animals)
            {
                item.eat();
                item.sleep();
                if (item is Dog) //is = new Dog()인지 체크함
                    (item as Dog).bark(); // = {((Dog)item).Bark();}
                if (item is Cat)
                    (item as Cat).meow(); // = {((Cat)item).meow();}
                if (item is Rabbit)
                    (item as Rabbit).dash(); // = {((Rabbit)item).dash();}
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
            (a1 as Dog).bark(); // 형변환을 통해 Dog에 있는 것들을 사용할 수 있음
            Dog d1 = new Dog(); 
            d1.bark(); // 일반적인 경우는 형변환 x

            // ---------------------------------------------------------------------

            Dog ddd = new Dog();
            ddd.bark();
            Animal ad = new Dog();
            (ad as Dog).bark();
            Cat cc = new Cat();
            Rabbit rr = new Rabbit();
            List<Animal> anis = new List<Animal>();
            anis.Add(new Animal());
            anis.Add(new Dog());
            anis.Add(new Cat());
            anis.Add(new Rabbit());
            anis.Add(ad);
            anis.Add(ddd);
            foreach(var item in anis)
            {
                item.sleep();
                item.eat();
                if (item is Cat)
                    (item as Cat).meow();
                if (item is Dog)
                    (item as Dog).bark();
            }

            // 다형성을 쓰지 않으면 아래와 같이 중복되는 것들이 많을것
            List<Animal> list1 = new List<Animal>();
            list1.Add(new Animal());
            list1.Add(new Animal());
            list1.Add(new Animal());
            List<Dog> list2 = new List<Dog>();
            list2.Add(new Dog());
            list2.Add(new Dog());
            list2.Add(new Dog());
            List<Cat> list3 = new List<Cat>();
            list3.Add(new Cat());
            list3.Add(new Cat());
            list3.Add(new Cat());
            foreach(var item in list1) 
            { 
                item.eat(); 
                item.sleep(); 
            }
            foreach(var item in list2)
            {
                item.eat();
                item.sleep();
                item.bark();
            }
            foreach (var item in list3)
            {
                item.eat();
                item.sleep();
                item.meow();
            }


            Animal dog = new Dog();
            (dog as Dog).bark(); //Animal 타입이지만 Dog로 형변환이 가능함 = 다형성
            dog.cry(); //오버라이드 된 메서드라면 오른쪽에 있는 클래스를 따름
            //하이딩된 것(=new)라면 왼쪽에 있는... 타입을 따름
            //하이딩됐다면 강제로 형변환시 오른쪽에 있는 메서드 호출하게 할 수 있음
            //Dog is Animal.
            //=> 
            //Animal is Dog. (x)

            Dog dddd = new Dog();
            //dddd.bark();
            Animal myanimal = new Animal();
            myanimal.Kg = -5;
            Console.WriteLine(myanimal.Kg);

        }


    }
}
