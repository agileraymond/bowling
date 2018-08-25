using System;
using System.Collections.Generic;

namespace Score
{
    public class ScoreInfo 
    {
        public bool IsStrike { get; private set; }
        public bool IsSpare { get; private set; }
        public List<int> Scores { get; private set; }
        public int Frame { get; private set; }

        public ScoreInfo()
        {
            Scores = new List<int>();
        }
        
        public ScoreInfo(int frame)
        {
            Scores = new List<int>();
            Frame = frame;
        }

        public void AddScore(int score)
        {   
            var sum = GetScoreTotal();
                
            if (Frame != 10) 
            {
                if (Scores.Count == 2)
                    throw new ArgumentException("frame 10 is the only frame that can contain 3 scores");

                if (sum + score > 10)
                    throw new ArgumentException("Total scores in a given frame can't exceed 10");
            }
            else if (Frame == 10) 
            {
                if (sum + score > 30)
                    throw new ArgumentException("In frame 10, total score can't exceed 30");
                if (Scores.Count == 3)
                    throw new ArgumentException("frame 10 can only contain 3 scores");
            }

            if (score >= 0 && score <= 10)
                Scores.Add(score);
            else
                throw new ArgumentException("score must be between 0 and 10");

            // get sum again
            sum = GetScoreTotal();
            if (Frame != 10 && sum == 10)
            {
                if (Scores.Count == 1)
                    IsStrike = true;
                else IsSpare = true; 
            }        
        }

        private int GetScoreTotal()
        {
            var sum = 0;
            foreach (var s in Scores)
            {
                sum += s;    
            }
            return sum;
        }
    }
}