using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Managers : Form
    {
        public Managers()
        {
            InitializeComponent();

            richTextBox_chatting.ReadOnly = true;
            button_send.Click += new EventHandler(button_send_Click);
            this.Load += new EventHandler(Managers_Load);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string chatContent = richTextBox_chat.Text;
                    string managerID = DataManager.loginedAdmin.manager_id;
                    DateTime cDate = DateTime.Now;

                    string sql = "INSERT INTO CHAT(chatContent, Manager_ID, cDate) VALUES (:chatContent, :ManagerID, :cDate)";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("chatContent", richTextBox_chat.Text));
                    cmd.Parameters.Add(new OracleParameter("ManagerID", managerID));
                    cmd.Parameters.Add(new OracleParameter("cDate", cDate));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }

            if (!string.IsNullOrEmpty(richTextBox_chat.Text))
            {
                // RichTextBox에 텍스트 추가
                //richTextBox_chatting.AppendText($"{DateTime.Now:MM/dd hh:mm:ss}  {DataManager.loginedAdmin.manager_id} : {richTextBox_chat.Text}" + Environment.NewLine);

                // 날짜 시간 텍스트 스타일 설정
                int startIndex = richTextBox_chatting.TextLength; // 시작 인덱스 저장
                richTextBox_chatting.AppendText($"{DateTime.Now:MM/dd hh:mm:ss}  "); // 날짜 시간 추가
                richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex); // 날짜 시간 텍스트 선택
                richTextBox_chatting.SelectionColor = Color.DarkGray; // 색상 변경 (예: 파란색)
                richTextBox_chatting.SelectionFont = new Font("경기천년제목", 10, FontStyle.Bold);


                // 관리자 ID 텍스트 스타일 설정
                startIndex = richTextBox_chatting.TextLength; // 시작 인덱스 저장
                richTextBox_chatting.AppendText($"{DataManager.loginedAdmin.manager_id} : "); // 관리자 ID 추가
                richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex); // 관리자 ID 텍스트 선택
                if (DataManager.loginedAdmin.manager_id == "siyou97")
                {
                    richTextBox_chatting.SelectionColor = Color.LightSalmon;
                }
                else if (DataManager.loginedAdmin.manager_id == "Gri22")
                {
                    richTextBox_chatting.SelectionColor = Color.LightGreen;
                }
                else if (DataManager.loginedAdmin.manager_id == "imgii0801")
                {
                    richTextBox_chatting.SelectionColor = Color.LightBlue;
                }
                else
                {
                    richTextBox_chatting.SelectionColor = Color.LightPink;
                }

                richTextBox_chatting.SelectionFont = new Font("경기천년제목", 10, FontStyle.Bold);
                // 메시지 추가

                startIndex = richTextBox_chatting.TextLength;
                richTextBox_chatting.AppendText($"{richTextBox_chat.Text}" + Environment.NewLine); // 메시지 추가
                richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex);
                richTextBox_chatting.SelectionColor = Color.Black;

                // 텍스트박스 비움
                richTextBox_chat.Clear();
            }
        }

        private void Managers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * FROM CHAT ORDER BY cDATE ";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string managerID = reader["Manager_ID"].ToString();
                        string chatContent = reader["chatContent"].ToString();
                        DateTime cDate = reader.GetDateTime(reader.GetOrdinal("cDate"));

                        //  richTextBox_chatting.AppendText($"{cDate:MM/dd hh:mm:ss}  { managerID} : { chatContent}" + Environment.NewLine);

                        // 날짜 시간 텍스트 스타일 설정
                        int startIndex = richTextBox_chatting.TextLength; // 시작 인덱스 저장
                        richTextBox_chatting.AppendText($"{cDate:MM/dd hh:mm:ss}  "); // 날짜 시간 추가
                        richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex); // 날짜 시간 텍스트 선택
                        richTextBox_chatting.SelectionColor = Color.DarkGray; // 색상 변경
                        richTextBox_chatting.SelectionFont = new Font("경기천년제목", 10, FontStyle.Bold);


                        // 관리자 ID 텍스트 스타일 설정
                        startIndex = richTextBox_chatting.TextLength; // 시작 인덱스 저장
                        richTextBox_chatting.AppendText($"{managerID} : "); // 관리자 ID 추가
                        richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex); // 관리자 ID 텍스트 선택
                                                                                                               // 조건문으로 색상 변경
                        if (managerID == "siyou97")
                        {
                            richTextBox_chatting.SelectionColor = Color.DarkSalmon;
                        }
                        else if (managerID == "Gri22")
                        {
                            richTextBox_chatting.SelectionColor = Color.DarkGreen;
                        }
                        else if (managerID == "imgii0801")
                        {
                            richTextBox_chatting.SelectionColor = Color.DarkCyan;
                        }
                        else
                        {
                            richTextBox_chatting.SelectionColor = Color.DeepPink;
                        }

                        richTextBox_chatting.SelectionFont = new Font("경기천년제목", 10, FontStyle.Bold);

                        startIndex = richTextBox_chatting.TextLength;
                        richTextBox_chatting.AppendText($"{chatContent}" + Environment.NewLine); // 메시지 추가        
                        richTextBox_chatting.Select(startIndex, richTextBox_chatting.TextLength - startIndex);
                        richTextBox_chatting.SelectionColor = Color.Black;
                        richTextBox_chat.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}