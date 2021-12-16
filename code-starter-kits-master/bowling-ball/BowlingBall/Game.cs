using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
       
        private int frameIndex = 0;
        public void Roll(int pins)
        {
           
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            return Count();
        }
        private int addBonusForSpare(int currentFrameIndex)
        {
            return frames[currentFrameIndex + 1].getRollHits(1);
        }

        private int addBonusForStrike(int currentFrameIndex)
        {
            int bonus = 0;
            Frame nextFrame = frames[currentFrameIndex + 1];
            if (nextFrame.isLastFrame())
            {
                bonus = nextFrame.getRollHits(2);
            }
            else if (nextFrame.isStrike())
            {
                Frame frameAfterNextFrame = frames[currentFrameIndex + 2];
                bonus = frameAfterNextFrame.getRollHits(1);
                bonus += nextFrame.getScore();
            }
            else
            {
                bonus = nextFrame.getScore();
            }
            return bonus;
        }



        public List<Frame> frames { get; set; }

        int CurrentFrameIndex;
        public Game()
        {
            frames = new List<Frame>();
            CurrentFrameIndex = 1;
        }

        public void Add(Frame frame)
        {
            frame.CurrentIndex = CurrentFrameIndex++;
            frames.Add(frame);
        }
        public int Count()
        {
            return frames.Count;
        }
        public Frame GetFrameByIndex(int index)
        {
            return frames.SingleOrDefault(x => x.CurrentIndex == index);
        }

        public int ComputeCurrentScore(Frame frame)
        {
            if (!frame.IsSpare && !frame.IsStrike)
            {
                return GetPreviousScore(frame) + frame.FirstThrow + frame.SecondThrow;
            }
            else if (frame.IsSpare)
            {
                return GetPreviousScore(frame) + 10 + GetNextFirstThrow(frame);
            }
            else if (frame.IsStrike)
            {
                return GetPreviousScore(frame) + 10 + GetNextTwoThrows(frame);
            }
            else
            {
                return 0;
            }
        }
        private int GetNextFirstThrow(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex + 1));

            return frm == null ? 0 : frm.FirstThrow;
        }
        private int GetNextTwoThrows(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex + 1));

            return frm == null ? 0 : frm.FirstThrow + frm.SecondThrow;
        }
        public int GetPreviousScore(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex - 1));

            if (frm == null) return 0;

            return frm.FrameScored;
        }
    }
}
}
