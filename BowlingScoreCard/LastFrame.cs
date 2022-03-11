namespace BowlingScoreCard
{
    public class LastFrame : Frame
    {
        public int ThirdRollPinCount { get; private set; }

        public int ThreeRollsPinCount
        {
            get { return FirstRollPinCount + SecondRollPinCount + ThirdRollPinCount; }
        }

        public override bool IsCompleted
        {
            get
            {
                return
                    IsStrike && FrameState == FrameState.ThirdRollCompleted ||
                    IsSpare && FrameState == FrameState.ThirdRollCompleted ||
                    IsOpenFrame;
            }
        }

        public LastFrame(ScoreCard scoreCard, int frameNumber) : base(scoreCard, frameNumber)
        {
        }

        public override void SetPinCount(int pinCount)
        {
            if (FrameState == FrameState.SecondRollCompleted)
            {
                ThirdRollPinCount = pinCount;
                FrameState = FrameState.ThirdRollCompleted;
            }
            else
            {
                base.SetPinCount(pinCount);
            }
        }

        public override int CalculateFrameScore()
        {
            if (IsCompleted)
            {
                if (IsOpenFrame)
                {
                    return TwoRollsPinCount;
                }
                else if (IsSpare || IsStrike)
                {
                    return ThreeRollsPinCount;
                }
            }

            return -1;
        }

        protected override int GetNextTwoShotsTotalForPreviousFrameStrike()
        {
            // Returns the total of the next two shots for a strike on the previous frame.
            if (FrameState > FrameState.FirstRollCompleted)
            {
                return TwoRollsPinCount;
            }

            // Two more shots haven't been completed yet so return -1
            return -1;
        }
    }
}
