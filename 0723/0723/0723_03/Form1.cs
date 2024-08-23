using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0723_03
{
    public partial class Form1 : Form
    {
        int answer;
        int cout = 1;
        int now = 0;
        const int LIMIT = 10;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            timer1.Interval = 1000; //1000ms = 1s = 1초
            timer1.Enabled = false; // 타이머 일단 동작하고있지않음
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();//timer1.Enabled = false;
            now = 0;

            answer = new Random().Next(25) + 1;
            Console.WriteLine(answer);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    Point point = new Point();
                    point.X = 13 + 100 * j;
                    point.Y = 13 + 13 + (23 + 3) * i;
                    button.Location = point;
                    button.Text = cout.ToString();
                    button.Click += Button_Click;
                    cout++;
                    Controls.Add(button);//필수
                }
            }
            timer1.Start();//timer1.Enabled = true;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            int mychoice = int.Parse((sender as Button).Text);
            if (mychoice == answer)
            {
                timer1.Stop();
                now = 0;
                MessageBox.Show("정답!");
                answer = new Random().Next(25) + 1;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            now++;
            if (now > LIMIT)
            {
                (sender as Timer).Stop(); //timer1.Stop();
                MessageBox.Show("타임 오버");
                return; //메서드 종료
            }
            label1.Text = now + "/" + LIMIT;
        }
    }
}
