using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Data
    {
        public int Index {get; set;}// the index of the product
        public int Lot{ get; set;} // refers to the quantity of the product(assuming)
        public string Time { get; set; } // manufactured time, has a korean character inside
        public double pH { get; set; } // acidity of the solution(? idk)
        public double Temp { get; set; } // temperature
        public double Current { get; set;} // current of the power source
        public double Voltage { get; set; } // voltage of the power source

        public string date { get; set; }
    }
}
