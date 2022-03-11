using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BowlingScoreCard
{
    public partial class BowlingScoreCardForm : Form
    {
        public List<FrameControl> FrameControls { get; private set; }
        public ScoreCard ScoreCard { get; private set; }

        public FrameControl ActiveFrameControl { get; private set; }

        public BowlingScoreCardForm()
        {
            InitializeComponent();
        }

        public void CalculateScores()
        {
            ScoreCard.CalculateScores();
            for (int frameIndex = 0; frameIndex < ScoreCard.Scores.Count; frameIndex++)
            {
                FrameControls[frameIndex].UpdateScores(ScoreCard.Scores[frameIndex]);
            }
        }

        public void StartFrame(int frameNumber)
        {
            ActiveFrameControl = FrameControls[frameNumber - 1];
            ActiveFrameControl.Start();
        }

        public void HandleGameCompleted()
        {
            EnterButton.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            FrameControls = new List<FrameControl>(10);
            ScoreCard = new ScoreCard();
            InitializeFrameControl(Frame1FrameControl, 1);
            InitializeFrameControl(Frame2FrameControl, 2);
            InitializeFrameControl(Frame3FrameControl, 3);
            InitializeFrameControl(Frame4FrameControl, 4);
            InitializeFrameControl(Frame5FrameControl, 5);
            InitializeFrameControl(Frame6FrameControl, 6);
            InitializeFrameControl(Frame7FrameControl, 7);
            InitializeFrameControl(Frame8FrameControl, 8);
            InitializeFrameControl(Frame9FrameControl, 9);
            InitializeFrameControl(Frame10FrameControl, 10);

            AcceptButton = EnterButton;
            StartFrame(1);
            base.OnLoad(e);
        }

        private void InitializeFrameControl(FrameControl frameControl, int frameNumber)
        {
            FrameControls.Add(frameControl);
            frameControl.InitializeFrame(frameNumber);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            EnterButton.Focus();
            ActiveFrameControl.HandleEnterPressed();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ScoreCard.Initialize();
            foreach (FrameControl frameControl in FrameControls)
            {
                frameControl.ClearAll();
            }
            StartFrame(1);
            EnterButton.Enabled = true;
            ActiveFrameControl.Focus();
        }
    }
}
