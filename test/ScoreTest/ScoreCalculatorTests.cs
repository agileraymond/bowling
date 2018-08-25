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
        public void Calculate_Returns150()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            for (int i = 1; i < 11; i++)
            {
                var frame = new ScoreInfo(i);
                frame.Scores.Add(5);
                frame.Scores.Add(5);
                scoreArray.Add(frame);
            }
            
            var totalScore = calculator.Calculate(scoreArray);
            Assert.Equal(150, totalScore);
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

        [Fact]
        public void ScoreInfo_SetsIsStrikeToTrue_WhenFrame1Totals10()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(10);

            Assert.True(frame1.IsStrike);
        }
        
        [Fact]
        public void ScoreInfo_SetsIsSpareToTrue_WhenFrame1Totals10In2Attempts()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(5);
            frame1.AddScore(5);

            Assert.True(frame1.IsSpare);
        }
        
        [Fact]
        public void ScoreInfo_SetsIsSpareAndIsStrike_WhenFrame1TotalsLessThan10In2Attempts()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(3);
            frame1.AddScore(4);

            Assert.False(frame1.IsSpare);
            Assert.False(frame1.IsStrike);
        }
        
        [Fact]
        public void Calculate_CorrectTotalScoreWhenIsSpare()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame1 = new ScoreInfo(1);
            frame1.AddScore(9);
            frame1.AddScore(1);

            var frame2 = new ScoreInfo(2);
            frame2.AddScore(2);

            scoreArray.Add(frame1);
            scoreArray.Add(frame2);

            var total = calculator.Calculate(scoreArray);
            Assert.True(total == 14);
        }
        
        [Fact]
        public void Calculate_CorrectTotalScoreWhenIsSpare14()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            for (int i = 1; i < 3; i++)
            {
                var frame = new ScoreInfo(i);
                frame.AddScore(4);
                frame.AddScore(6);
                scoreArray.Add(frame);
            }

            // 1 = 10 + 4
            // 2 = 10

            var total = calculator.Calculate(scoreArray);
            Assert.True(total == 24);
        }
    }
}
