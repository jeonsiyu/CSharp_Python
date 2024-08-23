namespace Project
{
    partial class MNPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNPost));
            this.label_manager = new System.Windows.Forms.Label();
            this.button_post = new System.Windows.Forms.Button();
            this.label_Content = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.richTextBox_Content = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Title = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_manager
            // 
            this.label_manager.AutoSize = true;
            this.label_manager.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_manager.Location = new System.Drawing.Point(259, 37);
            this.label_manager.Name = "label_manager";
            this.label_manager.Size = new System.Drawing.Size(57, 15);
            this.label_manager.TabIndex = 13;
            this.label_manager.Text = "관리자 : ";
            // 
            // button_post
            // 
            this.button_post.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_post.Location = new System.Drawing.Point(478, 308);
            this.button_post.Name = "button_post";
            this.button_post.Size = new System.Drawing.Size(75, 23);
            this.button_post.TabIndex = 12;
            this.button_post.Text = "등록";
            this.button_post.UseVisualStyleBackColor = true;
            this.button_post.Click += new System.EventHandler(this.button_post_Click);
            // 
            // label_Content
            // 
            this.label_Content.AutoSize = true;
            this.label_Content.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Content.Location = new System.Drawing.Point(24, 146);
            this.label_Content.Name = "label_Content";
            this.label_Content.Size = new System.Drawing.Size(32, 15);
            this.label_Content.TabIndex = 11;
            this.label_Content.Text = "내용";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Title.Location = new System.Drawing.Point(24, 37);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(32, 15);
            this.label_Title.TabIndex = 10;
            this.label_Title.Text = "제목";
            // 
            // richTextBox_Content
            // 
            this.richTextBox_Content.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_Content.Location = new System.Drawing.Point(26, 172);
            this.richTextBox_Content.Name = "richTextBox_Content";
            this.richTextBox_Content.Size = new System.Drawing.Size(527, 118);
            this.richTextBox_Content.TabIndex = 9;
            this.richTextBox_Content.Text = "";
            // 
            // richTextBox_Title
            // 
            this.richTextBox_Title.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_Title.Location = new System.Drawing.Point(26, 63);
            this.richTextBox_Title.Name = "richTextBox_Title";
            this.richTextBox_Title.Size = new System.Drawing.Size(377, 66);
            this.richTextBox_Title.TabIndex = 8;
            this.richTextBox_Title.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(429, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // MNPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 369);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_manager);
            this.Controls.Add(this.button_post);
            this.Controls.Add(this.label_Content);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.richTextBox_Content);
            this.Controls.Add(this.richTextBox_Title);
            this.Name = "MNPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNPost";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_manager;
        private System.Windows.Forms.Button button_post;
        private System.Windows.Forms.Label label_Content;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.RichTextBox richTextBox_Content;
        private System.Windows.Forms.RichTextBox richTextBox_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}