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

            for (int i = 1; i < 10; i++)
            {
                var frame = new ScoreInfo(i);
                frame.AddScore(10);
                scoreArray.Add(frame);
            }

            var lastframe = new ScoreInfo(10);
            lastframe.AddScore(10);
            lastframe.AddScore(10);
            lastframe.AddScore(10);
            scoreArray.Add(lastframe);
            
            var score = calculator.Calculate(scoreArray);
            Assert.Equal(300, score);
        }
        
        [Fact]
        public void Calculate_Returns75()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            for (int i = 1; i < 10; i++)
            {
                var frame = new ScoreInfo(i);
                frame.AddScore(5);
                scoreArray.Add(frame);
            }

            var lastframe = new ScoreInfo(10);
            lastframe.AddScore(10);
            lastframe.AddScore(10);
            lastframe.AddScore(10);
            scoreArray.Add(lastframe);
            
            var score = calculator.Calculate(scoreArray);
            Assert.Equal(75, score);
        }

        [Fact]
        public void Calculate_Returns145()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            for (int i = 1; i < 10; i++)
            {
                var frame = new ScoreInfo(i);
                frame.AddScore(5);
                frame.AddScore(5);
                scoreArray.Add(frame);
            }

            // last frame 
            var lastFrame = new ScoreInfo(10);
            lastFrame.AddScore(5);
            lastFrame.AddScore(5);
            lastFrame.AddScore(5);
            scoreArray.Add(lastFrame);
            
            var totalScore = calculator.Calculate(scoreArray);
            Assert.Equal(150, totalScore);
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
        
        [Fact]
        public void Calculate_CorrectlyWith1StrikeAnd1Spare()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var strike = new ScoreInfo(1);
            strike.AddScore(10);
            scoreArray.Add(strike);
            
            var spare = new ScoreInfo(2);
            spare.AddScore(4);
            spare.AddScore(6);
            scoreArray.Add(spare);
            
            var lastFrame = new ScoreInfo(3);
            lastFrame.AddScore(3);
            lastFrame.AddScore(2);
            scoreArray.Add(lastFrame);

            // 1 = 10 + 4 + 6 = 20
            // 2 = 4 + 6 + 3 = 13
            // 3 = 3 + 2 = 5

            var total = calculator.Calculate(scoreArray);
            Assert.Equal(38, total);
        }

        [Fact]
        public void Calculate_CorrectlyWithSpareAndStrike()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var spare = new ScoreInfo(1);
            spare.AddScore(4);
            spare.AddScore(6);
            scoreArray.Add(spare);
            
            var strike = new ScoreInfo(2);
            strike.AddScore(10);
            scoreArray.Add(strike);
            
            var lastFrame = new ScoreInfo(3);
            lastFrame.AddScore(3);
            lastFrame.AddScore(2);
            scoreArray.Add(lastFrame);

            // 1 = 10 + 10
            // 2 = 10 + 3 + 2
            // 3 = 3 + 2

            var total = calculator.Calculate(scoreArray);
            Assert.True(total == 40);
        }
    }
}
