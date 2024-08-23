using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0730_03
{
    public class Locale
    {
        public string name {  get; set; }   //장소명
        public double lat { get; set; } // y좌표
        public double lng { get; set; } // x좌표

        public Locale(string name, double lat, double lng)
        {
            this.name = name;
            this.lat = lat;
            this.lng = lng;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
