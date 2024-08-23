namespace Project
{
    partial class Managers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Managers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.richTextBox_chat = new System.Windows.Forms.RichTextBox();
            this.richTextBox_chatting = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_send);
            this.panel1.Controls.Add(this.richTextBox_chat);
            this.panel1.Controls.Add(this.richTextBox_chatting);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 458);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("경기천년제목 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(98, 24);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "채팅";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(477, 367);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(47, 78);
            this.button_send.TabIndex = 14;
            this.button_send.Text = "전송";
            this.button_send.UseVisualStyleBackColor = true;
            // 
            // richTextBox_chat
            // 
            this.richTextBox_chat.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_chat.Location = new System.Drawing.Point(23, 367);
            this.richTextBox_chat.Name = "richTextBox_chat";
            this.richTextBox_chat.Size = new System.Drawing.Size(442, 80);
            this.richTextBox_chat.TabIndex = 13;
            this.richTextBox_chat.Text = "";
            // 
            // richTextBox_chatting
            // 
            this.richTextBox_chatting.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox_chatting.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_chatting.Location = new System.Drawing.Point(23, 59);
            this.richTextBox_chatting.Name = "richTextBox_chatting";
            this.richTextBox_chatting.Size = new System.Drawing.Size(501, 284);
            this.richTextBox_chatting.TabIndex = 12;
            this.richTextBox_chatting.Text = "";
            // 
            // Managers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 458);
            this.Controls.Add(this.panel1);
            this.Name = "Managers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managers";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.RichTextBox richTextBox_chat;
        private System.Windows.Forms.RichTextBox richTextBox_chatting;
    }
}