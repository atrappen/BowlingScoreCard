using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace BowlingScoreCard
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class LastFrameControl : FrameControl
    {
        public LastFrameControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public override void ClearAll()
        {
            base.ClearAll();
            ThirdRollTextBox.Clear();
        }

        protected override void TryAcceptThirdRollPinCount()
        {
            if (Int32.TryParse(ThirdRollTextBox.Text, out int pinCount))
            {
                if (pinCount > 10)
                {
                    pinCount = 10;
                    ThirdRollTextBox.Text = pinCount.ToString();
                }
                Frame.SetPinCount(pinCount);
                CalculateScores();
            }
        }

        protected override void EnableFirstRollTextBox()
        {
            base.EnableFirstRollTextBox();
            ThirdRollTextBox.Enabled = false;
        }

        protected override void EnableSecondRollTextBox()
        {
            base.EnableSecondRollTextBox();
            ThirdRollTextBox.Enabled = false;
        }

        protected override void EnableThirdRollTextBox()
        {
            base.EnableThirdRollTextBox();
            ThirdRollTextBox.Enabled = true;
        }

        protected override void DisableAll()
        {
            base.DisableAll();
            ThirdRollTextBox.Enabled = false;
        }
    }
}
