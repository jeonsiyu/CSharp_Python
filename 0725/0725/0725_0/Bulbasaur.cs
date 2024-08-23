using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_0
{
    //java 
    //extends, impliments로 상속과 구현을 구분
    //C#은 콜론으로 뒤에 갖다 붙임


    public class Bulbasaur : Animal, IPlant
    {
        public override void eat()
        {
            throw new NotImplementedException();
        }
        public override void sleep()
        {
            throw new NotImplementedException();
        }
        public void grow()
        {
            throw new NotImplementedException();
        }
        public void photosynthesize()
        {
            throw new NotImplementedException();
        }
    }
}
