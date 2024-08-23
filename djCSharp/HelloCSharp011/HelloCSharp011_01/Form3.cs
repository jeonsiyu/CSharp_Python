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
    public partial class Form3 : Form,IObserver
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(ISubject sub) //Form1을 의미함
        {
            InitializeComponent();
            sub.register(this); //Form3를 추가하겠다
        }
        public void update(string value)
        {
            textBox1.Text = value;
        }
    }
}
