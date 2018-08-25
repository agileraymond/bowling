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
            if (Frame != 10 && Scores.Count == 2)
                throw new ArgumentException("frame 10 is the only frame that can contain 3 scores");

            if (score >= 0 && score <= 10)
                Scores.Add(score);
            else
                throw new ArgumentException("score must be between 0 and 10");    
        }
    }
}