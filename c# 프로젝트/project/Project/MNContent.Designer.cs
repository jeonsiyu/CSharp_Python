namespace Project
{
    partial class MNContent
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
            this.button_delect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Content = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_ManagerID = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_delect
            // 
            this.button_delect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_delect.FlatAppearance.BorderSize = 0;
            this.button_delect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delect.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_delect.Location = new System.Drawing.Point(606, 294);
            this.button_delect.Name = "button_delect";
            this.button_delect.Size = new System.Drawing.Size(52, 23);
            this.button_delect.TabIndex = 61;
            this.button_delect.Text = "삭제";
            this.button_delect.UseVisualStyleBackColor = false;
            this.button_delect.Click += new System.EventHandler(this.button_delect_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(18, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(640, 2);
            this.label2.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(18, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 2);
            this.label1.TabIndex = 59;
            // 
            // label_Content
            // 
            this.label_Content.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Content.Location = new System.Drawing.Point(27, 95);
            this.label_Content.Name = "label_Content";
            this.label_Content.Size = new System.Drawing.Size(610, 174);
            this.label_Content.TabIndex = 58;
            this.label_Content.Text = "내용";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Date.Location = new System.Drawing.Point(505, 42);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(43, 15);
            this.label_Date.TabIndex = 57;
            this.label_Date.Text = "등록일";
            // 
            // label_ManagerID
            // 
            this.label_ManagerID.AutoSize = true;
            this.label_ManagerID.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ManagerID.Location = new System.Drawing.Point(505, 18);
            this.label_ManagerID.Name = "label_ManagerID";
            this.label_ManagerID.Size = new System.Drawing.Size(45, 15);
            this.label_ManagerID.TabIndex = 56;
            this.label_ManagerID.Text = "관리자";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("경기천년제목 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Title.Location = new System.Drawing.Point(27, 41);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(35, 16);
            this.label_Title.TabIndex = 55;
            this.label_Title.Text = "제목";
            // 
            // MNContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(686, 329);
            this.Controls.Add(this.button_delect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Content);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.label_ManagerID);
            this.Controls.Add(this.label_Title);
            this.Name = "MNContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNContent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_delect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Content;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_ManagerID;
        private System.Windows.Forms.Label label_Title;
    }
}