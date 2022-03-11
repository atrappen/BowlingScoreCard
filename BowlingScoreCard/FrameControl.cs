using System;
using System.Windows.Forms;


namespace BowlingScoreCard
{
    public partial class FrameControl : UserControl
    {
        public int FrameNumber { get; private set; }

        public BowlingScoreCardForm BowlingScoreCardForm
        {
            get { return ParentForm as BowlingScoreCardForm; }
        }

        public ScoreCard ScoreCard
        {
            get { return BowlingScoreCardForm.ScoreCard; }
        }

        public Frame Frame
        {
            get { return ScoreCard?.Frames[FrameNumber - 1]; }
        }

        public FrameControl()
        {
            InitializeComponent();
        }

        public bool GameIsCompleted
        {
            get { return FrameNumber == 10 && Frame.IsCompleted; }
        }

        public void InitializeFrame(int frameNumber)
        {
            FrameNumber = frameNumber;
            FrameNumberTextBox.Text = "Frame " + frameNumber;
            UpdateState();
        }

        public void Start()
        {
            Frame.Start();
            UpdateState();
        }

        public virtual void ClearAll()
        {
            FirstRollTextBox.Clear();
            SecondRollTextBox.Clear();
            FrameScoreTextBox.Clear();
            TotalScoreTextBox.Clear();
            Frame.Reset();
            UpdateState();
        }

        #region HandleEnterPressed

        public void HandleEnterPressed()
        {
            if (Frame.IsNotStarted || Frame.IsCompleted)
            {
                return;
            }

            if (Frame.FrameState == FrameState.Started)
            {
                TryAcceptFirstRollPinCount();
            }
            else if (Frame.FrameState == FrameState.FirstRollCompleted)
            {
                TryAcceptSecondRollPinCount();
            }
            else
            {
                TryAcceptThirdRollPinCount();
            }

            BowlingScoreCardForm.ActiveFrameControl.Focus();
        }

        private void TryAcceptFirstRollPinCount()
        {
            if (Int32.TryParse(FirstRollTextBox.Text, out int pinCount))
            {
                if (pinCount > 10)
                {
                    pinCount = 10;
                    FirstRollTextBox.Text = pinCount.ToString();
                }
                Frame.SetPinCount(pinCount);
                CalculateScores();
            }
        }

        private void TryAcceptSecondRollPinCount()
        {
            if (Int32.TryParse(SecondRollTextBox.Text, out int pinCount))
            {
                if (FrameNumber < 10)
                {
                    if (Frame.FirstRollPinCount + pinCount > 10)
                    {
                        pinCount = 10 - Frame.FirstRollPinCount;
                        SecondRollTextBox.Text = pinCount.ToString();
                    }
                }
                else if (pinCount > 10)
                {
                    pinCount = 10;
                    SecondRollTextBox.Text = pinCount.ToString();
                }
                Frame.SetPinCount(pinCount);
                CalculateScores();
            }
        }

        protected virtual void TryAcceptThirdRollPinCount()
        {
        }

        #endregion

        public void UpdateScores(Scores scores)
        {
            FrameScoreTextBox.Text = scores.FrameScore.ToString();
            TotalScoreTextBox.Text = scores.TotalScore.ToString();
        }

        #region UpdateState

        public void UpdateState()
        {
            if (Frame.IsCompleted)
            {
                DisableAll();
                return;
            }

            FrameState frameState = Frame.FrameState;
            if (frameState == FrameState.Started)
            {
                EnableFirstRollTextBox();
                return;
            }

            if (frameState == FrameState.FirstRollCompleted)
            {
                EnableSecondRollTextBox();
                return;
            }

            if (frameState == FrameState.SecondRollCompleted)
            {
                EnableThirdRollTextBox();
                return;
            }

            DisableAll();
        }

        protected virtual void EnableFirstRollTextBox()
        {
            FirstRollTextBox.Enabled = true;
            SecondRollTextBox.Enabled = false;
            TabStop = true;
        }

        protected virtual void EnableSecondRollTextBox()
        {
            FirstRollTextBox.Enabled = false;
            SecondRollTextBox.Enabled = true;
            TabStop = true;
        }

        protected virtual void EnableThirdRollTextBox()
        {
            FirstRollTextBox.Enabled = false;
            SecondRollTextBox.Enabled = false;
            TabStop = true;
        }

        protected virtual void DisableAll()
        {
            FirstRollTextBox.Enabled = false;
            SecondRollTextBox.Enabled = false;
            TabStop = false;
        }

        #endregion

        protected void CalculateScores()
        {
            if (GameIsCompleted)
            {
                BowlingScoreCardForm.HandleGameCompleted();
            }
            else if (FrameNumber < 10 && Frame.IsCompleted)
            {
                BowlingScoreCardForm.StartFrame(FrameNumber + 1);
            }

            BowlingScoreCardForm.CalculateScores();
            UpdateState();
        }
    }
}
