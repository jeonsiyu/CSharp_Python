using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0725_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is GroupBox)
                {
                    var innerGroup = Controls[i] as GroupBox;
                    foreach (var item in innerGroup.Controls)
                    {
                        MessageBox.Show(item.ToString());
                    }
                    for (int j = 0; j < innerGroup.Controls.Count; j++)
                    {
                        {
                            MessageBox.Show(innerGroup.Controls[j].Text);
                        }
                    }
                }
            }
        }
    }
}
