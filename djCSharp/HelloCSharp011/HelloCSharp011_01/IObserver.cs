using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp011_01
{
    public interface IObserver
    {
        void update(string value);
    }
}
