using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0723_02
{
    public partial class Form1 : Form
    {
        int answer;
        public Form1()
        {
            InitializeComponent();
            
        }

        int cout = 1; //count 변수
        private void button1_Click(object sender, EventArgs e)
        {

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
                    button.Click += button1_Click;
                    cout++;
                    Controls.Add(button);  // 필수
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
  
