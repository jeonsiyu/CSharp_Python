using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Project
{
    public partial class MNContent : Form
    {
        private string title;
        public MNContent(string ManagerNoticeTitle, string Manager_ID, string ManagerNoticeContent, string ManagerNoticeDate)
        {
            InitializeComponent();

            label_Title.Text = ManagerNoticeTitle;
            label_ManagerID.Text = "관리자: " + DataManager.loginedAdmin.manager_id;
            label_Content.Text = ManagerNoticeContent;
            DateTime date = DateTime.Parse(ManagerNoticeDate);
            label_Date.Text = $"등록일: {date.ToString("yyyy-MM-dd")}";
            title = ManagerNoticeTitle;

            button_delect.Click -= new EventHandler(button_delect_Click);
            button_delect.Click += new EventHandler(button_delect_Click);
        }

        private void button_delect_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    var result = MessageBox.Show("게시물을 삭제하시겠습니까?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql = "";
                        sql = "DELETE FROM ManagerNotice WHERE ManagerNoticeTitle = :title";
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("title", title));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("삭제되었습니다.");
                        this.Close();
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
