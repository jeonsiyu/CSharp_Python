using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Project;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{

    public partial class Login : Form
    {
        string strConnection = "User Id=test;Password=1234;Data Source=localhost:1521/XE";
        OracleConnection conn;
        OracleCommand cmd;

        private Point myPoint;

        public Login()
        {
            InitializeComponent();
            textBox_Manager_Code.Text = "Manager001";
            textBox_Manager_ID.Text = "siyou97";
            textBox_Manager_PW.Text = "isiyou9071";

            this.StartPosition = FormStartPosition.CenterScreen;

            // 이벤트 선언
            InitEvent();

            // 새로운 패널 생성 및 설정
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.Transparent; // 필요에 따라 색상 설정

            // 기존 패널을 mainPanel에 추가
            mainPanel.Controls.Add(panel_Right);
            mainPanel.Controls.Add(panel_Left);

            // mainPanel을 폼에 추가
            this.Controls.Add(mainPanel);
            this.Controls.SetChildIndex(mainPanel, 0); // mainPanel이 최상위에 오도록 설정

            // mainPanel에 마우스 이벤트 핸들러 추가
            mainPanel.MouseDown += MainPanel_MouseDown;
            mainPanel.MouseMove += MainPanel_MouseMove;

            // 패널 내부에 다른 컨트롤이 있다면 이들도 마우스 이벤트를 전달할 수 있도록 설정
            foreach (Control control in mainPanel.Controls)
            {
                control.MouseDown += MainPanel_MouseDown;
                control.MouseMove += MainPanel_MouseMove;
            }

            button_Login.Click += new EventHandler(button_Login_Click);
            button_Exit.Click += new EventHandler(button_Exit_Click);
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            myPoint = new Point(e.X, e.Y); // 클릭한 위치를 저장
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = myPoint.X - e.X;
                int y = myPoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        /// <summary>
        /// 이벤트 선언 메서드
        /// </summary>
        private void InitEvent()
        {
            // panel 그라데이션 이벤트 선언
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Gradient);
            this.panel_Right.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient);
        }
        /// <summary>
        /// Panel 컨트롤 그라에디션 효과
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Gradient(object sender, PaintEventArgs e)
        {

            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle,
                                        System.Drawing.Color.Black,
                                        System.Drawing.Color.Black, 0, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);

        }

        /// <summary>
        /// Panel 컨트롤 그라데이션 효과
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_Gradient(object sender, PaintEventArgs e)
        {
            Color stsarColor = System.Drawing.ColorTranslator.FromHtml("#9ecfe6");
            Color MiddlieColor = System.Drawing.ColorTranslator.FromHtml("#969fe5");
            Color EndColor = System.Drawing.ColorTranslator.FromHtml("#d76ddb");
            //Color.FromArgb(0, 0, 0);

            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 2 / 6f, 1 };
            cb.Colors = new[] { stsarColor, MiddlieColor, EndColor };

            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle,
                            System.Drawing.Color.Black,
                            System.Drawing.Color.Black, 0, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);

            br.InterpolationColors = cb;
            br.RotateTransform(45);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // CheckBox 상태에 따라 관리자 코드를 불러옵니다.
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.SavedManagerCode))
            {
                textBox_Manager_Code.Text = Properties.Settings.Default.SavedManagerCode;
                checkBox_Manager_Code.Checked = true; // 체크박스 체크
            }
        }


        private void button_Login_Click(object sender, EventArgs e)
        {
            // 관리자 아이디와 비밀번호, 코드를 입력받는 텍스트 박스의 이름을 설정합니다.
            string managerCode = textBox_Manager_Code.Text; // 관리자 코드
            string managerId = textBox_Manager_ID.Text;     // 관리자 아이디
            string managerPw = textBox_Manager_PW.Text;     // 관리자 비밀번호

            if (DataManager.login(managerCode, managerId, managerPw))
            {
                Hide();
                Main main = new Main();
                main.ShowDialog();
                Show();
                //MessageBox.Show("로그인 성공" + "이름 : " + DataManager.loginedAdmin.manager_name);



                // CheckBox가 체크된 경우 관리자 코드를 저장합니다.
                if (checkBox_Manager_Code.Checked)
                {
                    Properties.Settings.Default.SavedManagerCode = managerCode;
                    Properties.Settings.Default.Save(); // 설정 저장
                }

            }
            else if (string.IsNullOrWhiteSpace(managerCode) || string.IsNullOrWhiteSpace(managerId) || string.IsNullOrWhiteSpace(managerPw))
            {

                MessageBox.Show("제대로 입력해주세요");

            }
            else
            {
                MessageBox.Show("정보가 일치하지 않습니다. 다시 로그인 해주세요!");
                if (checkBox_Manager_Code.Checked)
                {
                    Properties.Settings.Default.SavedManagerCode = managerCode;
                    Properties.Settings.Default.Save(); // 설정 저장
                }

                else
                {
                    textBox_Manager_Code.Clear();
                }

                textBox_Manager_ID.Clear();
                textBox_Manager_PW.Clear();

            }

        }

        public void ClearLoginFields()
        {
            string managerCode = textBox_Manager_Code.Text; // 관리자 코드
            if (checkBox_Manager_Code.Checked)
            {
                Properties.Settings.Default.SavedManagerCode = managerCode;
                Properties.Settings.Default.Save(); // 설정 저장
            }

            else
            {
                textBox_Manager_Code.Clear();
            }

            textBox_Manager_ID.Clear();
            textBox_Manager_PW.Clear();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
