using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_0
{
    public interface IFliablePokemon : IFly
    {
        void wingAttack();
        void makeSandStrom();
        void restWing();
    }
}
