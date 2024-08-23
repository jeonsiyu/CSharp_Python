using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;




namespace CsharpProject
{
    public partial class Chart : Form
    {
        //private string currentTime;
        DataReader reader = new DataReader();
        DataManager manager = new DataManager();
        Main m1;

        public Chart(Main form)
        {
            InitializeComponent();
            m1 = form;
            //reader = new DataReader();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> csvFilePaths = GetCSVFilePaths();
            // 콤보박스에 날짜 리스트 할당
            comboBox1.DataSource = csvFilePaths;
            comboBox1.DisplayMember = "FileName";
        }


        private void back_Click(object sender, EventArgs e)
        {

/*            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(panel1.BackColor);

            // 현재 시간을 그래픽으로 표시
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
            g.DrawString(currentTime, Font, Brushes.Black, 10, 10);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedFileName = comboBox1.SelectedItem.ToString();

            string selectedFileName = comboBox1.SelectedItem.ToString();

            // 선택한 파일 이름을 날짜로 변환
            DateTime selectedDate = DateTime.ParseExact(selectedFileName, "yyyy.MM.dd", null);

            // 선택한 날짜에 해당하는 CSV 파일 경로 가져오기
            string filePath = GetCSVFilePath(selectedDate);

            // 선택한 날짜의 CSV 파일 데이터 가져오기
            List<Data> dataList = reader.readDataFile(filePath);

            // CSV 파일의 모든 시간 데이터 가져오기
            List<string> timeList = dataList.Select(data => SplitTime(data.Time)).SelectMany(times => times).Distinct().ToList();

            /////////////new codes///////////////////
            m1.dateTimePicker1.Value = selectedDate;
            Filedir.dir = filePath;
            if(m1.textBox2.Text == string.Empty)
            {
                 m1.textBox1.Text = Filedir.dir;
            }
/*            int[] timesplit = manager.getDateFromFileName2(Filedir.dir);
            comboBox1.SelectedText = "";
            comboBox1.SelectedText = new DateTime(timesplit[0], timesplit[1], timesplit[2]).ToString("yyyy.MM.dd");*/
            //////////////////////////////////////////

            // 그리드뷰에 데이터 바인딩
            dataGridView1.DataSource = dataList;

            // 콤보박스2에 시간 데이터 바인딩
            comboBox2.DataSource = timeList;
        }



        private List<string> GetCSVFilePaths()
        {
            DateTime startDate = new DateTime(2021, 9, 6);
            DateTime endDate = new DateTime(2021, 10, 27);

            List<string> fileNames = new List<string>();

            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                string fileName = currentDate.ToString("yyyy.MM.dd"); // 파일 이름으로 사용할 날짜 포맷
                string filePath = GetCSVFilePath(currentDate);

                if (File.Exists(filePath))
                {
                    fileNames.Add(fileName);
                }

                // 다음 날짜로 이동 (한 날짜씩 증가)
                currentDate = currentDate.AddDays(1);
            }


            return fileNames;
        }

        private string GetCSVFilePath(DateTime date)
        {
            //string folderPath = @"D:\\TEAMPL\\NH\\project\\bin\\Debug\\";
            string folderPath = manager.getFolderNameByFile(Filedir.dir);
            string fileName = $"kemp-abh-sensor-{date:yyyy.MM.dd}.csv";
            string filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private List<string> SplitTime(string time)
        {
            string[] timeParts = time.Split(' '); // 시간과 분을 분리
            string[] hourMinute = timeParts[1].Split(':'); // 시간과 분을 분리

            string hour = hourMinute[0]; // 시간
            string minute = hourMinute[1]; // 분

            // 초 제거
            if (minute.Contains('.'))
                minute = minute.Substring(0, minute.IndexOf('.'));

            string formattedTime = $"오후 {hour}:{minute}"; // 오후와 시간 분을 하나로 합침

            return new List<string> { formattedTime };
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(comboBox1.SelectedItem.ToString(), "yyyy.MM.dd", null);

            // 선택한 날짜에 해당하는 CSV 파일 경로 가져오기
            string filePath = GetCSVFilePath(selectedDate);

            // 선택한 날짜의 CSV 파일 데이터 가져오기
            List<Data> dataList = reader.readDataFile(filePath);

            // 선택한 시간에 해당하는 데이터 가져오기
            string selectedTime = comboBox2.SelectedItem.ToString();
            List<double> tempData = dataList.Where(data => SplitTime(data.Time).Contains(selectedTime))
                                            .Select(data => data.Temp)
                                            .ToList();

            // 차트 초기화 및 데이터 설정
            chart1.Series.Clear();
            chart1.Series.Add("Temperature");
            chart1.Series["Temperature"].ChartType = SeriesChartType.Column;
            chart1.Series["Temperature"].Color = Color.SkyBlue; // 막대 차트의 색상을 회색으로 설정

            for (int i = 0; i < tempData.Count; i++)
            {
                chart1.Series["Temperature"].Points.AddXY(i + 1, tempData[i]);
                chart1.Series["Temperature"].Points[i].Label = tempData[i].ToString(); // 막대 그래프 위에 값 표시
            }

            // Y축 범위 설정
            double maxTemp = tempData.Max();
            chart1.ChartAreas[0].AxisY.Maximum = maxTemp + 5;
            SetChartAxisColor(Color.Black, Color.Black, Color.LightGray);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(comboBox1.SelectedItem.ToString(), "yyyy.MM.dd", null);

            // 선택한 날짜에 해당하는 CSV 파일 경로 가져오기
            string filePath = GetCSVFilePath(selectedDate);

            // 선택한 날짜의 CSV 파일 데이터 가져오기
            List<Data> dataList = reader.readDataFile(filePath);

            // 선택한 시간에 해당하는 "ph" 데이터 가져오기
            string selectedTime = comboBox2.SelectedItem.ToString();
            List<double> phData = dataList.Where(data => SplitTime(data.Time).Contains(selectedTime))
                                          .Select(data => data.pH)
                                          .ToList();

            // 차트 초기화 및 데이터 설정
            chart1.Series.Clear();
            chart1.Series.Add("pH");
            chart1.Series["pH"].ChartType = SeriesChartType.Column;
            chart1.Series["pH"].Color = Color.SkyBlue;

            for (int i = 0; i < phData.Count; i++)
            {
                chart1.Series["pH"].Points.AddXY(i + 1, phData[i]);
                chart1.Series["pH"].Points[i].Label = phData[i].ToString(); // 막대 그래프 위에 값 표시
            }

            // Y축 범위 설정
            double maxPh = phData.Max();
            chart1.ChartAreas[0].AxisY.Maximum = maxPh + 1;
        }
        private void SetChartAxisColor(Color xColor, Color yColor, Color majorGridColor)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = majorGridColor;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = majorGridColor;

            chart1.ChartAreas[0].AxisX.LineColor = xColor;
            chart1.ChartAreas[0].AxisY.LineColor = yColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double maxValue = double.MinValue;

            // 막대의 인덱스
            int maxIndex = -1;

            // 차트의 모든 시리즈에서 최대값을 찾기
            foreach (var series in chart1.Series)
            {
                for (int i = 0; i < series.Points.Count; i++)
                {
                    if (series.Points[i].YValues[0] > maxValue)
                    {
                        maxValue = series.Points[i].YValues[0];
                        maxIndex = i;
                    }
                }
            }

            // 차트의 모든 막대의 색상을 초기화
            foreach (var series in chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    point.Color = Color.SkyBlue; // 원하는 기본 색상으로 설정
                }
            }

            // 최대값에 해당하는 막대를 빨간색으로 설정
            if (maxIndex >= 0)
            {
                foreach (var series in chart1.Series)
                {
                    series.Points[maxIndex].Color = Color.Red;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double minValue = double.MaxValue;

            // 막대의 인덱스
            int minIndex = -1;

            // 차트의 모든 시리즈에서 최소값을 찾기
            foreach (var series in chart1.Series)
            {
                for (int i = 0; i < series.Points.Count; i++)
                {
                    if (series.Points[i].YValues[0] < minValue)
                    {
                        minValue = series.Points[i].YValues[0];
                        minIndex = i;
                    }
                }
            }

            // 차트의 모든 막대의 색상을 초기화
            foreach (var series in chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    point.Color = Color.SkyBlue; // 원하는 기본 색상으로 설정
                }
            }

            // 최소값에 해당하는 막대를 표시할 색상으로 설정
            if (minIndex >= 0)
            {
                foreach (var series in chart1.Series)
                {
                    series.Points[minIndex].Color = Color.Blue;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(comboBox1.SelectedItem.ToString(), "yyyy.MM.dd", null);

            // 선택한 날짜에 해당하는 CSV 파일 경로 가져오기
            string filePath = GetCSVFilePath(selectedDate);

            // 선택한 날짜의 CSV 파일 데이터 가져오기
            List<Data> dataList = reader.readDataFile(filePath);

            // 선택한 시간에 해당하는 데이터 가져오기
            string selectedTime = comboBox2.SelectedItem.ToString();
            List<Data> selectedData = dataList.Where(data => SplitTime(data.Time).Contains(selectedTime)).ToList();

            // 차트 초기화
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("Area"));

            // current 선 그래프 추가
            Series currentSeries = new Series("Current");
            currentSeries.ChartType = SeriesChartType.Line;
            currentSeries.Color = Color.Red;

            // voltage 선 그래프 추가
            Series voltageSeries = new Series("Voltage");
            voltageSeries.ChartType = SeriesChartType.Line;
            voltageSeries.Color = Color.Blue;

            // 데이터 포인트 추가
            for (int i = 0; i < selectedData.Count; i++)
            {
                currentSeries.Points.AddXY(i + 1, selectedData[i].Current);
                voltageSeries.Points.AddXY(i + 1, selectedData[i].Voltage);
            }

            // 꺾이는 부분을 점으로 표시
            for (int i = 0; i < selectedData.Count; i++)
            {
                if (i == 0 || selectedData[i].Current != selectedData[i - 1].Current || selectedData[i].Current != selectedData[i + 1].Current)
                    currentSeries.Points[i].MarkerStyle = MarkerStyle.Circle;

                if (i == 0 || selectedData[i].Voltage != selectedData[i - 1].Voltage || selectedData[i].Voltage != selectedData[i + 1].Voltage)
                    voltageSeries.Points[i].MarkerStyle = MarkerStyle.Circle;
            }

            // 시리즈를 차트에 추가
            chart1.Series.Add(currentSeries);
            chart1.Series.Add(voltageSeries);

            // Y축 범위 설정
            double maxCurrent = selectedData.Max(data => data.Current);
            double maxVoltage = selectedData.Max(data => data.Voltage);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Max(maxCurrent, maxVoltage) + 5;

            // X축 설정
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            SetChartAxisColor(Color.Black, Color.Black, Color.LightGray);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double inputValue = Convert.ToDouble(textBox1.Text);

            // 막대의 인덱스
            //int maxIndex = -1;

            // 차트의 모든 시리즈에서 최대값을 찾기
            foreach (var series in chart1.Series)
            {
                for (int i = 0; i < series.Points.Count; i++)
                {
                    if (series.Points[i].YValues[0] > inputValue)
                    {
                        series.Points[i].Color = Color.Red;
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double inputValue;

                if (double.TryParse(textBox1.Text, out inputValue))
                {
                    foreach (var series in chart1.Series)
                    {
                        foreach (DataPoint point in series.Points)
                        {
                            if (point.YValues[0] > inputValue)
                            {
                                point.Color = Color.Red;
                            }
                            else
                            {
                                // 원래 색상으로 되돌리거나 다른 색상을 설정할 수도 있습니다.
                                point.Color = series.Color;
                            }
                        }
                    }
                }
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double inputValue;

                if (double.TryParse(textBox2.Text, out inputValue))
                {
                    foreach (var series in chart1.Series)
                    {
                        foreach (DataPoint point in series.Points)
                        {
                            if (point.YValues[0] <= inputValue)
                            {
                                point.Color = Color.Blue;
                            }
                            else
                            {
                                // 원래 색상으로 되돌리거나 다른 색상을 설정할 수도 있습니다.
                                point.Color = series.Color;
                            }
                        }
                    }
                }
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
