using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp009_02
{
    public interface IFliablePokemon : IFly
    {
        void wingAttack();
        void makeSandStrom();
        void restWing();
    }
}
