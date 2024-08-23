using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();

            TotalMember tm = new TotalMember();
            tm.TopLevel = false;
            panel1.Controls.Add(tm);
            tm.Show();

            NewMember nm = new NewMember();
            nm.TopLevel = false;
            panel2.Controls.Add(nm);
            nm.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
