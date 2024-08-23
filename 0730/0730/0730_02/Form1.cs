using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0730_02
{
    public partial class Form1 : Form, ISubject
    {
        List<IObserver> list = new List<IObserver>();
        public Form1()
        {
            InitializeComponent();
            Form2 frm2 = new Form2(this);
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm2);
            frm2.Show();

            Form3 frm3 = new Form3(this);
            frm3.TopLevel = false;
            frm3.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(frm3);
            frm3.Show();

            Form4 frm4 = new Form4();
            frm4.TopLevel = false;
            frm4.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(frm4);
            frm4.Show();

            //textBox1에 글자가 바뀔 때 마다 notify가 호출됨
            textBox1.TextChanged += (sender, e) =>
            {
                notify((sender as TextBox).Text);
            };
        }

        public void notify(string msg)
        {
            //throw new NotImplementedException();
            foreach (var item in list)
                item.update(msg);
        }

        public void register(IObserver o)
        {
            //throw new NotImplementedException();
            list.Add(o);
        }

        public void unregister(IObserver o)
        {
            //throw new NotImplementedException();
            list.Remove(o);
        }
    }

}
