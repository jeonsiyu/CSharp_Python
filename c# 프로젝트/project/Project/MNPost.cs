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
    public partial class MNPost : Form
    {
        public MNPost()
        {
            InitializeComponent();

            label_manager.Text = "관리자: " + DataManager.loginedAdmin.manager_id;
            button_post.Click -= new EventHandler(button_post_Click);
            button_post.Click += new EventHandler(button_post_Click);
        }

        private void button_post_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 글 번호 
                    string ManagerNoticeID = "SELECT NVL(MAX(ManagerNoticeID), 0) FROM ManagerNotice";
                    OracleCommand getMaxIdCmd = new OracleCommand(ManagerNoticeID, conn);
                    int newId = Convert.ToInt32(getMaxIdCmd.ExecuteScalar()) + 1;

                    string ManagerNoticeTitle = richTextBox_Title.Text;
                    string ManagerNoticeContent = richTextBox_Content.Text;
                    string ManagerNoticeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string Manager_ID = DataManager.loginedAdmin.manager_id;

                    string sql = "INSERT INTO ManagerNotice(ManagerNoticeID, ManagerNoticeTitle, ManagerNoticeContent, ManagerNoticeDate, Manager_ID) " +
                                 "VALUES (:ManagerNoticeID, :ManagerNoticeTitle, :ManagerNoticeContent, :ManagerNoticeDate, :Manager_ID)";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("ManagerNoticeID", newId));
                    cmd.Parameters.Add(new OracleParameter("ManagerNoticeTitle", richTextBox_Title.Text));
                    cmd.Parameters.Add(new OracleParameter("ManagerNoticeContent", richTextBox_Content.Text));
                    cmd.Parameters.Add(new OracleParameter("ManagerNoticeDate", ManagerNoticeDate));
                    cmd.Parameters.Add(new OracleParameter("Manager_ID", Manager_ID));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("게시물이 등록되었습니다.");
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
