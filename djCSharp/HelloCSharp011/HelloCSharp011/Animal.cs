using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp011
{
    public /*abstract*/ class Animal
    {
        public string name { get; set; }
        public virtual void speak()  //정적 멤버(static)은 virtual 못 쓴다.
        {
            if (name == null)
                return;
            System.Windows.Forms.MessageBox.Show("동물 " + name+": 말 시작");
        }
        //public abstract void charming();
    }
}
