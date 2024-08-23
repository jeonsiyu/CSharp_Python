using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ActivationContext;

namespace Project
{
    public partial class Notice : Form
    {
        private string selectFilter;

        public Notice()
        {
            InitializeComponent();
            comboBox.Items.Add("공략");
            comboBox.Items.Add("모드");
            comboBox.Items.Add("게임추천");
            comboBox.Items.Add("FAQ");
            comboBox.SelectedIndex = 0;

            button_search.Click -= new EventHandler(button_search_Click);
            button_search.Click += new EventHandler(button_search_Click);
            button_post.Click -= new EventHandler(button_post_Click);
            button_post.Click += new EventHandler(button_post_Click);
            dataGridView1.CellDoubleClick -= new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            button_delete.Click -= new EventHandler(button_delete_Click);
            button_delete.Click += new EventHandler(button_delete_Click);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            selectFilter = comboBox.SelectedItem.ToString();
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    string sql = "";
                    string sqlNotice = "";
                    string tableName = "";

                    switch (selectFilter)
                    {
                        case "공략":
                            label_board.Text = $"공략 게시판";
                            tableName = "WT_BOARD_POST";
                            sql = $"SELECT TO_CHAR(wtID) AS \"글번호\", wtTitle \"제목\", userID \"작성자\", wtDate \"작성일\", TO_CHAR(wtViews) \"조회수\" FROM {tableName} ORDER BY wtID desc";
                            sqlNotice = "SELECT '공지' AS \"글번호\", noticeTitle AS \"제목\", Manager_ID AS \"작성자\", noticeDate AS \"작성일\", '-' AS \"조회수\" FROM NOTICE WHERE boardType = 'WT_BOARD_POST' ORDER BY noticeDate desc";
                            break;
                        case "모드":
                            label_board.Text = $"모드 게시판";
                            tableName = "MOD_BOARD";
                            sql = $"SELECT TO_CHAR(mID) AS \"글번호\", mTitle \"제목\", userID \"작성자\", mDate \"작성일\", TO_CHAR(mViews) \"조회수\" FROM {tableName} ORDER BY mID desc";
                            sqlNotice = "SELECT '공지' AS \"글번호\", noticeTitle AS \"제목\", Manager_ID AS \"작성자\", noticeDate AS \"작성일\", '-' AS \"조회수\" FROM NOTICE WHERE boardType = 'MOD_BOARD' ORDER BY noticeDate desc";
                            break;
                        case "게임추천":
                            label_board.Text = $"게임 추천 게시판";
                            tableName = "SG_BOARD_POST";
                            sql = $"SELECT TO_CHAR(sgID) AS \"글번호\", sgTitle \"제목\", userID \"작성자\", sgDate \"작성일\", TO_CHAR(sgViews) \"조회수\" FROM {tableName} ORDER BY sgID desc";
                            sqlNotice = "SELECT '공지' AS \"글번호\", noticeTitle AS \"제목\", Manager_ID AS \"작성자\", noticeDate AS \"작성일\", '-' AS \"조회수\" FROM NOTICE WHERE boardType = 'SG_BOARD_POST' ORDER BY noticeDate desc";
                            break;
                        case "FAQ":
                            label_board.Text = $"FAQ 게시판";
                            tableName = "FAQ_BOARD_POST";
                            sql = $"SELECT TO_CHAR(fID) AS \"글번호\", fTitle \"제목\", userID \"작성자\", fDate \"작성일\", TO_CHAR(fViews) \"조회수\" FROM {tableName} ORDER BY fID desc";
                            sqlNotice = "SELECT '공지' AS \"글번호\", noticeTitle AS \"제목\", Manager_ID AS \"작성자\", noticeDate AS \"작성일\", '-' AS \"조회수\" FROM NOTICE WHERE boardType = 'FAQ_BOARD_POST' ORDER BY noticeDate desc";
                            break;
                    }

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleCommand cmdNotice = new OracleCommand(sqlNotice, conn);
                    OracleDataAdapter c = new OracleDataAdapter(cmd);
                    OracleDataAdapter cn = new OracleDataAdapter(cmdNotice);
                    DataSet ds = new DataSet();
                    c.Fill(ds, "Type");
                    cn.Fill(ds, "Notice");

                    DataTable mixtable = ds.Tables["Type"].Clone();
                    mixtable.Merge(ds.Tables["Notice"]);
                    mixtable.Merge(ds.Tables["Type"]);

                    dataGridView1.Columns.Clear();
                    // 체크박스 열 추가
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.Name = "checkBoxColumn";
                    checkBoxColumn.TrueValue = true;
                    checkBoxColumn.FalseValue = false;
                    checkBoxColumn.Width = 50;
                    dataGridView1.Columns.Add(checkBoxColumn);
                    dataGridView1.DataSource = mixtable;
                    // 헤더에 체크박스 추가
                    HeaderCheckBox();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["글번호"].Value.ToString() == "공지")  // 글번호가 '공지'일때 글자 색상 변경
                        {
                            row.Cells["글번호"].Style.ForeColor = Color.Red;
                        }
                    }
                    foreach (Control control in dataGridView1.Controls)
                    {
                        if (control is CheckBox headerCheckBox)
                        {
                            headerCheckBox.Checked = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("게시판 데이터가 없습니다.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void NContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData(); // 폼이 닫힐 때 데이터를 다시 로드하여 업데이트
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // 헤더 클릭 방지
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string ID = row.Cells["글번호"].Value.ToString();
                string Title = row.Cells["제목"].Value.ToString();
                string userID = row.Cells["작성자"].Value.ToString();
                string Date = row.Cells["작성일"].Value.ToString();
                string Views = row.Cells["조회수"].Value.ToString();
                string content = Content(selectFilter, Title);

                // 모달 창 생성 및 데이터 전달
                NContent c = new NContent(ID, Title, userID, Date, Views, selectFilter, content);
                c.FormClosed += new FormClosedEventHandler(NContent_FormClosed);
                c.ShowDialog(); // 모달 창 열기
            }
        }

    private string Content(string filter, string title)
        { 
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";
            string content = "";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "";
                    string sqlNotice = "";

                    switch (filter)
                    {
                        case "공략":
                            sql = "SELECT wtContent FROM WT_BOARD_POST WHERE wtTitle = :title";
                            sqlNotice = "SELECT noticeContent FROM NOTICE WHERE noticeTitle = :title AND boardType = 'WT_BOARD_POST'";
                            break;
                        case "모드":
                            sql = "SELECT mContent FROM MOD_BOARD WHERE mTitle = :title";
                            sqlNotice = "SELECT noticeContent FROM NOTICE WHERE noticeTitle = :title AND boardType = 'MOD_BOARD'";
                            break;
                        case "게임추천":
                            sql = "SELECT sgContent FROM SG_BOARD_POST WHERE sgTitle = :title";
                            sqlNotice = "SELECT noticeContent FROM NOTICE WHERE noticeTitle = :title AND boardType = 'SG_BOARD_POST'";
                            break;
                        case "FAQ":
                            sql = "SELECT fContent FROM FAQ_BOARD_POST WHERE fTitle = :title";
                            sqlNotice = "SELECT noticeContent FROM NOTICE WHERE noticeTitle = :title AND boardType = 'FAQ_BOARD_POST'";
                            break;
                    }

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("title", title));
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        content = reader.GetString(0);

                    }
                    reader.Close();

                    if (string.IsNullOrEmpty(content))
                    {
                        OracleCommand cmdNotice = new OracleCommand(sqlNotice, conn);
                        cmdNotice.Parameters.Add(new OracleParameter("title", title));
                        OracleDataReader readerNotice = cmdNotice.ExecuteReader();

                        if (readerNotice.Read())
                        {
                            content = readerNotice.GetString(0);
                        }
                        readerNotice.Close();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("데이터를 가져오는 중 오류가 발생했습니다.");
                }
                finally
                {
                    conn.Close();
                }
            }
            return content;
        }

        private void button_post_Click(object sender, EventArgs e)
        {
            selectFilter = comboBox.SelectedItem.ToString();
            NPost n = new NPost(selectFilter);
            n.FormClosed += new FormClosedEventHandler(NPost_FormClosed);
            n.ShowDialog();
        }

        private void NPost_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=test;Password=1234;Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                            {
                                string id = row.Cells["글번호"].Value.ToString();
                                string sql = "";

                                if (id == "공지") // 공지사항 삭제
                                {
                                    string boardType = "";
                                    switch (selectFilter)
                                    {
                                        case "공략": 
                                            boardType = "WT_BOARD_POST"; break;
                                        case "모드":
                                            boardType = "MOD_BOARD"; break;
                                        case "게임추천": 
                                            boardType = "SG_BOARD_POST"; break;
                                        case "FAQ": 
                                            boardType = "FAQ_BOARD_POST"; break;
                                    }

                                    sql = $"DELETE FROM NOTICE WHERE noticeTitle = :noticeTitle AND boardType = :boardType";
                                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                                    {
                                        cmd.Parameters.Add(new OracleParameter("noticeTitle", row.Cells["제목"].Value.ToString()));
                                        cmd.Parameters.Add(new OracleParameter("boardType", boardType));
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else // 일반 게시글 삭제
                                {
                                    string tableName = "", tableID = "";

                                    switch (selectFilter)
                                    {
                                        case "공략": 
                                            tableName = "WT_BOARD_POST"; tableID = "wtID"; break;
                                        case "모드": 
                                            tableName = "MOD_BOARD"; tableID = "mID"; break;
                                        case "게임추천": 
                                            tableName = "SG_BOARD_POST"; tableID = "sgID"; break;
                                        case "FAQ":
                                            tableName = "FAQ_BOARD_POST"; tableID = "fID"; break;
                                    }

                                    sql = $"DELETE FROM {tableName} WHERE {tableID} = :id";
                                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                                    {
                                        cmd.Parameters.Add(new OracleParameter("id", id));
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }

                    LoadData();
                    MessageBox.Show("선택된 항목이 삭제되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류: " + ex.Message);
                }
            }
        }

        private void HeaderCheckBox()
        {
            // 데이터가 로드된 후 컬럼이 존재하는지 확인
            if (dataGridView1.Columns.Count > 0)
            {
                // 체크박스 생성 및 설정
                CheckBox headerCheckBox = new CheckBox
                {
                    Size = new Size(15, 15), // 체크박스 크기 설정
                    BackColor = Color.Transparent, // 배경을 투명으로 설정
                };

                // 첫 번째 컬럼의 헤더 위치에 체크박스 배치
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(0, -1, true);
                headerCheckBox.Location = new Point(rect.Location.X + 18, rect.Location.Y + 4);
                headerCheckBox.CheckedChanged += new EventHandler(HeaderCheckBox_CheckedChanged);

                // DataGridView에 체크박스 추가
                dataGridView1.Controls.Add(headerCheckBox);
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 체크박스 클릭 시 모든 행의 체크박스를 선택 또는 해제
            bool isChecked = ((CheckBox)sender).Checked;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index >= 0) // 헤더가 아닌 모든 행을 대상으로 설정합니다.
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"];
                    checkBoxCell.Value = isChecked;
                }
            }
            dataGridView1.RefreshEdit();
        }
    }
}