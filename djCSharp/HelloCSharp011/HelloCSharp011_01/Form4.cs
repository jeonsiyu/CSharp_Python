using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp011_01
{
    public partial class Form4 : Form
    {
        private ISubject sub;
        private IObserver o1;
        private IObserver o2;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(ISubject sub, IObserver o1, IObserver o2)
        {
            InitializeComponent();//이게 있어야 디자인 창에 추가했던 버튼들이 보임
            this.sub = sub;
            this.o1 = o1;
            this.o2 = o2;

            button1.Click += (sender, e) => { sub.unregister(o1); };
            button2.Click += (sender, e) => { sub.unregister(o2); };
            button3.Click += (sender, e) => { sub.register(o1); };
            button4.Click += (sender, e) => { sub.register(o2); };
        }
    }
}
