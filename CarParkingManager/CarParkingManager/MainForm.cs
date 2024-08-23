using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CarParkingManager
{
    public partial class MainForm : Form
    {
        delegate string lookUpFunc(int ps);
        public MainForm()
        {
            InitializeComponent();
            label_now.Text = DateTime.Now.ToString() ;

            try
            {
                textBox_parkingSpot.Text = DataManager.Instance.parkingAreas[0].parkingSpot + "";
                textBox_carNumber.Text = DataManager.Instance.parkingAreas[0].carNumber;
                textBox_driverName.Text = DataManager.Instance.parkingAreas[0].driverName;
                textBox_phoneNumber.Text = DataManager.Instance.parkingAreas[0].phoneNumber;
                textBox_parkingSpotArea.Text = textBox_parkingSpot.Text;
            }
            catch (Exception ex)
            {
            }
            if (DataManager.Instance.parkingAreas.Count > 0)
                parkingCarBindingSource.DataSource = DataManager.Instance.parkingAreas;
            dataGridView_parkingCar.CellClick += (s, e) =>
            {
                ParkingCar p = (s as DataGridView).CurrentRow.DataBoundItem as ParkingCar;
                textBox_parkingSpot.Text = p.parkingSpot.ToString();
                textBox_carNumber.Text = p.carNumber;
                textBox_driverName.Text = p.driverName;
                textBox_phoneNumber.Text = p.phoneNumber;
                textBox_parkingSpotArea.Text = textBox_parkingSpot.Text;
            };
            button_inParking.Click += (s, e) =>
            {
                if (textBox_parkingSpot.Text.Trim().Equals(""))
                    MessageBox.Show("주차 공간 입력하셔야 주차를 하실 수 있습니다.");
                else if (textBox_parkingSpot.Text.Trim().Equals(""))
                    MessageBox.Show("차량 번호를 알아야 주차를 하실 수 있습니다.");
                else
                {
                    try
                    {
                        ParkingCar p = DataManager.Instance.parkingAreas.Single(c => c.parkingSpot.ToString().Equals(textBox_parkingSpot.Text));

                        if (p.carNumber.Trim().Equals("") == false)
                            MessageBox.Show("이 곳엔 이미 차가 있어서 주차할 수 없어요.");
                        else //해당 공간이 비어서 주차가 가능한 경우
                        {
                            p.carNumber = textBox_carNumber.Text;
                            p.driverName = textBox_driverName.Text;
                            p.phoneNumber = textBox_phoneNumber.Text;
                            p.parkingTime = DateTime.Now;

                            parkingCarBindingSource.DataSource = null;
                            parkingCarBindingSource.DataSource = DataManager.Instance.parkingAreas;

                            DataManager.Instance.Save(p);
                            string contents = $"주차 공간 {textBox_parkingSpot.Text}에 " +
                            $"{textBox_carNumber.Text}차를 주차했습니다.";
                            writeLog(contents);
                            MessageBox.Show(contents);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("주차 공간 " + textBox_parkingSpot.Text + "는 없습니다.");
                        writeLog("주차 공간 " + textBox_parkingSpot.Text + "는 없습니다.");
                    }
                }
            };
            button_outParking.Click += (s, e) =>
            {
                if (textBox_parkingSpot.Text.Equals(""))
                    MessageBox.Show("주차 공간 번호를 알아야 출차가 됩니다.");
                else
                {
                    try
                    {
                        ParkingCar p = DataManager.Instance.parkingAreas.Single
                        (c => c.parkingSpot.ToString().Equals(textBox_parkingSpot.Text));
                        if (p.carNumber.Equals(""))
                            MessageBox.Show("아직 차가 없으니 출차 안 됩니다.");
                        else
                        {
                            string oldCar = p.carNumber;//전에 주차한 차 정보
                            p.carNumber = "";
                            p.driverName = "";
                            p.phoneNumber = "";
                            p.parkingTime = new DateTime();

                            parkingCarBindingSource.DataSource = null;
                            parkingCarBindingSource.DataSource = DataManager.Instance.parkingAreas;

                            DataManager.Instance.Save(p, true);
                            string contents = $"주차 공간 {textBox_parkingSpot.Text}에 {oldCar} 차 출차";
                            writeLog(contents);
                            MessageBox.Show(contents);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"출차 불가능 {textBox_parkingSpot.Text} 없음");
                        writeLog($"출차 불가능 {textBox_parkingSpot.Text} 없음");
                    }
                }
            };

            button_select.Click += Button_select_Click;
            button_insert.Click += Button_insert_Click;
            button_delete.Click += Button_delete_Click;
            button_selectAll.Click += Button_selectAll_Click;
        }

        private void Button_selectAll_Click(object sender, EventArgs e)
        {
            DataManager.Instance.Load();
            parkingCarBindingSource.DataSource = null;
            if (DataManager.Instance.parkingAreas.Count > 0)
                parkingCarBindingSource.DataSource = DataManager.Instance.parkingAreas;
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox_parkingSpotArea.Text, out int parkingSpot);
            psManager(parkingSpot, "delete");
        }

        private void Button_insert_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox_parkingSpotArea.Text, out int parkingSpot);
            psManager(parkingSpot, "insert");
        }
        private void psManager(int parkingSpot, string v)
        {
            if (parkingSpot <= 0)
            {
                writeLog("주차 공간 번호는 0 이상의 숫자여야 합니다.");
                MessageBox.Show("주차 공간 번호는 0 이상의 숫자여야 합니다.");
                return; //메서드 종료(이벤트 종료)
            }
            string contents = "";//로그에 넣을 값
            //v = insert or delete 즉 cmd
            //text = ps
            bool check = DataManager.Instance.Save(v, parkingSpot, out contents);
            if (check) //성공하였다면
                button_selectAll.PerformClick();//리프래시
            MessageBox.Show(contents);
            writeLog(contents);
        }

        private void Button_select_Click(object sender, EventArgs e)
        {
            try
            {

                lookUpFunc findPsCar = delegate (int ps)
                {
                    foreach (var item in DataManager.Instance.parkingAreas)
                    {
                        if (item.parkingSpot == ps)
                        {
                            return item.carNumber;
                        }
                    }
                    return "";
                };
                int.TryParse(textBox_parkingSpotArea.Text, out int parkingSpot);

                string parkingCar = findPsCar(parkingSpot);
                string contents = "";
                if (parkingCar.Trim() != "") //Equals 대신 ==으로도 문자열 비교 가능(C#)
                    contents = $"주차공간 {textBox_parkingSpotArea.Text}에 주차된 차는 {parkingCar}!";
                else
                    contents = $"주차공간 {textBox_parkingSpotArea.Text}에 주차된 차는 없습니다!";
                writeLog(contents);
                MessageBox.Show(contents);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                writeLog(ex.Message);
            }
        }

        private void writeLog(string v)
        {
            string contents = $"[{DateTime.Now.ToString()}]";
            contents += v;
            DataManager.printLog(contents);
            listBox_log.Items.Insert(0, contents); //최신 내용이 맨 위에 가게 됨
            //최신 내용이 맨 밑에 있게 하려면 Add를 쓰면 됨
            //listBox_log.Items.Add(contents);
        }

        private void timer_now_Tick(object sender, EventArgs e)
        {
            label_now.Text = DateTime.Now.ToString();
        }
    }
}
