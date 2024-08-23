using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_01
{
    internal class Test
    {
        //인스턴스 변수처럼, 인스턴스마다 호출되는 값이나 결과, 모양등이 
        //다를 수 있다.
        public int power(int x) //이 것들은 전부 다 인스턴스 메서드
        {                                    //왜? static이 없음
            return x * x;             //인스턴스 별로 다를 수 있음
        }
        public int Multi(int x, int y)
        {
            return x * y;
        }
        public void print()
        {
            Console.WriteLine("메시지를 출력합니다.");
        }
    }
}
