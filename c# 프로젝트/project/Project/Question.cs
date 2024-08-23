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
    public partial class Question : Form
    {
        public Question()
        {
            InitializeComponent();
            comboBox.Items.Add("제목");
            comboBox.Items.Add("작성자");
            comboBox.SelectedIndex = 0;

            this.Load += new EventHandler(Question_Load);
            button_search.Click += new EventHandler(button_search_Click);
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            LoadData();
        }

        public void Question_Load(object sender, EventArgs e)
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
                    string sql = "SELECT fID AS \"글번호\", fTitle AS \"제목\", userID AS \"작성자\", " +
                                "fDate AS \"작성일\", status AS \"상태\", fContent, answer " +
                                "FROM FAQ_BOARD_POST ORDER BY fDate asc";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "FAQ_BOARD_POST");

                    dataGridView1.DataSource = ds.Tables["FAQ_BOARD_POST"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Columns["fContent"].Visible = false;
                    dataGridView1.Columns["answer"].Visible = false;

                    int rowCount = dataGridView1.Rows.Count;
                    label_question.Text = "전체 질문 수 : " + rowCount.ToString();

                    int answer1Count = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Count(row => row.Cells["상태"].Value.ToString() == "답변완료");
                    label1.Text = "답변 완료 수 : " + answer1Count.ToString();

                    int answer2Count = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Count(row => row.Cells["상태"].Value.ToString() == "");
                    label2.Text = "남은 답변 수 : " + answer2Count.ToString();
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
                            case "제목":
                                sql = "SELECT fID AS \"글번호\", fTitle AS \"제목\", userID AS \"작성자\", " +
                                        "fDate AS \"작성일\", status AS \"상태\", fContent, answer " +
                                        "FROM FAQ_BOARD_POST WHERE fTitle LIKE '%' || :SearchText || '%' ORDER BY fDate asc";
                                break;
                            case "작성자":
                                sql = "SELECT fID AS \"글번호\", fTitle AS \"제목\", userID AS \"작성자\", " +
                                        "fDate AS \"작성일\", status AS \"상태\", fContent, answer " +
                                        "FROM FAQ_BOARD_POST WHERE userID = :SearchText ORDER BY fDate asc";
                                break;
                        }
                        dataGridView1.Columns["fContent"].Visible = false;
                        dataGridView1.Columns["answer"].Visible = false;

                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("SearchText", textBox_search.Text));

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "FAQ_BOARD_POST");

                        dataGridView1.DataSource = ds.Tables["FAQ_BOARD_POST"];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("다시 입력해주세요.");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                LoadData();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // 헤더 클릭 방지
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string fTitle = row.Cells["제목"].Value.ToString();
                string userID = row.Cells["작성자"].Value.ToString();
                string fContent = row.Cells["fContent"].Value.ToString();
                string fDate = row.Cells["작성일"].Value.ToString();
                string answer = row.Cells["answer"].Value.ToString();

                // 모달 창 생성 및 데이터 전달
                QContent c = new QContent(fTitle, userID, fContent, fDate, answer);
                c.FormClosed += new FormClosedEventHandler(QContent_FormClosed);
                c.ShowDialog();
            }
        }
        private void QContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData(); // 폼이 닫힐 때 데이터를 다시 로드하여 업데이트
        }
    }
}