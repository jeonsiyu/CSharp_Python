using Oracle.ManagedDataAccess.Client;
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
    public partial class Home : Form
    {
        public calender CalenderForm = new calender();
        public Home()
        {
            InitializeComponent();
            LoadCalenderForm();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click -= new EventHandler(button3_Click);
            button3.Click += new EventHandler(button3_Click);

            board();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calender calender = new calender(true);
            calender.ShowDialog();
            for (int i = 0; i < CalenderForm.Days.Count; i++)
            {
                CalenderForm.Days[i].DisplaySchedules();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Managers m = new Managers();
            m.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerNotice mn = new ManagerNotice();
            mn.FormClosed += new FormClosedEventHandler(ManagerNotice_FormClosed);
            mn.ShowDialog();
        }

        private void LoadCalenderForm()
        {
            ConfigureScrollPanel(); // 스크롤 패널 설정 추가
            CalenderForm.TopLevel = false; // TopLevel을 false로 설정
            CalenderForm.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
            CalenderForm.Dock = DockStyle.None; // Dock을 None으로 설정하여 크기를 조정할 수 있도록 함
            panel9.Dock = DockStyle.None;
            panel9.Controls.Clear(); // 패널에 있는 기존 컨트롤 제거
            panel9.Controls.Add(CalenderForm); // 폼을 패널에 추가
            CalenderForm.Show(); // 폼 표시

            // 패널 크기에 맞게 폼 크기 조정
            AdjustFormAndControlsSize(CalenderForm, panel9.ClientSize);
        }

        private void ConfigureScrollPanel()
        {
            panel9.AutoScroll = true; // 스크롤 가능하도록 설정
            panel9.VerticalScroll.Enabled = true; // 수직 스크롤 허용

        }

        private void AdjustFormAndControlsSize(Form form, Size panelSize)
        {
            // 기본 폼 크기 (설계 시에 설정한 크기)
            //1100, 895 
            Size baseSize = new Size(1000, 600); // 설계 시 폼의 기준 크기 Size(1250,650)
            float widthFactor = (float)panelSize.Width / baseSize.Width;
            float heightFactor = (float)panelSize.Height / baseSize.Height;
            float scaleFactor = Math.Min(widthFactor, heightFactor); // 비율을 사용하여 축소

            // 폼 크기 조정
            form.Size = new Size((int)(baseSize.Width * widthFactor), (int)(baseSize.Height * heightFactor));

            // 각 컨트롤의 크기 및 위치 조정
            foreach (Control control in form.Controls)
            {
                control.Width = (int)(control.Width * widthFactor);
                control.Height = (int)(control.Height * heightFactor);
                control.Left = (int)(control.Left * widthFactor) + 7; // 건들지 않아도됨
                control.Top = (int)(control.Top * heightFactor) - 65;
                control.Font = new Font(control.Font.FontFamily, control.Font.Size * scaleFactor);
            }
        }

        private void board()
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 각 게시판 게시물 수 조회
                    string sql1 = "SELECT COUNT(*) FROM WT_BOARD_POST WHERE wtDate >= '2024-08-01'";
                    string sql2 = "SELECT COUNT(*) FROM MOD_BOARD WHERE mDate >= '2024-08-01'";
                    string sql3 = "SELECT COUNT(*) FROM SG_BOARD_POST WHERE sgDate >= '2024-08-01'";
                    string sql4 = "SELECT COUNT(*) FROM FAQ_BOARD_POST WHERE fDate >= '2024-08-01'";

                    OracleCommand cmd1 = new OracleCommand(sql1, conn);
                    int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    label_wt.Text = "공략 : " + count1.ToString();

                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    int count2 = Convert.ToInt32(cmd2.ExecuteScalar());
                    label_m.Text = "모드 : " + count2.ToString();

                    OracleCommand cmd3 = new OracleCommand(sql3, conn);
                    int count3 = Convert.ToInt32(cmd3.ExecuteScalar());
                    label_sg.Text = "게임추천 : " + count3.ToString();

                    OracleCommand cmd4 = new OracleCommand(sql4, conn);
                    int count4 = Convert.ToInt32(cmd4.ExecuteScalar());
                    label_f.Text = "FAQ : " + count4.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void LoadData()
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Manager_ID AS \"작성자\", ManagerNoticeTitle AS \"제목\" " +
                                 "FROM ManagerNotice ORDER BY ManagerNoticeDate DESC";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ManagerNotice");

                    label_title1.Click -= Label_Click;
                    label_title2.Click -= Label_Click;
                    label_title3.Click -= Label_Click;
                    label_title4.Click -= Label_Click;

                    // 최신 데이터 5개 라벨에 표시
                    if (ds.Tables["ManagerNotice"].Rows.Count > 0)
                    {
                        DataRow row1 = ds.Tables["ManagerNotice"].Rows[0];
                        label_manager1.Text = row1["작성자"].ToString();
                        label_title1.Text = row1["제목"].ToString();
                        label_title1.Tag = row1;  // Tag에 DataRow 저장
                        label_title1.Click += Label_Click;
                    }
                    if (ds.Tables["ManagerNotice"].Rows.Count > 1)
                    {
                        DataRow row2 = ds.Tables["ManagerNotice"].Rows[1];
                        label_manager2.Text = row2["작성자"].ToString();
                        label_title2.Text = row2["제목"].ToString();
                        label_title2.Tag = row2;  // Tag에 DataRow 저장
                        label_title2.Click += Label_Click;
                    }
                    if (ds.Tables["ManagerNotice"].Rows.Count > 2)
                    {
                        DataRow row3 = ds.Tables["ManagerNotice"].Rows[2];
                        label_manager3.Text = row3["작성자"].ToString();
                        label_title3.Text = row3["제목"].ToString();
                        label_title3.Tag = row3;  // Tag에 DataRow 저장
                        label_title3.Click += Label_Click;
                    }
                    if (ds.Tables["ManagerNotice"].Rows.Count > 3)
                    {
                        DataRow row4 = ds.Tables["ManagerNotice"].Rows[3];
                        label_manager4.Text = row4["작성자"].ToString();
                        label_title4.Text = row4["제목"].ToString();
                        label_title4.Tag = row4;  // Tag에 DataRow 저장
                        label_title4.Click += Label_Click;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void ManagerNotice_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            DataRow row = clickedLabel.Tag as DataRow;

            if (row != null)
            {
                string Manager_ID = row["작성자"].ToString();
                string ManagerNoticeTitle = row["제목"].ToString();

                string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "SELECT ManagerNoticeContent, ManagerNoticeDate FROM ManagerNotice WHERE ManagerNoticeTitle = :title";
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("title", ManagerNoticeTitle));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ManagerNoticeContent = reader["ManagerNoticeContent"].ToString();
                                string ManagerNoticeDate = reader["ManagerNoticeDate"].ToString();

                                // MNContent 폼에 데이터를 전달하여 표시
                                MNContent mn = new MNContent(ManagerNoticeTitle, Manager_ID, ManagerNoticeContent, ManagerNoticeDate);
                                mn.FormClosed += new FormClosedEventHandler(MNContent_FormClosed);
                                mn.ShowDialog();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류: {ex.Message}");
                    }
                }
            }
        }
        private void MNContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
    }
}