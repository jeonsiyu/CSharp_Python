using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp009_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            MessageBox.Show("제곱 결과 : " + (a*a));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool test = int.TryParse(textBox2.Text, out int a);
            MessageBox.Show("제곱 결과 : " + (a * a));
        }

        //반지름 정보 입력받아서 넓이와 둘레를 구해주는 메서드
        //아니 그럼... 리턴값이 2개야???
        //out : ref랑 똑같음. 다만... 다른 게 딱 하나 있다면...
        //ref는 값을 새로 할당할 필요가 없지만 out은 반 드 시 값을 새로 할당해야 함
        //아래 메서드의 경우, area와 round에는 무조건 값이 들어가야 함
        bool generateCircleInfo(int r, out double area, out double round)
        {
            if (r <= 0)
            {
                area = 0;
                round = 0;
                return false;
            }
            area = r*r*3.14;
            round = 2*r*3.14;
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double myarea=0;
            double myround=0;
            //visual studio 2015까지는... out int 이렇게 못 쓰고......
            //int를 TryParse 밖에다 미리 선언해야 했음
            //int radius=0;
            //int.TryParse(textBox3.Text, out radius);
            //2017부터는 아래와 같이 선언과 동시에 쓰는 게 가능해짐(out int)
            int.TryParse(textBox3.Text, out int radius);
            generateCircleInfo(radius, out myarea, out myround);
            MessageBox.Show("myarea = " + myarea);
            MessageBox.Show("myround = " + myround);
        }



        private void button4_Click(object sender, EventArgs e)
        {
            double myarea = 0;
            double myround = 0; 
            bool check = int.TryParse(textBox4.Text, out int radius);
            if(check)
            {
                generateCircleInfo(radius, out myarea, out myround);
                MessageBox.Show("myarea = " + myarea);
                MessageBox.Show("myround = " + myround);
            }

        }

        void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        void swap(out int x, out int y, int a, int b)
        {
            //out은 반드시 할당을 받아야 하는 데, 첫 줄부터 할당을 받는 게 아니고
            //누군가에게 할당을 해줘야 함... 그래서 에러가 남...
            int temp = a;
            x = b;
            y = temp;
        }
        private void button_swap_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox_a.Text, out int a);
            int.TryParse(textBox_b.Text, out int b);
            swap(ref a, ref b);
            MessageBox.Show("a="+a+",b="+b);
            swap(out a, out b, a, b);
            MessageBox.Show("a=" + a + ",b=" + b);

        }
    }
}
