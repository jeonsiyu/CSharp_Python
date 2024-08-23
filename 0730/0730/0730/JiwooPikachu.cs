using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0730
{
    internal class JiwooPikachu : Animal
    {
 
        //C# 스타일로 만드는 싱글톤
        private JiwooPikachu() { }
        private static JiwooPikachu instance;
        public static JiwooPikachu Instance
        {
            get
            {
                if (instance == null)
                    instance = new JiwooPikachu();
                return instance;
            }
        }
        public override void speak()
        {
            base.speak();
            System.Windows.Forms.MessageBox.Show("피카 피카~");
        }
    } 
}

