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
    public partial class Form2 : Form, IObserver
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ISubject sub) //Form1을 의미함
        {
            //ISubject 인터페이스를 구현한 인스턴스를 매개변수로 함
            //그 안에 있는 register를 호출해서 Form2 자신을 집어넣음
            InitializeComponent();
            sub.register(this); //Form2를 추가하겠다
        }
        public void update(string value)
        {
            label1.Text = "옵저버 1 : " + value;
        }
    }
}
