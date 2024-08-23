using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Project
{

    public partial class NContent : Form
    {
        private string selectFilter;
        private string title;

        public NContent(string ID, string Title, string userID, string Date, string Views, string filter, string content)
        {
            InitializeComponent();
            label_Title.Text = Title;
            label_userID.Text = (userID == "siyou97" || userID == "Gri22" || userID == "imgii0801" || userID == "smoo1130")
                                ? label_userID.Text = $"관리자: {userID}"
                                : label_userID.Text = $"작성자: {userID}";

            DateTime date = DateTime.Parse(Date);
            label_Date.Text = $"등록일: {date.ToString("yyyy-MM-dd")}";

            DisplayContent(content);

            title = Title;
            selectFilter = filter;

            button_delect.Click -= new EventHandler(button_delect_Click);
            button_delect.Click += new EventHandler(button_delect_Click);
        }

        private void DisplayContent(string content)
        {
            webBrowser1.DocumentText = content;
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
                        string sqlNotice = "";

                        switch (selectFilter)
                        {
                            case "공략":
                                sql = "DELETE FROM WT_BOARD_POST WHERE wtTitle = :title";
                                sqlNotice = "DELETE FROM NOTICE WHERE noticeTitle = :title AND boardType = 'WT_BOARD_POST'";
                                break;
                            case "모드":
                                sql = "DELETE FROM MOD_BOARD WHERE mTitle = :title";
                                sqlNotice = "DELETE FROM NOTICE WHERE noticeTitle = :title AND boardType = 'MOD_BOARD'";
                                break;
                            case "게임추천":
                                sql = "DELETE FROM SG_BOARD_POST WHERE sgTitle = :title";
                                sqlNotice = "DELETE FROM NOTICE WHERE noticeTitle = :title AND boardType = 'SG_BOARD_POST'";
                                break;
                            case "FAQ":
                                sql = "DELETE FROM FAQ_BOARD_POST WHERE fTitle = :title";
                                sqlNotice = "DELETE FROM NOTICE WHERE noticeTitle = :title AND boardType = 'FAQ_BOARD_POST'";
                                break;
                        }
                        // 일반 게시물 삭제
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("title", title));
                        cmd.ExecuteNonQuery();

                        // 공지사항 삭제 
                        OracleCommand cmdNotice = new OracleCommand(sqlNotice, conn);
                        cmdNotice.Parameters.Add(new OracleParameter("title", title));
                        cmdNotice.ExecuteNonQuery();

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