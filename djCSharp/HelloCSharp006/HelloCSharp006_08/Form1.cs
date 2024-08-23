using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp006_08
{
    public partial class Form1 : Form
    {
        //열거형, Enumeration
        enum RCP
        {
            Gawi, Bawi, Bo
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getResult("가위");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getResult(button2.Text);//getResult("바위");
        }
        //sender : 이벤트를 발생시키는 주체
        //object : 모든 객체의 조상
        private void button3_Click(object sender, EventArgs e)
        {
            getResult( (sender as  Button).Text  );//getResult(button3.Text);//getResult("보");
        }

        void getResult(string text)
        {
            label1.Text = "내가 낸 것 : " + text;
            int computer = new Random().Next(3); //0=가위, 1=바위, 2=보
            string[] rcp = { "가위", "바위", "보" };

            const int GAWI = 0;
            const int BAWI = 1;
            const int BO = 2;

            MessageBox.Show(rcp[GAWI]);
            MessageBox.Show(rcp[BAWI]);
            MessageBox.Show(rcp[BO]);
            MessageBox.Show(rcp[ (int)RCP.Gawi]  );
            MessageBox.Show(rcp[(int)RCP.Bawi] );
            MessageBox.Show(rcp[(int)RCP.Bo] );


            label2.Text = "컴퓨터가 낸 것 : " + rcp[computer];
            //무승부
            if (text.Equals(rcp[computer])) //==도 되나 문자열 비교는 Equals를 쓰자
            {
                label3.Text = "무승부";
                return; //함수 종료
            }
            //승리  or 패배
            switch(text)
            {
                case "가위":
                    if (rcp[computer].Equals("바위"))
                        label3.Text = "패배";
                    else //보
                        label3.Text = "승리";
                    break;
                case "바위":
                    if (rcp[computer].Equals("가위"))
                        label3.Text = "승리";
                    else //보
                        label3.Text = "패배";
                    break;
                case "보":
                    if (rcp[computer].Equals("가위"))
                        label3.Text = "패배";
                    else //바위
                        label3.Text = "승리";
                    break;
            }
        }
    }
}
