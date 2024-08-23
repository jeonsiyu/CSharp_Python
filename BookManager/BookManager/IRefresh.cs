using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    public interface IRefresh // 인터페이스 : 특정 메서드를 반드시 규현하라고 강제하는 규칙, 규약
    {
        void RefreshScreen(); // 반환형 없이 사용해서 RefreshScreen();를 파일마다 불러와서 쓸수있음
    }
}
