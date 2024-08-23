using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_04
{
    internal class Student
    {
        //public Student() { }

        int id; //기본 접근 제한자가 private //Program.cs에서는 접근할 방법 없음
        private string hakbeon;
        public string getHakbeon()
        {
            return hakbeon;
        }
        public void setHakbeon(string hakbeon)
        {
            this.hakbeon = hakbeon;
        }
        //1.
        private int age;

        //value : Age=10; 이때의 10을 value라고 봄
        public int Age { get { return this.age; } set { this.age = value; } }
        //2.
        private int birthYear;
        public int BirthYear { get => birthYear; set => birthYear = value; }
        //3. 최종 진화
        public string name { get; set; }

    }
}
