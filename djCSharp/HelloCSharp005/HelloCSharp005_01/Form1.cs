﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp005_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button b = new Button();
            b.Text = "Hi";
            //Controls = Form 안에 있는 모든 컴포넌트들
            Controls.Add(b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Text는 Label 클래스의 구성요소(=속성, 컴포넌트, 프로퍼티...)
            //주로 Label, TextBox, Button과 같이 Form안에 있는 것들은 컴포넌트 혹은 컨트롤이라고 부름
            //즉 Student의 name과 같은 그런 존재
            label1.Text = "안녕하세요";
        }
    }
}
