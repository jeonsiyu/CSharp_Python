using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp011_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //webBrowser1.Url = "https://dongjoonleedj.github.io/HelloMap/";
            listBox1.SelectedIndexChanged += (s, e) =>
            {
                if ((s as ListBox).SelectedIndex == -1)
                    return;

                Locale m = (s as ListBox).SelectedItem as Locale;
                object[] pos = new object[] { m.lat, m.lng };
                HtmlDocument hdoc = webBrowser1.Document;
                //Invoke : 부르다
                hdoc.InvokeScript("setCenter", pos);

            };
            button1.Click += (s, e) => 
            {
                List<Locale> locales = KakaoAPI.Search(textBox1.Text);
                listBox1.Items.Clear();
                foreach (var item in locales)
                    listBox1.Items.Add(item);
            };
            textBox1.KeyUp += (s, e) => 
            {
                if (e.KeyCode == Keys.Enter)
                    button1.PerformClick();//강제 클릭
            };
        }
    }
}
