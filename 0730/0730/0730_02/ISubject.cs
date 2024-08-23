using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0730_02
{
    public interface ISubject
    {
        // 매개변수 의미 : IObserver를 구현한 모든 객체가 다 매개변수로 들어올 수 있음
        // 이유는 다형성 때문!!
        //IFly pokemon = new Tropius();
        //IPlant startingPokemon = new Bulbasaur();
        void register(IObserver o); // subscribe
        void unregister(IObserver o);   // unsubscribe 혹은 dissubscribe
        void notify(string msg); // 일괄적으로 IObserver에 있는 update를 호출함 
    }
}
