using System;
using System.Collections.Generic;
using System.Linq;

namespace Score
{
    public class ScoreCalculator
    {
        public int Calculate(List<ScoreInfo> scoreInfo)
        {
            var score = 0;
            if (scoreInfo == null || !scoreInfo.Any())
                return score;

            foreach (var nextFrame in scoreInfo)
            {
                foreach (var nextScore in nextFrame.Scores)
                {
                    score += nextScore;    
                }        
            }    

            return score;
        }
    }
}