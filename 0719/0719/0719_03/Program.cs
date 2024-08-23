using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0719_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ArrayList<integer>
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(5);
            Console.WriteLine(nums[1]); //nums.get(1);
            // c#에도 ArrayList가 있으나 용도가 다름
        }   // java의 ArrayList<Object>와 같음
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("123");
    }
}
