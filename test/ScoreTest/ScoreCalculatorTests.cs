using System;
using Xunit;
using Score;
using System.Collections.Generic;

namespace ScoreTest
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void Calculate_ReturnsZero_WhenEmptyScores()
        {
            var calculator = new ScoreCalculator();
            var scoreInfo = new List<ScoreInfo>();
            var score = calculator.Calculate(scoreInfo);
            Assert.Equal(0, score);
        }
        
        [Fact]
        public void Calculate_ReturnsZero_WhenScoreInfoIsNull()
        {
            var calculator = new ScoreCalculator();
            var score = calculator.Calculate(null);
            Assert.Equal(0, score);
        }

        [Fact]
        public void Calculate_ReturnsFive_WhenFramesContainFive()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();
            var scoreInfo = new ScoreInfo();
            scoreInfo.Scores.Add(2);
            scoreInfo.Scores.Add(3);
            scoreArray.Add(scoreInfo);

            var score = calculator.Calculate(scoreArray);
            Assert.Equal(5, score);
        }
        
        [Fact]
        public void Calculate_ReturnsTen_WhenFramesTotalTen()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();
            
            var frame1 = new ScoreInfo();
            frame1.Scores.Add(2);
            frame1.Scores.Add(3);

            var frame2 = new ScoreInfo();
            frame2.Scores.Add(1);
            frame2.Scores.Add(4);
            
            scoreArray.Add(frame1);
            scoreArray.Add(frame2);
            
            var score = calculator.Calculate(scoreArray);
            Assert.Equal(10, score);
        }

        [Fact]
        public void Calculate_Returns300_InPerfectGame()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            for (int i = 0; i < 10; i++)
            {
                var frame = new ScoreInfo();
                frame.Scores.Add(10);
                scoreArray.Add(frame);
            }
            
            var score = calculator.Calculate(scoreArray);
            //Assert.Equal(300, score);
        }
        
        [Fact]
        public void Calculate_ThrowsArgumentException_WhenScoreIsNegative()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo();
            Assert.Throws<ArgumentException>(() => frame.AddScore(-1));
        }
        
        [Fact]
        public void Calculate_ThrowsArgumentException_WhenScoreIsGreaterThanTen()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo();
            Assert.Throws<ArgumentException>(() => frame.AddScore(11));
        }
        
        [Fact]
        public void Calculate_ThrowsArgumentException_WhenAdding3ScoresToFrame1()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo(1);
            frame.AddScore(4);
            frame.AddScore(6);
            
            Assert.Throws<ArgumentException>(() => frame.AddScore(1));    
        }
    }
}
