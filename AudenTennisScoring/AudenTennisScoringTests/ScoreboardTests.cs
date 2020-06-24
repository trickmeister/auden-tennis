using AudenTennisScoring;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AudenTennisScoringTests
{
    [TestFixture]
    public class ScoreboardTests
    {
        [Test]
        public void Player1Scores_ScoreIsUpdated()
        {
            var player = new Mock<IPlayer>();
            player.Setup(x => x.Scores());
            player.Setup(x => x.Points).Returns(15);

            var scoreBoard = new Scoreboard(player.Object);

            scoreBoard.Player1Scores();
            scoreBoard.Score.Should().Be("15");
        }
    }

    
}
