using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Project
{
    public partial class TotalMember : Form
    {
        public TotalMember()
        {
            InitializeComponent();
            comboBox.Items.Add("ID");
            comboBox.Items.Add("이름");
            comboBox.SelectedIndex = 0;

            button1.Click += new EventHandler(button1_Click);
            button_search.Click += new EventHandler(button_search_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT member_id AS \"ID\", member_pw AS \"비밀번호\", member_name AS \"이름\", member_email AS \"이메일\", " +
                                "member_birth AS \"생년월일\", member_gender AS \"성별\",  member_nation AS \"국적\", member_phone AS \"연락처\", member_join_date AS \"가입일\" " +
                                "FROM GAME_MEMBER";
                    
                    OracleCommand cmd = new OracleCommand(sql, conn);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GAME_MEMBER");

                    dataGridView1.DataSource = ds.Tables["GAME_MEMBER"];

                    int rowCount = dataGridView1.Rows.Count-1;
                    label_Total.Text = "전체 멤버 수: " + rowCount.ToString();
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

        private void button_search_Click(object sender, EventArgs e)
        {
            string member_name = textBox_search.Text.Trim();
            string filter = comboBox.SelectedItem.ToString();
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string selectedDay = dateTimePicker.Value.ToString("yyyy-MM-dd");

            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT member_id AS \"ID\", member_pw AS \"비밀번호\", member_name AS \"이름\", member_email AS \"이메일\", " +
                                "member_birth AS \"생년월일\", member_gender AS \"성별\",  member_nation AS \"국적\", member_phone AS \"연락처\", member_join_date AS \"가입일\" " +
                                "FROM GAME_MEMBER WHERE member_join_date BETWEEN :SelectedDay AND :Today";

                    if (!string.IsNullOrEmpty(member_name))
                    {
                        switch (filter)
                        {
                            case "ID":
                                sql += " AND member_id = :SearchText";
                                break;
                            case "이름":
                                sql += " AND member_name = :SearchText";
                                break;
                        }
                    }

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("SelectedDay", selectedDay));
                    cmd.Parameters.Add(new OracleParameter("Today", today));

                    if (!string.IsNullOrEmpty(member_name))
                    {
                        cmd.Parameters.Add(new OracleParameter("SearchText", member_name));
                    }

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GAME_MEMBER");

                    dataGridView1.DataSource = ds.Tables["GAME_MEMBER"];

                    int rowCount = dataGridView1.Rows.Count - 1;
                    label_search.Text = "검색된 회원 수: " + rowCount.ToString();
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

        private void TotalMember_Load(object sender, EventArgs e)
        {

        }
    }
}