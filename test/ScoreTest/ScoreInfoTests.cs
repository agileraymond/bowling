using System;
using Xunit;
using Score;
using System.Collections.Generic;

namespace ScoreTest
{
    public class ScoreInfoTests
    {
        [Fact]
        public void AddScore_ThrowsArgumentException_WhenScoreIsNegative()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo();
            Assert.Throws<ArgumentException>(() => frame.AddScore(-1));
        }
        
        [Fact]
        public void AddScore_ThrowsArgumentException_WhenScoreIsGreaterThanTen()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo();
            Assert.Throws<ArgumentException>(() => frame.AddScore(11));
        }

        [Fact]
        public void AddScore_ThrowsArgumentException_WhenAdding3ScoresToFrame1()
        {
            var calculator = new ScoreCalculator();
            var scoreArray = new List<ScoreInfo>();

            var frame = new ScoreInfo(1);
            frame.AddScore(4);
            frame.AddScore(6);
            
            Assert.Throws<ArgumentException>(() => frame.AddScore(1));    
        }

        [Fact]
        public void AddScore_SetsIsStrikeToTrue_WhenFrame1Totals10()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(10);
            Assert.True(frame1.IsStrike);
        }

        [Fact]
        public void AddScore_SetsIsSpareToTrue_WhenFrame1Totals10In2Attempts()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(5);
            frame1.AddScore(5);

            Assert.True(frame1.IsSpare);
        }
        
        [Fact]
        public void AddScore_SetsIsSpareAndIsStrike_WhenFrame1TotalsLessThan10In2Attempts()
        {
            var frame1 = new ScoreInfo(1);
            frame1.AddScore(3);
            frame1.AddScore(4);

            Assert.False(frame1.IsSpare);
            Assert.False(frame1.IsStrike);
        }
    }
}