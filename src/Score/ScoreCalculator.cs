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

            var index = 0;
            foreach (var nextFrame in scoreInfo)
            {
                if (nextFrame.IsStrike)
                {
                    score += GetNextStrikeScore(index + 1, scoreInfo);
                }
                else if (nextFrame.IsSpare)
                {
                    // add next score
                    score += GetNextScore(index + 1, scoreInfo);
                }
                
                foreach (var nextScore in nextFrame.Scores)
                {
                    score += nextScore;    
                }
                
                index++;        
            }    

            return score;
        }

        private int GetNextScore(int index, List<ScoreInfo> scoreInfo)
        {
            var score = 0;

            try
            {
                score += scoreInfo[index].Scores.First();       
            }
            catch (System.Exception)
            {
            }

            return score;            
        }
        
        private int GetNextStrikeScore(int index, List<ScoreInfo> scoreInfo)
        {
            var score = 0;

            try
            {
                var scoreObj = scoreInfo[index];
                score += scoreObj.Scores.FirstOrDefault();

                if (scoreObj.IsStrike)
                {
                    score += GetNextScore(index + 1, scoreInfo);
                }
                else if (scoreObj.Scores.Count > 1) 
                {
                    score += scoreObj.Scores[1];    
                }       
            }
            catch (System.Exception)
            {
            }

            return score;            
        }
    }
}