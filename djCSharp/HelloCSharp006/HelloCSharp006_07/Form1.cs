using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp006_07
{
    public partial class Form1 : Form
    {
        //프로그램 시작하자마자 정답이 정해지게 하고 싶음
        //문제 맞추면 정답이 바뀌게 하고 싶음
        int answer=0; //Form1, button1_Click에서 모두 적용되는 전역 변수
        //전역 변수라기 보단... Form1 클래스의 새로운 구성요소
        //ex. Student 클래스의 age와 같은 것
        public Form1()
        {
            InitializeComponent();
            answer = new Random().Next(10) + 1;//1~10까지의 값
            Console.WriteLine(answer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mychoice = int.Parse(textBox1.Text);
            if(mychoice == answer)
            {
                MessageBox.Show("정답!");
                answer = new Random().Next(10) + 1;//1~10까지의 값
                Console.WriteLine(answer);
            }

        }
    }
}
