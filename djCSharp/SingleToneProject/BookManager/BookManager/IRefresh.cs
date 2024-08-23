using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    public interface IRefresh //특정 메서드를 반드시 구현하라고 강제하는 규칙,규약
    {
        void RefreshScreen();
    }
}
