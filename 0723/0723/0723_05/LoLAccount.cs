using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_05
{
    // 무조건 값복사(=깊은 복사)가 되서
    // 추노를 부를 일이 없다.
    // 실수로 값을 잘 못 복사할 일 없음
    // 간단한 사용자 정의 자료형의 경우 구조체도 많이 씀
    // 다만 상속 드으이 여러가지 특성들이 주로 class에 있어서
    // class를 훨씬 더 많이 쓰긴 함
    internal struct LoLAccount
    {
        public string tier {  get; set; }   
        public string name { get; set; }    

        public int cashMoney {  get; set; } 

        public void playGame()
        {
            Console.WriteLine(tier+"끼리 게임중인 " + name);
        }
    }
}
