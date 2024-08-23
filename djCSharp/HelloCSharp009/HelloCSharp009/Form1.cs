using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp009
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Initialize : 초기화
            //Component : 구성요소
            InitializeComponent();

            Student<int> a = new Student<int>();
            a.hakbeon = 1;
            Student<string> b = new Student<string>();
            b.hakbeon = "a01";
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(5);
            nums.Add(15);
            
        }
        //ctrl - : 직전 화면
        //ctrl shift - : 다시 뒤의 화면
        //참고 : 이클립스에서는 alt키랑 좌우 방향키로 화면 이동가능함

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test"); //모달(Modal)
            MessageBox.Show("Test","제목");
            MessageBox.Show("Test","제목",MessageBoxButtons.OKCancel);
            MessageBox.Show("Test","제목",(MessageBoxButtons)1);//OKCancel
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MyForm().Show();//모달리스(Modeless)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MyForm().ShowDialog();//모달(Modal)
        }
    }
}
