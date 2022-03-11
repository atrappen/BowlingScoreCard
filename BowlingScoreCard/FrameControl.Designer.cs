namespace BowlingScoreCard
{
    partial class FrameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirstRollTextBox = new System.Windows.Forms.TextBox();
            this.SecondRollTextBox = new System.Windows.Forms.TextBox();
            this.FrameScoreTextBox = new System.Windows.Forms.TextBox();
            this.TotalScoreTextBox = new System.Windows.Forms.TextBox();
            this.FrameNumberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstRollTextBox
            // 
            this.FirstRollTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstRollTextBox.Location = new System.Drawing.Point(3, 22);
            this.FirstRollTextBox.Name = "FirstRollTextBox";
            this.FirstRollTextBox.Size = new System.Drawing.Size(30, 20);
            this.FirstRollTextBox.TabIndex = 1;
            // 
            // SecondRollTextBox
            // 
            this.SecondRollTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SecondRollTextBox.Location = new System.Drawing.Point(39, 22);
            this.SecondRollTextBox.Name = "SecondRollTextBox";
            this.SecondRollTextBox.Size = new System.Drawing.Size(30, 20);
            this.SecondRollTextBox.TabIndex = 2;
            // 
            // FrameScoreTextBox
            // 
            this.FrameScoreTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.FrameScoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FrameScoreTextBox.Enabled = false;
            this.FrameScoreTextBox.Location = new System.Drawing.Point(3, 48);
            this.FrameScoreTextBox.Name = "FrameScoreTextBox";
            this.FrameScoreTextBox.Size = new System.Drawing.Size(66, 13);
            this.FrameScoreTextBox.TabIndex = 3;
            this.FrameScoreTextBox.TabStop = false;
            // 
            // TotalScoreTextBox
            // 
            this.TotalScoreTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TotalScoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalScoreTextBox.Enabled = false;
            this.TotalScoreTextBox.Location = new System.Drawing.Point(3, 74);
            this.TotalScoreTextBox.Name = "TotalScoreTextBox";
            this.TotalScoreTextBox.Size = new System.Drawing.Size(66, 13);
            this.TotalScoreTextBox.TabIndex = 4;
            this.TotalScoreTextBox.TabStop = false;
            // 
            // FrameNumberTextBox
            // 
            this.FrameNumberTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.FrameNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FrameNumberTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FrameNumberTextBox.Enabled = false;
            this.FrameNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrameNumberTextBox.Location = new System.Drawing.Point(0, 3);
            this.FrameNumberTextBox.Name = "FrameNumberTextBox";
            this.FrameNumberTextBox.Size = new System.Drawing.Size(72, 13);
            this.FrameNumberTextBox.TabIndex = 0;
            this.FrameNumberTextBox.TabStop = false;
            this.FrameNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.FrameNumberTextBox);
            this.Controls.Add(this.TotalScoreTextBox);
            this.Controls.Add(this.FrameScoreTextBox);
            this.Controls.Add(this.SecondRollTextBox);
            this.Controls.Add(this.FirstRollTextBox);
            this.Name = "FrameControl";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(72, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FrameNumberTextBox;
        private System.Windows.Forms.TextBox FirstRollTextBox;
        private System.Windows.Forms.TextBox SecondRollTextBox;
        private System.Windows.Forms.TextBox FrameScoreTextBox;
        private System.Windows.Forms.TextBox TotalScoreTextBox;
    }
}
