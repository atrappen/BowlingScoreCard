namespace BowlingScoreCard
{
    partial class LastFrameControl
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
            this.ThirdRollTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ThirdRollTextBox
            // 
            this.ThirdRollTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThirdRollTextBox.Location = new System.Drawing.Point(75, 22);
            this.ThirdRollTextBox.Name = "ThirdRollTextBox";
            this.ThirdRollTextBox.Size = new System.Drawing.Size(30, 20);
            this.ThirdRollTextBox.TabIndex = 6;
            // 
            // LastFrameControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ThirdRollTextBox);
            this.Name = "LastFrameControl2";
            this.Size = new System.Drawing.Size(109, 90);
            this.Controls.SetChildIndex(this.ThirdRollTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ThirdRollTextBox;
    }
}
