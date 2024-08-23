using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0723_01
{
    public partial class Form1 : Form
    {
        int answer;
        const int LIMT = 5; // 제한 시간
        int now; // 현재시간
        public Form1()
        { 
            InitializeComponent();
            Random r = new Random();
            answer = r.Next(10)+1;
            Console.WriteLine(answer);
            now = 0;
            label1.Text = ("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Trim: 양 옆 공백제거
            if (textBox1.Text.Trim().Equals(""))
                return; // 메서드 종료

            int num = int.Parse(textBox1.Text.Trim());
            if(answer == num)
            {
                timer1.Enabled = false; // timer1 중단시킴
                MessageBox.Show("정답!");
                answer = new Random().Next(10) + 1;
                Console.WriteLine(answer);
                timer1.Start();
                //timer1.Enabled = true;
            }


        }

        // 1000ms, 즉 1초에 한번 동작
        private void timer1_Tick(object sender, EventArgs e)
        {
            now++;
            if(now >= LIMT)
            {
                timer1.Stop(); //Stop 부분 클릭 후 F12 눌러서 확인해보기
                now = 0;
                MessageBox.Show("TimeOver");
            }

            label1.Text = now + "/" + LIMT;
        }
    }
}
