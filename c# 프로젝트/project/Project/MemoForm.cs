using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project
{
    public partial class MemoForm : Form
    {
        string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";
        public string MemoText { get; private set; } // 입력된 메모를 저장할 속성
        private UcDay ucDayInstance; // UcDay 인스턴스 변수 추가]
        private Label selectedLabel; // 선택된 라벨을 저장할 변수
        private Schedule selectedSchedule;  // 선택된 이미지 표시를 위한 PictureBox
     
        public event Action ScheduleAdded; // 일정 추가 이벤트
        public event Action ScheduleUpdated; // 일정 수정 이벤트
        public event Action ScheduleDeleted;  // 일정 삭제 이벤트


        public MemoForm(UcDay ucDayInstance, Schedule schedule = null)
        {
            InitializeComponent();
            this.ucDayInstance = ucDayInstance; // 전달된 UcDay 인스턴스를 저장
            DisplaySchedules();
            this.deleteButton.Click += deleteButton_Click;

            plusSave_Button.Click += new EventHandler(plusSave_Button_Click);
            updateButton.Click += new EventHandler(updateButton_Click);
            deleteButton.Click -= new EventHandler(deleteButton_Click);
            deleteButton.Click += new EventHandler(deleteButton_Click);
        }


        private void plusSave_Button_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(ucDayInstance.Date); // UcDay에서 선택된 날짜
            Schedule selectedSchedule = new Schedule(selectedDate);

            using (var scheduleCheckForm = new ScheduleCheckForm(selectedSchedule))
            {
                // 모달 폼으로 열기
                if (scheduleCheckForm.ShowDialog() == DialogResult.OK) // 일정이 성공적으로 추가된 경우
                {
                    ScheduleAdded?.Invoke(); // 일정 추가 이벤트 발생
                    DisplaySchedules(); // 추가 후 즉시 일정 표시
                }
            }
        }


        private void DisplaySchedules()
        {
            // 패널 초기화
            flowLayoutPanel_Schedules.Controls.Clear();

            // DBHelper를 통해 일정 로드
            DBHelper dbHelper = new DBHelper();
            List<Schedule> schedules = dbHelper.LoadSchedules();

            // UcDay에서 전달받은 날짜 사용
            DateTime targetDate = DateTime.Parse(ucDayInstance.Date); // UcDay에서 전달된 날짜 사용

            // 저장된 일정 표시
            foreach (var schedule in schedules)
            {
                if (schedule.Date.Date == targetDate.Date) // 오늘 날짜와 비교
                {
                    Label scheduleLabel = new Label
                    {
                        Text = schedule.ToString(),
                        AutoSize = true,
                        BackColor = schedule.Color, // 색상 적용 (배경색으로 설정)
                        ForeColor = Color.Black, // 텍스트 색상
                        Padding = new Padding(3), // 패딩 추가
                        Margin = new Padding(1), // 마진 추가
                        Tag = schedule // 일정 정보를 저장
                    };

                    if (scheduleLabel.BackColor == Color.Black)
                    {
                        scheduleLabel.ForeColor = Color.White;
                    }

                    scheduleLabel.Click += (sender, e) =>
                    {
                        if (selectedLabel != null)
                        {
                            // 현재 선택된 라벨이 클릭되었을 경우
                            if (selectedLabel == scheduleLabel)
                            {
                                selectedLabel.ForeColor = Color.Black; // 기본 색상으로 변경
                                selectedLabel = null; // 선택 해제
                                return; // 메서드 종료
                            }
                            else
                            {
                                selectedLabel.ForeColor = Color.Black; // 이전 선택 해제
                            }
                        }

                        selectedLabel = scheduleLabel; // 현재 라벨 선택
                        selectedLabel.ForeColor = Color.Blue; // 선택된 색상으로 변경
                    };

                    flowLayoutPanel_Schedules.Controls.Add(scheduleLabel);
                }
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                // 선택된 라벨에서 스케줄 정보를 가져옴
                Schedule selectedSchedule = (Schedule)selectedLabel.Tag;

                using (var scheduleCheckForm = new ScheduleCheckForm(selectedSchedule))
                {
                    if (scheduleCheckForm.ShowDialog() == DialogResult.OK)
                    {
                        // 일정이 수정된 후 화면 업데이트
                        ScheduleUpdated?.Invoke(); // 수정된 후 이벤트 발생
                        DisplaySchedules(); // 일정 업데이트
                    }
                }
            }
            else
            {
                        MessageBox.Show("수정할 일정을 선택해 주세요.", "수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                {
                    // 선택된 라벨에서 스케줄 정보를 가져옴
                    Schedule scheduleToDelete = (Schedule)selectedLabel.Tag;

                    // 삭제 확인 메시지 박스
                    DialogResult result = MessageBox.Show($"'{scheduleToDelete.Title}' 일정을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DBHelper dbHelper = new DBHelper();
                        dbHelper.DeleteSchedule(scheduleToDelete.Number); // 스케줄 번호로 삭제

                        // 일정이 삭제된 후 화면 업데이트
                        ScheduleDeleted?.Invoke(); // 삭제 후 이벤트 발생
                        DisplaySchedules(); // 업데이트하여 UI에서 삭제된 일정 표시
                    }
                }

            }
                else
                    {
                        MessageBox.Show("삭제할 일정을 선택해 주세요.", "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
        }

    }
}