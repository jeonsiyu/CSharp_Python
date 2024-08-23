using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList<Integer> nums = new ArrayList<Integer>();
            //List<Integer> nums = new ArrayList<Integer>();
            List<int> nums = new List<int>(); //클래스임
            //참고로 배열 자체도 클래스임
            nums.Add(10);
            nums.Add(5);
            Console.WriteLine(nums[0]); //nums.get(1);
            //C#에도 ArrayList가 있으나, 용도가 다름
            //java의 ArrayList<Object>와 같음
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("123");
            arrayList.Add(Math.PI);
            Console.WriteLine(arrayList[2]);
        }
    }
}
