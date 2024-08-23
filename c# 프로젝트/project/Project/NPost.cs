using Oracle.ManagedDataAccess.Client;
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
    public partial class NPost : Form
    {
        private string selectFilter;

        public NPost(string selectFilter)
        {
            InitializeComponent();
            this.selectFilter = selectFilter;
            label_manager.Text = "관리자: " + DataManager.loginedAdmin.manager_id;
            button_post.Click -= new EventHandler(button_post_Click);
            button_post.Click += new EventHandler(button_post_Click);
        }

        private string tablename(string filter)
        {
            switch (filter)
            {
                case "공략":
                    return "WT_BOARD_POST";
                case "모드":
                    return "MOD_BOARD";
                case "게임추천":
                    return "SG_BOARD_POST";
                case "FAQ":
                    return "FAQ_BOARD_POST";
                default:
                    return null;
            }
        }

        private void button_post_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                { 
                    conn.Open();

                    string noticeID = "공지";
                    string noticetTitle = richTextBox_Content.Text;
                    string noticeContent = richTextBox_Title.Text;
                    string noticeDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string boardType = tablename(selectFilter);
                    string managerID = DataManager.loginedAdmin.manager_id;


                    string sql = "INSERT INTO NOTICE(noticeID, boardType, noticeTitle, noticeContent, noticeDate, Manager_ID) " +
                                "VALUES (:noticeID, :boardType, :noticeTitle, :noticeContent, :noticeDate, :ManagerID)";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("noticeID", noticeID));
                    cmd.Parameters.Add(new OracleParameter("boardType", boardType));
                    cmd.Parameters.Add(new OracleParameter("noticeTitle", richTextBox_Title.Text));
                    cmd.Parameters.Add(new OracleParameter("noticeContent", richTextBox_Content.Text));
                    cmd.Parameters.Add(new OracleParameter("noticeDate", noticeDate));
                    cmd.Parameters.Add(new OracleParameter("manager_ID", managerID));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("공지사항이 등록되었습니다.");
                    this.Close();
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