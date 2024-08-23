using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0719_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Student> students = new List<Student>();
            students.Add(new Student() { name = "이동준", grade = 1 });
            students.Add(new Student() { name = "동준이", grade = 2 });
            students.Add(new Student() { name = "준동이", grade = 3 });
            students.Add(new Student() { name = "준준이", grade = 4 });
            students.Add(new Student() { name = "동동이", grade = 1 });
            students.Add(new Student() { name = "이이이", grade = 2 });

            for (int i = 0; i < students.Count; i++)
            {
                Label label = new Label();
                label.Text = $"{students[i].grade}학년 {students[i].name} 학생";
                label.AutoSize = true; // 크기를 자동으로 설정해줌
                label.Location = new Point(13, 13 + (23 + 3) * i);
                Controls.Add(label);
            }
            // 먼가를 제거하기 위해서 역 for문을 쓰는게 좋다.
            for (int i = students.Count - 1; i >= 0; i--)
            {
                if (students[i].grade > 1) 
                {
                    students.RemoveAt(i); // i번째꺼 지우겠다!
                }
            }
           
            for (int i = 0; i < students.Count; i++)
            {
                Label label = new Label();
                label.Text = $"{students[i].grade}학년 {students[i].name} 학생";
                label.AutoSize = true;
                label.Location = new Point(130, 13 + (23 + 3) * i);
                Controls.Add(label);
            }
        }
    }
}
