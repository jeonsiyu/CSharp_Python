using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CsharpProject
{
    public partial class DataBaseSetting : Form
    {
        Main M1;
        public DataBaseSetting(Main form)
        {
            InitializeComponent();
            M1 = form;
            textBox1.Text = UserInfo.DBName;
            textBox2.Text = UserInfo.Tablename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string db = textBox1.Text;
            string table = textBox2.Text;
            bool ok = db != "" && table != "" && !db.Contains(".") && !table.Contains(".");
            if (ok)
            {
                Application.OpenForms["DataBaseSetting"].Close();
                UserInfo.DBName = db;
                UserInfo.Tablename = table;
            }
            else
            {
                MessageBox.Show("잘못된 양식입니다!");
            }

        }

        public void DataBaseInit()
        {
            string DataBaseName = textBox1.Text;
            string TableName = textBox2.Text;

            string[] commands = new string[]{

                "sqlcmd -S localhost -E",
                "create database "+DataBaseName,
                "go",
                $"create table {DataBaseName}.dbo.{TableName}\r\n(\r\n[Index] int,\r\nLot int,\r\nTime nvarchar(50),\r\npH float,\r\n[Current] float,\r\nVoltage float,\r\ndate nvarchar(50),\r\nTemp float\r\n)" ,
                "go"
            };

            try
            {
                Process pro = new Process();
                ProcessStartInfo pri = new ProcessStartInfo();
                pri.FileName = @"cmd.exe";
                pri.CreateNoWindow = false;
                pri.UseShellExecute = false;
            
                pri.RedirectStandardOutput = true;
                pri.RedirectStandardError = true;
                pri.RedirectStandardInput = true;

                pro.StartInfo = pri;
                pro.Start();

                foreach(var items in commands)
                {
                pro.StandardInput.Write(items + Environment.NewLine);
                }
                pro.StandardInput.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseInit();
        }
    }
}
