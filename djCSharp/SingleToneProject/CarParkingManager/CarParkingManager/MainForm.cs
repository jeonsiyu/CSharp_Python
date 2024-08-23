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

namespace CarParkingManager
{
    public partial class MainForm : Form
    {
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
                //writeLog("주차 버튼 테스트");
            };
            button_outParking.Click += (s, e) =>
            {
                //writeLog("출차 버튼 테스트");
            };
            button_insert.Click += Button_insert_Click;
            button_delete.Click += Button_delete_Click;
            button_select.Click += Button_select_Click;
            button_selectAll.Click += Button_selectAll_Click;
        }

        private void Button_selectAll_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_select_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_insert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void writeLog(string v)
        {
            string contents = $"[{DateTime.Now.ToString()}]";
            contents += v;
            DataManager.Instance.printLog(contents);
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
