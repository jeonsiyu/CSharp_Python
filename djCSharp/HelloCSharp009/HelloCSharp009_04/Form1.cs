using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp009_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for(int i = 0; i<Controls.Count; i++)
            {
                if (Controls[i] is GroupBox)
                {
                    var innerGroup = Controls[i] as GroupBox;

                    for (int j = 0; j < innerGroup.Controls.Count; j++)
                    {
                        MessageBox.Show(innerGroup.Controls[j].Text);
                    }
                }
            }

        }
    }
}
