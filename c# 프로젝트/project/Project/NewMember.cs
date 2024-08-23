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
using static System.Windows.Forms.AxHost;

namespace Project
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
            comboBox.Items.Add("ID");
            comboBox.Items.Add("이름");
            comboBox.SelectedIndex = 0;

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
                    string sql ="SELECT member_id AS \"ID\", member_pw AS \"비밀번호\", member_name AS \"이름\", member_email AS \"이메일\", " +
                                "member_birth AS \"생년월일\", member_gender AS \"성별\",  member_nation AS \"국적\", member_phone AS \"연락처\", member_join_date AS \"가입일\" " +
                                "FROM GAME_MEMBER WHERE member_join_date >= '2024-08-01'";
                    OracleCommand cmd = new OracleCommand(sql, conn);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GAME_MEMBER");   // DataSet을 채움, "GAME_MEMBER"라는 이름으로 테이블 생성

                    dataGridView1.DataSource = ds.Tables["GAME_MEMBER"];

                    int rowCount = dataGridView1.Rows.Count;
                    label_newMember.Text = "신규 멤버 수: " + rowCount.ToString();
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
            string member_id = textBox_search.Text.Trim();     // 텍스트박스에서 입력된 아이디를 가져옴
            string filter = comboBox.SelectedItem.ToString(); // 콤보박스에서 선택된 필터를 가져옴

            if (!string.IsNullOrEmpty(textBox_search.Text))
            {
                string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    try
                    {
                        string sql = "";

                        switch (filter)
                        {
                            case "ID":
                                sql = "SELECT member_id AS \"ID\", member_pw AS \"비밀번호\", member_name AS \"이름\", member_email AS \"이메일\", " +
                                "member_birth AS \"생년월일\", member_gender AS \"성별\",  member_nation AS \"국적\", member_phone AS \"연락처\", member_join_date AS \"가입일\" " +
                                        "FROM GAME_MEMBER WHERE member_id = :SearchText AND member_join_date >= '2024'";
                                break;
                            case "이름":
                                sql = "SELECT member_id AS \"ID\", member_pw AS \"비밀번호\", member_name AS \"이름\", member_email AS \"이메일\", " +
                                "member_birth AS \"생년월일\", member_gender AS \"성별\",  member_nation AS \"국적\", member_phone AS \"연락처\", member_join_date AS \"가입일\" " +
                                        "FROM GAME_MEMBER WHERE member_name = :SearchText AND member_join_date >= '2024'";
                                break;
                        }

                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("SearchText", textBox_search.Text));

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "GAME_MEMBER");

                        dataGridView1.DataSource = ds.Tables["GAME_MEMBER"];

                        int rowCount = dataGridView1.Rows.Count;
                        label_search.Text = "검색된 회원 수 : " + rowCount.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("일치하는 회원 정보가 없습니다." );
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("검색어를 입력하세요.");
            }
        }
    }
}