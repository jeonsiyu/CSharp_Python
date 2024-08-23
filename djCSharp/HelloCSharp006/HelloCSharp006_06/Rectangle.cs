using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp006_06
{
    public class Rectangle
    {
        public int width { get; set; }
        public int height { get; set; }
        public int getArea()
        {
            return width * height;
        }
        public static int getArea(int w, int h)
        {
            return w * h;
        }
    }
}
