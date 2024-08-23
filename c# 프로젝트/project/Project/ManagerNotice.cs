using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ManagerNotice : Form
    {
        public ManagerNotice()
        {
            InitializeComponent();

            this.Load += new EventHandler(ManagerNotice_Load);
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            button_post.Click -= new EventHandler(button_post_Click);
            button_post.Click += new EventHandler(button_post_Click);
            LoadData();
        }

        public void ManagerNotice_Load(object sender, EventArgs e)
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
                    string sql = "SELECT ManagerNoticeID AS \"글번호\", ManagerNoticeTitle AS \"제목\", " +
                                "ManagerNoticeDate AS \"작성일\", Manager_ID AS \"작성자\", ManagerNoticeContent " +
                                "FROM ManagerNotice ORDER BY ManagerNoticeDate desc";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ManagerNotice");

                    dataGridView1.DataSource = ds.Tables["ManagerNotice"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Columns["ManagerNoticeContent"].Visible = false;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // 헤더 클릭 방지
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string ManagerNoticeTitle = row.Cells["제목"].Value.ToString();
                string Manager_ID = row.Cells["작성자"].Value.ToString();
                string ManagerNoticeContent = row.Cells["ManagerNoticeContent"].Value.ToString();
                string ManagerNoticeDate = row.Cells["작성일"].Value.ToString();

                // 모달 창 생성 및 데이터 전달
                MNContent mn = new MNContent(ManagerNoticeTitle, Manager_ID, ManagerNoticeContent, ManagerNoticeDate);
                mn.FormClosed += new FormClosedEventHandler(MNContent_FormClosed);
                mn.ShowDialog();
            }
        }

        private void MNContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void button_post_Click(object sender, EventArgs e)
        {
            MNPost mnp = new MNPost();
            mnp.FormClosed += new FormClosedEventHandler(MNPost_FormClosed);
            mnp.ShowDialog();
        }

        private void MNPost_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
    }
}