using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }

        public Student() { Console.WriteLine("ㅋㅋㅋ"); }

        private int id;
        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id=id;
        }

        private string hakbeon;
        public string Hakbeon { get { return hakbeon; } 
            set {  hakbeon = value; } }
        public string myHakbeon { get => hakbeon; set => hakbeon = value; }

        public void study()
        {
            if(age>20)
                Console.WriteLine("걸음마");
            else
                Console.WriteLine("인생살기");
        }




    }
}
