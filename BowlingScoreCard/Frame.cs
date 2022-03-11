namespace BowlingScoreCard
{
    public enum FrameState
    {
        NotStarted,
        Started,
        FirstRollCompleted,
        SecondRollCompleted,
        ThirdRollCompleted
    }

    public class Frame
    {
        
        #region Properties

        public FrameState FrameState { get; protected set; }
        public ScoreCard ScoreCard { get; private set; }
        public int FrameNumber { get; private set; }

        public int FirstRollPinCount { get; private set; }
        public int SecondRollPinCount { get; private set; }

        public int TwoRollsPinCount
        {
            get { return FirstRollPinCount + SecondRollPinCount; }
        }

        public bool IsNotStarted
        {
            get { return FrameState == FrameState.NotStarted; }
        }

        public bool IsStrike
        {
            get { return FrameState > FrameState.Started && FirstRollPinCount == 10; }
        }

        public bool IsSpare
        {
            get { return FrameState > FrameState.FirstRollCompleted && TwoRollsPinCount == 10; }
        }

        public bool IsOpenFrame
        {
            get { return FrameState == FrameState.SecondRollCompleted && TwoRollsPinCount < 10; }
        }

        public virtual bool IsCompleted
        {
            get { return IsStrike || IsSpare || IsOpenFrame; }
        }

        #endregion

        public Frame(ScoreCard scoreCard, int frameNumber)
        {
            ScoreCard = scoreCard;
            FrameNumber = frameNumber;
        }

        public void Start()
        {
            FrameState = FrameState.Started;
        }

        public void Reset()
        {
            FrameState = FrameState.NotStarted;
        }

        public virtual void SetPinCount(int pinCount)
        {
            if (FrameState == FrameState.Started)
            {
                FirstRollPinCount = pinCount;
                FrameState = FrameState.FirstRollCompleted;
            }
            else if (FrameState == FrameState.FirstRollCompleted)
            {
                SecondRollPinCount = pinCount;
                FrameState = FrameState.SecondRollCompleted;
            }
        }

        public virtual int CalculateFrameScore()
        {
            if (IsCompleted)
            {
                if (IsOpenFrame)
                {
                    return TwoRollsPinCount;
                }
                else if (IsSpare)
                {
                    Frame nextFrame = ScoreCard.GetNextFrame(FrameNumber);
                    if (nextFrame.FrameState > FrameState.Started)
                    {
                        return TwoRollsPinCount + nextFrame.FirstRollPinCount;
                    }
                }
                else if (IsStrike)
                {
                    return GetScoreForStrike();
                }
            }

            return -1;
        }

        private int GetScoreForStrike()
        {
            Frame nextFrame = ScoreCard.GetNextFrame(FrameNumber);
            int nextTwoShotsTotal = nextFrame.GetNextTwoShotsTotalForPreviousFrameStrike();
            if (nextTwoShotsTotal > -1)
            {
                return 10 + nextTwoShotsTotal;
            }

            return -1;
        }

        protected virtual int GetNextTwoShotsTotalForPreviousFrameStrike()
        {
            // Returns the total of the next two shots for a strike on the previous frame.
            if (IsOpenFrame || IsSpare)
            {
                return TwoRollsPinCount;
            }
            else if (IsStrike)
            {
                // Get the frame two after the one with the original strike
                Frame nextNextFrame = ScoreCard.GetNextFrame(FrameNumber);
                if (nextNextFrame.FrameState > FrameState.Started)
                {
                    return 10 + nextNextFrame.FirstRollPinCount;
                }
            }

            // Two more shots haven't been completed yet so return -1
            return -1;
        }
    }
}
