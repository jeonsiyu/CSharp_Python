using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class calender : Form
    {
        public static int _year, _month; // 현재 표시되고 있는 년도와 월을 저장하는 정적 변수
        public List<UcDay> Days = new List<UcDay>();
        private bool isFull = false;
        public calender(bool isFull = false)
        {
            InitializeComponent();
            this.isFull = isFull;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year); // 현재 날짜와 월, 연도를 가져와 showDays 메서드를 호출    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _month -= 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDays(_month, _year);
        }


        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            Days.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            IbMonth.Text = monthName.ToUpper() + " " + year;
            DateTime strartodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);    
            int week = Convert.ToInt32(strartodTheMonth.DayOfWeek.ToString("d")) + 1; // strartodTheMonth은 해당 월의 첫번째 날을 나타냄
            
            // 빈 날 추가하기
            for (int i = 1; i< week; i++)
            {
                UcDay uc = isFull ? new UcDay("", isFull) : new UcDay("");
                Days.Add(uc);
                flowLayoutPanel1.Controls.Add(uc);
            }

            // 현재 날짜 가져오기
            DateTime currentDate = DateTime.Now;

            // 날짜 추가하기
            for (int i = 1; i<= day ; i++)
            {

                        // 현재 날짜와 비교
        Color bgColor = (i == currentDate.Day && month == currentDate.Month && year == currentDate.Year) 
            ? Color.FromArgb(255, 150, 79) // 현재 날짜 색상
            : Color.White; // 기본 색상


                UcDay uc = isFull? new UcDay(i + "", isFull) : new UcDay(i+"");
                Days.Add(uc);
                flowLayoutPanel1.Controls.Add(uc);
            }
                 
        }
    }
}
