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
                    // add next 2 scores     
                }
                else if (nextFrame.IsSpare)
                {
                    // add next score
                    try
                    {
                        var n = scoreInfo[index + 1];
                        var nScore = n.Scores.FirstOrDefault();
                        Console.WriteLine($"nScore is {nScore}");
                        score += nScore;    
                    }
                    catch (System.Exception)
                    {   
                    }
                }
                
                foreach (var nextScore in nextFrame.Scores)
                {
                    score += nextScore;    
                }
                
                Console.WriteLine($"index {index} - score is {score}");
                index++;        
            }    

            return score;
        }
    }
}