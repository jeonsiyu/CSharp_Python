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
    public partial class UcDay : UserControl
    {

        string _day;
        string date;
        string weekday;
        bool isFull;
        Label todayLabel;
        public string Date => date;

        private CalendarManager calendarManager; // CalendarManager 인스턴스 추가


        public UcDay(string day, bool isFull=false)
        {
            InitializeComponent();
            _day = day; // 전달된 날짜를 저장
            label1.Text = day; // 레이블에 날자표시
                               // checkBox1.Hide(); // 체크박스 숨기기
            date = calender._month + "/" + _day + "/" + calender._year;

            //더블 클릭 이벤트 
            flowLayoutPanel_UcDay.DoubleClick += FlowLayoutPanel_UcDay_DoubleClick; // flowLayoutPanel 더블 클릭

            // 오늘 날짜와 비교하여 색상 설정
            SetColorForToday();
            this.isFull = isFull;
            // 일정 표시
            DisplaySchedules();
        }



        private void FlowLayoutPanel_UcDay_DoubleClick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(254, 236, 243); // 색상 변경

            // MemoForm을 UcDay 인스턴스를 전달하며 생성
            MemoForm memoForm = new MemoForm(this);
            memoForm.ScheduleAdded += RefreshSchedules;
            memoForm.ScheduleUpdated += RefreshSchedules;
            memoForm.ScheduleDeleted += RefreshSchedules;
            memoForm.ShowDialog();

            this.BackColor = Color.White; // 원래 색상으로 되돌리기
        }

        // 일정 표시 메서드
        public void RefreshSchedules()
        {
            DisplaySchedules(); // 현재 일정을 다시 표시
        }


        // 일정 표시 메서드
        public void DisplaySchedules()
        {
        
            flowLayoutPanel_UcDay.Controls.Clear(); // 기존 일정 초기화

            // DBHelper를 통해 일정 로드
            DBHelper dbHelper = new DBHelper();
            List<Schedule> schedules = dbHelper.LoadSchedules();

            // 날짜와 일치하는 일정 찾기
            DateTime targetDate;
            if (!DateTime.TryParse(date, out targetDate))
            {
                // 날짜 변환 실패 시, 적절한 처리를 합니다. 예: 오류 로그 기록 또는 기본값 설정.
                Console.WriteLine($"Invalid date format: {date}");
                return; // 메서드 종료
            }




            int count = 0;
            foreach (var schedule in schedules)
            {
                if (schedule.Date.Date == targetDate.Date) // 오늘 날짜와 비교
                {
                    // 일정 정보를 레이블로 표시
                    Label scheduleLabel = new Label
                    {
                        Text = schedule.Title, // 일정 제목
                        AutoSize = true,
                        BackColor = schedule.Color, // 색상 적용
                        ForeColor = Color.Black,
                        Padding = new Padding(2),
                        Margin = new Padding(2),
                        Font = new Font("경기천년제목", 9f),
                        Tag = schedule // 일정 정보를 태그로 저장
                    };

                    if (scheduleLabel.BackColor == Color.Black)
                    {
                        scheduleLabel.ForeColor = Color.White;
                    }
                    scheduleLabel.DoubleClick += (s, args) =>
                    {
                        this.BackColor = Color.FromArgb(254, 236, 243); // 색상 변경

                        // MemoForm을 UcDay 인스턴스를 전달하며 생성
                        MemoForm memoForm = new MemoForm(this);
                        memoForm.ScheduleAdded += RefreshSchedules; // 일정 추가 후 새로 고침
                        memoForm.ShowDialog();

                        this.BackColor = Color.White; // 원래 색상으로 되돌리기
                    };

                    flowLayoutPanel_UcDay.Controls.Add(scheduleLabel);

                    if(isFull!=true)
                    {
                        count++;
                        if (count >= 2)
                        {
                            break;
                        }
                    }

                }
            }
   
        }


        private void SetColorForToday()
        {
            DateTime currentDate = DateTime.Today; // 오늘 날짜
            DateTime thisDate;

            // date 문자열을 DateTime으로 변환
            if (DateTime.TryParse(date, out thisDate))
            {
                // 오늘 날짜와 비교
                if (thisDate.Date == currentDate)
                {
                    panel1.BackColor = Color.FromArgb(253, 206, 206); // 오늘 날짜의 색상

                }
            }
        }

        private void sundays()
        {
            try
            {
                DateTime day = DateTime.Parse(date); //date 문자열을 DateTime으로 변환
                weekday = day.ToString("dddd", new CultureInfo("ko-KR")); // 요일을 한글 문자열로 가져옴 (예: sun,mon, ... )
                if (weekday == "일요일")
                {
                    label1.ForeColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);
                }
            } catch(Exception) { }
        }


        private void UcDay_Load(object sender, EventArgs e)
        {
            sundays();
        }

        
    }
}
