using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp008_01
{
    public partial class Form1 : Form
    {
        int answer;
        int cout = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            answer = new Random().Next(25) + 1;
            Console.WriteLine(answer);
            cout = 1; //cout 값 초기화

            //무언가를 제거할 땐 역for문을 써주는 게 좋음
            for(int i = Controls.Count-1; i>=0; i--)
            {
                if (Controls[i].Name.Contains("q"))
                    Controls.RemoveAt(i);
            }

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
                    button.Name = "q" + cout;
                    button.Click += Button_Click;
                    cout++;
                    Controls.Add(button);//필수
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //sender = 이벤트를 발생시키는 주체
            //(sender as Button) = Button으로 형변환
            int mychoice = int.Parse((sender as Button).Text);
            if (mychoice == answer)
                MessageBox.Show("정답");
        }

    }
}
