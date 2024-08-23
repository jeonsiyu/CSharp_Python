using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class QContent : Form
    {
        private string fTitle;
        public QContent(string fTitle, string userID, string fContent, string fDate, string answer)
        {
            InitializeComponent();
            label_Title.Text = fTitle;
            label_userID.Text = $"작성자: {userID}";
            DateTime date = DateTime.Parse(fDate);
            label_Date.Text = $"등록일: {date.ToString("yyyy-MM-dd")}";
            label_Content.Text = fContent;
            richTextBox_answer.Text = answer;

            this.fTitle = fTitle;
            button_answer.Click += new EventHandler(button_answer_Click);
        }

        private void button_answer_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string answerText = richTextBox_answer.Text;

                    string status = string.IsNullOrEmpty(answerText) ? "" : "답변완료";

                    string sql = "UPDATE FAQ_BOARD_POST SET answer = :answer, status = :status WHERE fTitle = :fTitle";
                    OracleCommand cmd = new OracleCommand(sql, conn);

                    cmd.Parameters.Add(new OracleParameter("answer", richTextBox_answer.Text));
                    cmd.Parameters.Add(new OracleParameter("status", status));
                    cmd.Parameters.Add(new OracleParameter("fTitle", fTitle));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("답변이 저장되었습니다.");

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