using System;
using System.Collections.Generic;


namespace BowlingScoreCard
{
    public class ScoreCard
    {
        private int _totalScore;

        public List<Frame> Frames { get; private set; }
        public List<Scores> Scores { get; private set; }

        public ScoreCard()
        {
            Initialize();
        }

        public void Initialize()
        {
            Frames = new List<Frame>(10);
            for (int frameNumber = 1; frameNumber <= 9; frameNumber++)
            {
                Frames.Add(new Frame(this, frameNumber));
            }

            Frames.Add(new LastFrame(this, 10));

            Scores = new List<Scores>(10);
        }

        public Frame GetNextFrame(int frameNumber)
        {
            // frameNumber isn't zero based so when used as an index it gets the next frame.
            return Frames[frameNumber];
        }

        public void CalculateScores()
        {
            Scores.Clear();
            _totalScore = 0;

            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                Frame frame = Frames[frameIndex];
                int frameScore = frame.CalculateFrameScore();
                if (frameScore == -1)
                {
                    break;
                }
                _totalScore += frameScore;
                Scores.Add(new Scores(frameScore, _totalScore));
            }
        }

        private int GetNextTwoShotsTotal(int frameIndex)
        {
            Frame nextFrame = Frames[frameIndex + 1];
            if (nextFrame.IsOpenFrame || nextFrame.IsSpare)
            {
                return nextFrame.TwoRollsPinCount;
            }
            else if (nextFrame.IsStrike)
            {
                Frame nextNextFrame = Frames[frameIndex + 2];
                if (nextNextFrame.FrameState > FrameState.Started)
                {
                    return 10 + nextNextFrame.FirstRollPinCount;
                }
            }

            // Two more shots haven't been completed yet so return -1
            return -1;
        }
    }

    public struct Scores
    {
        public int FrameScore { get; private set; }
        public int TotalScore { get; private set; }

        public Scores(int frameScore, int totalScore)
        {
            FrameScore = frameScore;
            TotalScore = totalScore;
        }
    }
}
