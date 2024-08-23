using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0719_09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<int> mylotto = new List<int>();
            Random r = new Random();
            int bnsNum = r.Next(45) + 1;//1~45

            //1~6번째는 중복x, 오름차순 정렬
            //이 여섯개의 번호와 7번째 보너스 번호는 서로 겹치면 안 됨
            mylotto.Add(r.Next(45) + 1);
            while (mylotto.Count < 6)
            {
                int ran = r.Next(45) + 1;
                if (mylotto.Contains(ran)) //포함 여부 체크
                    mylotto.Remove(ran); //포함 되어 있다면 제거
                mylotto.Add(ran); //포함이 되어있든 안 되어 있든 유일한 값
            }
            mylotto.Sort(); //오름 차순 정렬;
            while (mylotto.Contains(bnsNum)) //포함되어 있다면 무한 반복, 없으면 끝
                bnsNum = r.Next(45) + 1;
            foreach (var item in mylotto)
                Console.WriteLine(item);
            Console.WriteLine("보너스 : " + bnsNum);

            Label label = new Label();
            label.AutoSize = true;
            label1.Text = "";
            label1.AutoSize = true;
            foreach (var item in mylotto)
            {
                label.Text += item + " ";
                label1.Text += item + " ";

            }
            label.Text += "보너스 번호 : " + bnsNum;
            label1.Text += "보너스 번호 : " + bnsNum;
            Controls.Add(label);

        }
    }
}
