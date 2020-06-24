using AudenTennisScoring;
using AudenTennisScoring.Strategies;
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
            var player1 = new Mock<IPlayer>();
            var player2 = new Mock<IPlayer>();

            var strategies = new Mock<IScoreConversionStrategies>();

            strategies.Setup(x => x.Accepts(It.IsAny<IPlayer>(), It.IsAny<IPlayer>())).Returns(true);
            strategies.Setup(x => x.GetScore(player1.Object, player2.Object)).Returns("15 15");

            player1.Setup(x => x.Scores());
            player2.Setup(x => x.Scores());

            player1.Setup(x => x.Points).Returns(15);
            player2.Setup(x => x.Points).Returns(15);

            var scoreBoard = new Scoreboard(player1.Object, player2.Object, new []{strategies.Object});

            scoreBoard.Player1Scores();
            scoreBoard.Score.Should().Be("15 15");
        }

        [Test]
        public void Player2Scores_ScoreIsUpdated()
        {
            var player1 = new Mock<IPlayer>();
            var player2 = new Mock<IPlayer>();

            var strategies = new Mock<IScoreConversionStrategies>();

            strategies.Setup(x => x.Accepts(It.IsAny<IPlayer>(), It.IsAny<IPlayer>())).Returns(true);
            strategies.Setup(x => x.GetScore(player1.Object, player2.Object)).Returns("0 15");

            player2.Setup(x => x.Scores());

            player1.Setup(x => x.Points).Returns(0);
            player2.Setup(x => x.Points).Returns(15);

            var scoreBoard = new Scoreboard(player1.Object, player2.Object, new[] { strategies.Object });

            scoreBoard.Player2Scores();
            scoreBoard.Score.Should().Be("0 15");
        }
    }
}
