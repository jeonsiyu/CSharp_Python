using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0722_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 인스턴스 메서드
        private void button1_Click(object sender, EventArgs e)
        {
            // 오버로딩 예시
            // 매개변수의 개수나 타입이 다르면
            // 메서드의 이름이 똑같아도
            // 서로 다른 메서드로 간주함
            // c언어에는 없고, java에는 있는 개념!!!
            // 참고로 반환형은 전혀 중요하지 않음 오직 중요한건 매개변수!
            MessageBox.Show("Test"); // 클래스 메서드 메시지 박스, 매개변수에 따라 형태 달라짐
            MessageBox.Show("내용", "제목");


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
