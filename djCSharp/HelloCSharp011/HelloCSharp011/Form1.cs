using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp011
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MySingletone a = MySingletone.getInstance();
            MySingletone b = MySingletone.getInstance();
            Animal aa = new Animal();
            Animal bb = new Animal();
            Console.WriteLine("싱글톤 패턴은 객체가 딱 하나 => " + (a==b));
            Console.WriteLine("aa와 bb는 서로 다른 존재 " + (aa==bb));
            //사실 우리가 만들었던 도서 관리 프로그램도 싱글톤으로 변형해서 쓸 수 있음

        }

        GoldenMole g1;
        GoldenMole g2;

        private void button1_Click(object sender, EventArgs e)
        {
            g1 = GoldenMole.getInstance();
            g1.speak();
            g1.hairColor = "무지갯빛";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g2 = GoldenMole.getInstance();
            g2.speak();
            MessageBox.Show(g2.hairColor);
            MessageBox.Show("살아있니, 황금 두더지, 네 1마리요... " + (g1==g2));
        }

        JiwooPikachu j1;
        JiwooPikachu j2;
        private void button3_Click(object sender, EventArgs e)
        {
            j1 = JiwooPikachu.Instance;
            j1.speak();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            j2 = JiwooPikachu.Instance;
            j2.name = "피카추";
            j2.speak();
            MessageBox.Show(j1.name);//피카추
            MessageBox.Show("지우 피카츄는 개체가 단 하나임 " + (j1==j2));
        }
    }
}
