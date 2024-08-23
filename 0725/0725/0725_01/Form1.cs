using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0725_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Initialize : 초기화
            // Component : 구성요소
            InitializeComponent();

            Student<int> a = new Student<int>();
            a.hakbeon = 1;
            Student<string> b = new Student<string>();
            b.hakbeon = "a01";
            List<int> nums = new List<int>(); // List도 제너릭의 한 종류라고 볼 수 있음
            nums.Add(10);
            nums.Add(5);
            nums.Add(15);
        }

        // ctrl- : 직전화면
        // ctrl shift- : 다시 뒤의 화면
        // 참고: 이클립스에서는 alt키랑 좌우 방향키로 화면 이동가능함

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test"); // 모달(Modal) : 뒤에 창을 만질 수 없음
            MessageBox.Show("Test", "제목");
            MessageBox.Show("Test","제목", MessageBoxButtons.OKCancel);
            MessageBox.Show("Test","제목", (MessageBoxButtons)1); //OKCnacel
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MyForm().Show(); // 모달리스(Modelss) : 뒤에 창이 만질 수 있음
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MyForm().ShowDialog(); // 모달(Modal)
        }
    }
}
