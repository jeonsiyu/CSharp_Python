using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodByeCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 마우스가 눌렸을 때 
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;

        }
        private Point myPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            myPoint = new Point(e.X, e.Y);//클릭한 곳의 위치를 저장
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int x = myPoint.X - e.X;
                int y = myPoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

    }
}
