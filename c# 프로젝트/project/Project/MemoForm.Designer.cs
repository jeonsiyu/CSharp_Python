namespace Project
{
    partial class MemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoForm));
            this.deleteButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel_Schedules = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.plusSave_Button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusSave_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(390, 256);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(59, 47);
            this.deleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deleteButton.TabIndex = 15;
            this.deleteButton.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("경기천년제목V Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(403, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "삭제";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("경기천년제목V Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(342, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "수정";
            // 
            // updateButton
            // 
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.Location = new System.Drawing.Point(331, 256);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(53, 47);
            this.updateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.updateButton.TabIndex = 12;
            this.updateButton.TabStop = false;
            // 
            // flowLayoutPanel_Schedules
            // 
            this.flowLayoutPanel_Schedules.AutoScroll = true;
            this.flowLayoutPanel_Schedules.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_Schedules.Font = new System.Drawing.Font("경기천년제목 Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flowLayoutPanel_Schedules.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_Schedules.Name = "flowLayoutPanel_Schedules";
            this.flowLayoutPanel_Schedules.Size = new System.Drawing.Size(502, 216);
            this.flowLayoutPanel_Schedules.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("경기천년제목V Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(463, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "추가";
            // 
            // plusSave_Button
            // 
            this.plusSave_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plusSave_Button.Image = ((System.Drawing.Image)(resources.GetObject("plusSave_Button.Image")));
            this.plusSave_Button.Location = new System.Drawing.Point(446, 256);
            this.plusSave_Button.Name = "plusSave_Button";
            this.plusSave_Button.Size = new System.Drawing.Size(70, 47);
            this.plusSave_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusSave_Button.TabIndex = 9;
            this.plusSave_Button.TabStop = false;
            // 
            // MemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 317);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.flowLayoutPanel_Schedules);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.plusSave_Button);
            this.Name = "MemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemoForm";
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusSave_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox deleteButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox updateButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Schedules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox plusSave_Button;
    }
}