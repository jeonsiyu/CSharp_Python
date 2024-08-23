using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpProject
{
    public partial class Main : Form
    {
        SqlConnection conn = new SqlConnection();
        public bool isshown = false;

        public Main()
        {
            InitializeComponent();
            label1.Text = "현재시각 : " + DateTime.Now.ToString();

            button6.Click += delegate
            {              
                if(textBox1.Text != "")
                {
                    textBox2.Text = string.Empty;
                    button8.Enabled = false;
                }
                dateTimePicker1.Enabled = false;
            };

            button7.Click += delegate
            {
                if (textBox2.Text != "")
                {
                    textBox1.Text = string.Empty;
                    button8.Enabled = true;
                }
                dateTimePicker1.Enabled = true;
            };
            panel1.Enabled = false;

            if(UserInfo.Tablename == string.Empty)
                panel2.Enabled = false;
            else
                panel2.Enabled = true;
        }

        private void ConnectDB() 
        {
            //conn.ConnectionString = string.Format("Data Source = ({0});" + "Initial Catalog = {1};" + "Integrated Security = {2};" + "Timeout = 3;", "local", "project", "SSPI");
            conn.ConnectionString = string.Format("Data Source = ({0});" + "Initial Catalog = {1};" + "Integrated Security = {2};" + "Timeout = 3;", "local", UserInfo.DBName, "SSPI");
            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();
        }

        private void dbSelect()
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM " + UserInfo.Tablename;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //da.Fill(ds, "sensor");
                da.Fill(ds, UserInfo.Tablename);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = UserInfo.Tablename;
                isshown = true;
            }
            catch (Exception)
            {
                isshown=false;
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private void dbDelete()
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM " + UserInfo.Tablename;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ////da.Fill(ds, "sensor");
                da.Fill(ds, UserInfo.Tablename);
                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = UserInfo.Tablename;
                isshown = true;
            }
            catch (Exception)
            {
                isshown = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private void dbInsert()
        {
            ConnectDB();
            DataManager dm = new DataManager();
            try
            {
                string sqlcommand = "insert into "+ UserInfo.Tablename +" ([Index],Lot,Time,Temp,date,pH,[Current],Voltage) " +
                    "values (@parameter1,@parameter2,@parameter3,@parameter4,@parameter5,@parameter6,@parameter7,@parameter8);";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int i = 0;
                for(i= 0;i<dataGridView1.RowCount;i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@parameter1", int.Parse(this.dataGridView1[0,i].Value.ToString())); // index
                    cmd.Parameters.AddWithValue("@parameter2", int.Parse(this.dataGridView1[1, i].Value.ToString())); // lot
                    cmd.Parameters.AddWithValue("@parameter3", this.dataGridView1[2,i].Value.ToString()); // time
                    cmd.Parameters.AddWithValue("@parameter4", this.dataGridView1[4,i].Value.ToString()); // Temp
                    cmd.Parameters.AddWithValue("@parameter5", dm.getDateFromFileName(Filedir.dir));         // Date
                    cmd.Parameters.AddWithValue("@parameter6", this.dataGridView1[3, i].Value.ToString()); // pH
                    cmd.Parameters.AddWithValue("@parameter7", this.dataGridView1[5, i].Value.ToString()); // current
                    cmd.Parameters.AddWithValue("@parameter8", this.dataGridView1[6,i].Value.ToString()); // voltage
                    cmd.CommandText = sqlcommand;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Data> datalist = new List<Data>();
            DataManager dm = new DataManager();
            DateTime dt = dateTimePicker1.Value;
            bool isokay = false;
            string dir = "";
            if(textBox1.Text.Trim() == "")
            {
                int[] ymd = new int[3];
                ymd[0] = dt.Year;
                ymd[1] = dt.Month;
                ymd[2] = dt.Day;
                dir = dm.getFileNameByFolder(ymd, textBox2.Text.ToString(), out isokay);
            }
            else if(textBox2.Text.Trim() == "")
            {
                dir = dm.getFileName(textBox1.Text, out isokay);
            }                  
            string howMuch =  numericUpDown1.Value.ToString();
            string fromWhere = numericUpDown2.Value.ToString();

            if(isokay)
            {
                datalist = dm.getData(dir).GetRange(int.Parse(fromWhere), int.Parse(howMuch)).ToList();
                Filedir.dir = dir;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = datalist;
                isshown = true;
            }
            else
            {
                MessageBox.Show("Failed to find the requested data!");
                isshown = false;
            }
            button5.Enabled = true;
            listBox1.Items.Add(DateTime.Now.ToString() + " / 데이터 조회");
            listBox1.Items.Add("결과 : " + (isshown?"성공":"실패") +" / 데이터 "+ dataGridView1.RowCount + "건");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "현재시각 : " + DateTime.Now.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter(this);
            listBox1.Items.Add(DateTime.Now.ToString() + " / 필터링 선택");
            filter.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            List<Data> datalist = new List<Data>();
            DataManager dm = new DataManager();
            DateTime dt = dateTimePicker1.Value;
            bool isokay = false;
            string dir = "";
            if (textBox1.Text.Trim() == "")
            {
                int[] ymd = new int[3];
                ymd[0] = dt.Year;
                ymd[1] = dt.Month;
                ymd[2] = dt.Day;
                dir = dm.getFileNameByFolder(ymd, textBox2.Text.ToString(), out isokay);
                Filedir.dir = dir;
            }
            else if (textBox2.Text.Trim() == "")
            {
                dir = dm.getFileName(textBox1.Text, out isokay);
                Filedir.dir = dir;
            }
            if (isokay)
            {
                datalist = dm.getData(dir).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = datalist;
                isshown = true;
            }
            else
            {
                MessageBox.Show("Failed to find the requested data!");
                isshown = false;
            }
            button5.Enabled = true;
            listBox1.Items.Add(DateTime.Now.ToString() + " / 데이터 전체 조회");
            listBox1.Items.Add("결과 : " + (isshown?"성공":"실패") + " / 데이터 " + dataGridView1.RowCount + "건");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbSelect();
            button5.Enabled = false;
            listBox1.Items.Add("데이터베이스 조회");
            listBox1.Items.Add("결과 : " + (isshown ? "성공" : "실패" + " / 데이터 " + dataGridView1.RowCount + "건"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbInsert();
            listBox1.Items.Add("데이터베이스에 저장");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowFileDialog(out string a, out string b);
            Filedir.dir =textBox1.Text.ToString();
            listBox1.Items.Add("파일 선택");
        }

        public string ShowFileDialog(out string fileName, out string fileFullName)
        {
            fileName = "";
            fileFullName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 선택하기";
            //ofd.FileName = "kemp";
            ofd.Filter = "csv 파일 (*.csv) | *.csv; | 모든 파일(*.*) | *.* ";
            DialogResult dr = ofd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                fileName = ofd.SafeFileName;
                fileFullName = ofd.FileName;
                listBox1.Items.Add(fileFullName);
                textBox1.Text = fileFullName;
                return fileFullName;
            }
            else
            {
                return "";
            }
        }

        public string ShowFolderDialog(out string folderFullName)
        {
            folderFullName = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                folderFullName = fbd.SelectedPath;
                listBox1.Items.Add(folderFullName);
                textBox2.Text = folderFullName;
                return folderFullName;
            }
            else
            {
                return "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowFolderDialog(out string folderFullName);
            DataManager dm = new DataManager();
            int[] ymd = new int[3];
             ymd[0] = dateTimePicker1.Value.Year;
             ymd[1] = dateTimePicker1.Value.Month;
             ymd[2] = dateTimePicker1.Value.Day;
            Filedir.dir = dm.getFileNameByFolder(ymd,folderFullName,out bool isokay);
            listBox1.Items.Add("폴더 선택");
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" || textBox2.Text.Trim() != "")
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() != "" || textBox2.Text.Trim() != "")
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void 로그지우기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseSetting f3 = new DataBaseSetting(this);
            f3.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
/*            rollbackDB();
            listBox1.Items.Add("저장 내용 롤백");*/
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            Chart f4 = new Chart(this);
            f4.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dbDelete();
            dbSelect();
            listBox1.Items.Add("DB 내용 삭제 완료");
        }
    }
}
