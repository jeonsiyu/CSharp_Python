namespace Project
{
    partial class ScheduleCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleCheckForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_Note = new System.Windows.Forms.TextBox();
            this.label_Note = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Time1 = new System.Windows.Forms.ComboBox();
            this.label_Color = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Time2 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_number = new System.Windows.Forms.Label();
            this.Color_button = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("경기천년제목 Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(389, 275);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "추가 하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("경기천년제목 Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(505, 275);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "닫기 ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_Note
            // 
            this.textBox_Note.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Note.Location = new System.Drawing.Point(39, 238);
            this.textBox_Note.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(571, 26);
            this.textBox_Note.TabIndex = 3;
            // 
            // label_Note
            // 
            this.label_Note.AutoSize = true;
            this.label_Note.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Note.Location = new System.Drawing.Point(35, 216);
            this.label_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Note.Name = "label_Note";
            this.label_Note.Size = new System.Drawing.Size(41, 19);
            this.label_Note.TabIndex = 4;
            this.label_Note.Text = "설명";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_title.Location = new System.Drawing.Point(35, 49);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(52, 19);
            this.label_title.TabIndex = 5;
            this.label_title.Text = "제목 :";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_date.Location = new System.Drawing.Point(35, 87);
            this.label_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(53, 19);
            this.label_date.TabIndex = 6;
            this.label_date.Text = "날짜 :";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Time.Location = new System.Drawing.Point(35, 130);
            this.label_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(57, 19);
            this.label_Time.TabIndex = 7;
            this.label_Time.Text = "시간 : ";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Title.Location = new System.Drawing.Point(100, 42);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(276, 26);
            this.textBox_Title.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 84);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // comboBox_Time1
            // 
            this.comboBox_Time1.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox_Time1.FormattingEnabled = true;
            this.comboBox_Time1.Location = new System.Drawing.Point(100, 127);
            this.comboBox_Time1.Name = "comboBox_Time1";
            this.comboBox_Time1.Size = new System.Drawing.Size(121, 27);
            this.comboBox_Time1.TabIndex = 10;
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Color.Location = new System.Drawing.Point(35, 176);
            this.label_Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(56, 19);
            this.label_Color.TabIndex = 11;
            this.label_Color.Text = "컬러 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(228, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "~";
            // 
            // comboBox_Time2
            // 
            this.comboBox_Time2.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox_Time2.FormattingEnabled = true;
            this.comboBox_Time2.Location = new System.Drawing.Point(255, 127);
            this.comboBox_Time2.Name = "comboBox_Time2";
            this.comboBox_Time2.Size = new System.Drawing.Size(121, 27);
            this.comboBox_Time2.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(418, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label_number
            // 
            this.label_number.AutoSize = true;
            this.label_number.Location = new System.Drawing.Point(39, 13);
            this.label_number.Name = "label_number";
            this.label_number.Size = new System.Drawing.Size(14, 13);
            this.label_number.TabIndex = 19;
            this.label_number.Text = "-";
            this.label_number.Visible = false;
            // 
            // Color_button
            // 
            this.Color_button.Location = new System.Drawing.Point(99, 172);
            this.Color_button.Name = "Color_button";
            this.Color_button.Size = new System.Drawing.Size(122, 23);
            this.Color_button.TabIndex = 20;
            this.Color_button.Text = "색상 추가하기";
            this.Color_button.UseVisualStyleBackColor = true;
            this.Color_button.Click += new System.EventHandler(this.Color_button_Click);
            // 
            // ScheduleCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 329);
            this.Controls.Add(this.Color_button);
            this.Controls.Add(this.label_number);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox_Time2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Color);
            this.Controls.Add(this.comboBox_Time1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_Note);
            this.Controls.Add(this.textBox_Note);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ScheduleCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleCheckForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_Note;
        private System.Windows.Forms.Label label_Note;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox_Time1;
        private System.Windows.Forms.Label label_Color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Time2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_number;
        private System.Windows.Forms.Button Color_button;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}