using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Main : Form
    {
        private Home home;
        private Member member;
        private Question question;
        private Notice notice;

        public Main()
        {
            InitializeComponent();

            // 폼 속성
            home = new Home { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            member = new Member { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            question = new Question { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            notice = new Notice { TopLevel = false, FormBorderStyle = FormBorderStyle.None };

            // 패널에 폼 추가 (보이기/숨기기 제어 위해)
            panel_main.Controls.Add(home);
            panel_main.Controls.Add(member);
            panel_main.Controls.Add(question);
            panel_main.Controls.Add(notice);

            // 초기 panel에 homeForm 보이기
            ShowHomeForm();

            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);
            button_Logout.Click += new EventHandler(button_Logout_Click);

            label_Welcome_Create();
            InitEvent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showForm(home);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showForm(member);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showForm(question);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showForm(notice);
        }

        private void showForm(Form form)
        {
            HideAllForms();

            // 폼 보이기
            panel_main.Controls.Add(form);
            form.Show();
        }

        private void HideAllForms()
        {
            foreach (Control control in panel_main.Controls)
            {
                if (control is Form form)
                {
                    form.Hide();
                }
            }
        }
        private void ShowHomeForm()
        {
            panel_main.Controls.Add(home);
            home.Show();
        }

        private void InitEvent()
        {
            // panel 그라데이션 이벤트 선언
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Gradient);
            this.panel_Main_Top.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient);

            // Resize 이벤트 등록
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void Form_Gradient(object sender, PaintEventArgs e)
        {
            try
            {
                LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle,
                                            System.Drawing.Color.White,
                                            System.Drawing.Color.White, 0, false);
                e.Graphics.FillRectangle(br, this.ClientRectangle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("화면 최소화하면 발생하는 오류");
            }
        }

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
                            System.Drawing.Color.White,
                            System.Drawing.Color.White, 0, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);

            br.InterpolationColors = cb;
            br.RotateTransform(45);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // 폼을 다시 그리도록 요청 -> 현재 컨트롤을 다시 그리도록 요청하는 메서드
        }

        private void label_Welcome_Create()
        {
            // 저장된 데이터를 가져와서 환영하기(?)          
            label_Welcome.Text = $"{DataManager.loginedAdmin.manager_name}님 환영합니다!";
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            // 로그아웃 시 로그인 폼의 텍스트 박스를 초기화
            Login loginForm = (Login)Application.OpenForms["Login"];
            if (loginForm != null)
            {
                loginForm.ClearLoginFields();  // 텍스트 박스를 초기화하는 메서드 호출
            }
            DataManager.loginedAdmin = null;

            Close();
        }
    }
}
