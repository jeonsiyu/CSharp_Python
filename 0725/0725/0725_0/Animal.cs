using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0725_0
{
    public abstract class Animal
    {
        public string name {  get; set; }
        public abstract void eat();
        public abstract void sleep();
    }
}
