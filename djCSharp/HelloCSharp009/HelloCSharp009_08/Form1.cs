using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp009_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button b = new Button();
            b.Click += B_Click;
            b.Click -= B_Click; //named event remove
            b.Click += delegate (object o, EventArgs e)
            {
                MessageBox.Show("Test1");
            };
            b.Click += (s, e) =>
            {
                MessageBox.Show("Test2");
            };
            EventHandler h = new EventHandler(B_Click);
            b.Click += h;
            Controls.Add(b);
        }

        private void B_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Last Event");
        }
    }
}
