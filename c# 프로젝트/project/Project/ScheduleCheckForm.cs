using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ScheduleCheckForm : Form
    {
        public static List<Schedule> Schedules = new List<Schedule>();
        private Schedule selectedSchedule;
        //Schedule scheduled;
        private bool isColorButtonSelected = false; // Color_button 선택 상태를 추적하는 변수
        public ScheduleCheckForm(Schedule schedule)
        {
            InitializeComponent();
            this.selectedSchedule = schedule;
            this.Load += AddScheduleForm_Load;
            //label_number.Visible = true;
            if (schedule.Title == null)
            {
                button1.Text = "추가하기";
            }
            
            else if (schedule.Title!=null)
            {
                button1.Text = "수정하기";
                label_number.Text = schedule.Number.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string title = textBox_Title.Text.Trim();
            DateTime date = dateTimePicker1.Value;
            string startTime = comboBox_Time1.SelectedItem.ToString(); // 시간 시간
            string endTime = comboBox_Time2.SelectedItem.ToString(); // 종료 시간
            Color selectedColor = colorDialog1.Color; // 선택된 색상

            string description = textBox_Note.Text;

            // 입력검증
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("일정 제목을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Title.Focus();
                return;
            }

            if (startTime == "00:00" || endTime == "00:00")
            {
                MessageBox.Show("시작 시간과 종료 시간을 선택해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Time1.Focus();
                return;
            }
            // Color_button이 선택되지 않은 경우
            if (!isColorButtonSelected)
            {
                MessageBox.Show("색상 버튼을 클릭해 색상을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 메서드 종료
            }

       

            Schedule newSchedule = new Schedule(
            textBox_Title.Text.Trim(),              // 제목
            dateTimePicker1.Value,                  // 날짜
            comboBox_Time1.SelectedItem.ToString(), // 시작 시간
            comboBox_Time2.SelectedItem.ToString(), // 종료 시간
            selectedColor,                     // 색상
            textBox_Note.Text.Trim()                // 설명
            );
            if ( (sender as Button).Text.Equals("수정하기"))
            {
                newSchedule.Number = int.Parse(label_number.Text);
                selectedSchedule.Title = newSchedule.Title;
                selectedSchedule.StartTime = newSchedule.StartTime;
                selectedSchedule.EndTime = newSchedule.EndTime;
                selectedSchedule.Date = newSchedule.Date;
                selectedSchedule.Description = newSchedule.Description;
                selectedSchedule.Color = newSchedule.Color;

            }

            DBHelper dbHelper = new DBHelper();

            dbHelper.SaveSchedule(newSchedule);/////////////////여 기

            // 일정 저장 로직 (예: 데이터베이스 또는 파일에 저장)
            SaveSchedule(title, date, startTime, endTime, selectedColor, description);
           //  MessageBox.Show("일정이 추가되었습니다.");
            if ((sender as Button).Text.Equals("추가하기"))
            {

                MessageBox.Show("일정이 추가되었습니다.");
              
            }
            else if ((sender as Button).Text.Equals("수정하기"))
            {
                MessageBox.Show("일정이 수정되었습니다.");
            }

            //성공적으로 추가되었음을 알리기 위해 DialogResult 설정
            this.DialogResult = DialogResult.OK;
            this.Close(); // 폼 닫기

        }

        private void SaveSchedule(string title, DateTime date, string startTime, string endTime, Color color, string description)
        {
            // 예를 들어, 데이터베이스에 저장하거나 리스트에 추가하는 등  
            var schedule = new Schedule(title, date, startTime, endTime, color, description);

            Schedules.Add(schedule); // 리스트에 추가
        }

        private void AddScheduleForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = selectedSchedule.Date; // 선택한 날짜를 dateTimePicker에 설정
            // 시간 정보를 콤보박스에 추가 (0시부터 23시까지)
            for (int hour = 0; hour < 24; hour++)
            {
                comboBox_Time1.Items.Add($"{hour:D2}:00"); // 시작 시간 (정각)
                comboBox_Time1.Items.Add($"{hour:D2}:30"); // 시작 시간 (30분)

                comboBox_Time2.Items.Add($"{hour:D2}:00"); // 종료 시간 (정각)
                comboBox_Time2.Items.Add($"{hour:D2}:30"); // 종료 시간 (30분)
            }


            LoadScheduleData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadScheduleData()
        {
            textBox_Title.Text = selectedSchedule.Title;
            dateTimePicker1.Value = selectedSchedule.Date;
            comboBox_Time1.SelectedItem = selectedSchedule.StartTime;
            comboBox_Time2.SelectedItem = selectedSchedule.EndTime;
            colorDialog1.Color = selectedSchedule.Color;
            textBox_Note.Text = selectedSchedule.Description;

            // 기본 선택 값 설정
            if (comboBox_Time1.Items.Count > 0 && selectedSchedule.StartTime==null)
                comboBox_Time1.SelectedIndex = 0; // 기본 시작 시간 선택

            if (comboBox_Time2.Items.Count > 0 && selectedSchedule.EndTime==null)
                comboBox_Time2.SelectedIndex = 0; // 기본 종료 시간 선택 (00시 30분으로 설정)
        }

        private void Color_button_Click(object sender, EventArgs e)
        {
            isColorButtonSelected = true;
            colorDialog1.ShowDialog();
        }
    }
}
