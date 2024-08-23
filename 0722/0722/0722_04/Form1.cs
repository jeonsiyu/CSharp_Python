using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0722_04
{
    // 3. Random 이용해서 Winform에서 숫자 맞추기 게임 간단하게
    //만들기(1~10 중 하나의 값 입력받고 정답 확인)
    public partial class Form1 : Form
    {
        private int randomNumber; // 정답 숫자 저장
    
        public Form1()
        {
            InitializeComponent();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            Random random = new Random();
            randomNumber = random.Next(1, 11); // 1부터 10까지의 랜덤 숫자 생성
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userGuess;

            // 사용자가 입력한 값이 유효한 숫자인지 확인
            if (int.TryParse(txtGuess.Text, out userGuess))
            {
                // 숫자가 1과 10 사이에 있는지 확인
                if (userGuess < 1 || userGuess > 10)
                {
                    MessageBox.Show("숫자는 1과 10 사이여야 합니다.", "잘못된 입력", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (userGuess == randomNumber)
                {
                    MessageBox.Show("정답입니다! 게임을 새로 시작합니다.", "축하합니다!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GenerateRandomNumber(); // 새 게임을 위한 새로운 숫자 생성
                    txtGuess.Text = "";
                }
                else
                {
                    MessageBox.Show("틀렸습니다. 다시 시도해보세요.", "오답", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGuess.Text = "";
                }
            }
            else
            {
                MessageBox.Show("유효한 숫자를 입력하세요.", "잘못된 입력", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
