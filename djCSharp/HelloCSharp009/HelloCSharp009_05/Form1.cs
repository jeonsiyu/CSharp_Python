using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp009_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("이동준", "09", "컴공");
            dataGridView1.Rows.Add("이유나", "19", "컴전");
            dataGridView1.Rows.Add("박상신", "99", "전자");
            //dataGridView1.Rows.RemoveAt(1);

            studentBindingSource.Add(new Student() { name = "김규리", hakbeon = "24", major = "컴공" });
            studentBindingSource.Add(new Student() { name = "전시유", hakbeon = "23", major = "관광" });
            studentBindingSource.Add(new Student() { name = "오승민", hakbeon = "24", major = "관광" });
            //studentBindingSource.RemoveAt(1);

            List<Student> students = new List<Student>();
            students.Add(new Student() { name = "서은영", hakbeon = "22", major = "전자" });
            students.Add(new Student() { name = "김정희", hakbeon = "23", major = "전기" });
            students.Add(new Student() { name = "성다현", hakbeon = "22", major = "컴전" });
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = students;

        }
    }
}
