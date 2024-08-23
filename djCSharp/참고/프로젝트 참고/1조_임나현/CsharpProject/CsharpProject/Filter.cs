using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpProject
{
    public partial class Filter : Form
    {
        Main M1;
        FilterInit fi = new FilterInit();

        public Filter(Main form)
        {
            InitializeComponent();
            M1 = form;  
            label1.Text = "검색 항목";  
            label2.Text = "값 최소 범위";  
            label3.Text = "값 최대 범위";  
            label4.Text = "시작 인덱스";  
            label5.Text = "인덱스 범위";

            string[] combolist = fi.combolist; 
            comboBox1.Items.AddRange(combolist);
            comboBox1.SelectedIndex = 0;
            numericUpDown3.Value = M1.numericUpDown1.Value;
            numericUpDown4.Value = M1.numericUpDown2.Value;
            textBox1.Text = FilterInit.min;
            textBox2.Text = FilterInit.max;
            button1.Click += delegate
            {
                check(out bool ret);
                if (ret)
                {
                    Application.OpenForms["Filter"].Close();
                    M1.numericUpDown1.Value = numericUpDown3.Value;
                    M1.numericUpDown2.Value = numericUpDown4.Value;
                    List<Data> datalist = new List<Data>();
                    DataManager dg = new DataManager();
                    datalist = dg.getData(Filedir.dir);

                    List<Data> result = Linqsets(comboBox1.SelectedItem.ToString(), datalist);
                    int howMuch = int.Parse(numericUpDown3.Value.ToString());
                    int fromWhere = int.Parse(numericUpDown4.Value.ToString());
                    if (result.Count < howMuch - fromWhere)
                    {
                        howMuch = result.Count;
                    }
                    M1.dataGridView1.DataSource = null;
                    M1.dataGridView1.DataSource = result.GetRange(fromWhere, howMuch).ToList();
                    M1.button5.Enabled = true;
                    M1.listBox1.Items.Add($"결과 : 성공 / 데이터 {M1.dataGridView1.RowCount} 건");
                }
                else
                {
                    MessageBox.Show("잘못된 양식입니다!");
                }
            };
        }

        public List<Data> Linqsets(string combo, List<Data> datalist)
        {
            List<Data> result = new List<Data>();
            if(combo == "Lot")
            {
               var list = from item in datalist
                       where (item.Lot >= int.Parse(textBox1.Text) && item.Lot <= int.Parse(textBox2.Text))
                       select item;
                result = list.ToList();
            }
            else if (combo == "Time")
            {
                DataManager dg = new DataManager();
                var list = from item in datalist
                           where (
                           (dg.timeSplit(item.Time)[2] + dg.timeSplit(item.Time)[1] * 60 + dg.timeSplit(item.Time)[0] * 3600
                           >= 
                           dg.timeSplit(textBox1.Text)[2] + dg.timeSplit(textBox1.Text)[1] * 60 + dg.timeSplit(textBox1.Text)[0] * 3600)

                           &&
                           
                           (dg.timeSplit(item.Time)[2] + dg.timeSplit(item.Time)[1] * 60 + dg.timeSplit(item.Time)[0] * 3600
                           <= 
                           dg.timeSplit(textBox2.Text)[2] + dg.timeSplit(textBox2.Text)[1] * 60 + dg.timeSplit(textBox2.Text)[0] * 3600)
                           )
                           select item;

                result = list.ToList();
            }
            else if (combo == "pH")
            {
                var list = from item in datalist
                           where (item.pH >= double.Parse(textBox1.Text.ToString()) && item.pH <= double.Parse(textBox2.Text.ToString()))
                           select item;
                result = list.ToList();
            }
            else if (combo == "Current")
            {
                var list = from item in datalist
                           where (item.Current >= double.Parse(textBox1.Text.ToString()) && item.Current <= double.Parse(textBox2.Text.ToString()))
                           select item;
                result = list.ToList();
            }
            else if (combo == "Voltage")
            {
                var list = from item in datalist
                           where (item.Voltage >= double.Parse(textBox1.Text.ToString()) && item.Voltage <= double.Parse(textBox2.Text.ToString()))
                           select item;
                result = list.ToList();
            }

            return result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = fi.label6help[comboBox1.SelectedIndex];
            if (comboBox1.SelectedItem.ToString() == "pH" || comboBox1.SelectedItem.ToString() == "Current" || comboBox1.SelectedItem.ToString() == "Voltage")
                maskedTextBox1.Mask = "0.0";
            else if (comboBox1.SelectedItem.ToString() == "Time")
                maskedTextBox1.Mask = "(??) 00:00:00";
            else
                maskedTextBox1.Mask = "90";
        }

        private void button1_Click(object sender, EventArgs e)
        {            

        }

        private void check(out bool ret)
        {
            ret = true;
            bool[] checks = new bool[4];
            if(Char.IsNumber(textBox1.Text.Trim(), 0))
                checks[0] =  textBox1.Text != "" && textBox1.Text != null;
            else
                checks[0] = true;
            if(Char.IsNumber(textBox2.Text.Trim(), 0))
                checks[1] = textBox2.Text != "" && textBox2.Text != null;
            else
                checks[1] = true;

            if(textBox1.Text.Contains(".") && textBox2.Text.Contains("."))
            {
                checks[2] = double.Parse(textBox2.Text.Trim()) >= double.Parse(textBox1.Text.Trim());
            }
            else if (Char.IsNumber(textBox2.Text.Trim(), 0) && Char.IsNumber(textBox1.Text.Trim(), 0))
            {
                checks[2] = int.Parse(textBox2.Text.Trim()) >= int.Parse(textBox1.Text.Trim());
            }
            else
            {
                checks[2] = true;
            }
            if (Char.IsNumber(comboBox1.SelectedIndex.ToString(), 0))
                checks[3] = comboBox1.Text != "";
            else
                checks[3] = true;
            if (checks.Contains(false))
            {
                ret = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //toolTip1.Show("wrong input!",this);
        }
    }
}
