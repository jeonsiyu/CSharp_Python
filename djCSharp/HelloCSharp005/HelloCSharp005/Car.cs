using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005
{
    public class Car
    {
        //{get;set;} java의 Getter Setter와 같은 것
        //private String carNum;
        //public void setCarNum(String carNum)
        //{
        //this.carNum = carNum;
        //}
        //public String getCarNum()
        //{
        //  return this.carNum;
        //}
        public string carNum { get; set; }
        public string category { get; set; }
        public int length { get; set; }
        public double kg { get; set; }
    }
}
