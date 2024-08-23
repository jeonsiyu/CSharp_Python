using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp006_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Student> students = new List<Student>();
            Student s = new Student();
            s.name = "이동준";
            s.grade = 1;
            students.Add(s);
            Student student = new Student() { name="동준이", grade=2};
            students.Add(student);
            students.Add(new Student() { name = "준동이", grade = 3 });//ctrl d
            students.Add(new Student() { name = "준준이", grade = 4 });
            students.Add(new Student() { name = "동동이", grade = 1 });
            students.Add(new Student() { name = "이이이", grade = 2 });

            for(int i = 0; i<students.Count; i++)
            {
                Label label = new Label();
                label.Text = $"{students[i].grade} 학년 {students[i].name} 학생";
                label.AutoSize = true;
                label.Location = new Point(13, 13 + (23 + 3) * i);
                Controls.Add(label);
            }

            //뭔가를 제거하기 위해선 역 for문을 쓰는 게 좋다.
             for(int i = students.Count-1; i>=0; i--)
             {
                if (students[i].grade > 1)
                    students.RemoveAt(i); //i번째꺼 지우겠다!
             }
            for (int i = 0; i < students.Count; i++)
            {
                Label label = new Label();
                label.Text = $"{students[i].grade} 학년 {students[i].name} 학생";
                label.AutoSize = true;
                label.Location = new Point(130, 13 + (23 + 3) * i);
                Controls.Add(label);
            }

        }
    }
}
