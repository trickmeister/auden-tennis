using System.Collections.Generic;
using AudenTennisScoring;
using AudenTennisScoring.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests.Strategies
{
    [TestFixture]
    public class WinStrategyTests
    {
        [TestCaseSource(nameof(CreateAcceptStrategies))]
        public void Strategy_Accepts_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, bool expectedResult )
        {
            var strategy = new WinStrategy();
            for (var i = 0; i < scoreLoop1; i++)
            {
                player1.Scores();
            }

            for (var i = 0; i < scoreLoop2; i++)
            {
                player2.Scores();
            }

            var actualResult = strategy.Accepts(player1, player2);

            actualResult.Should().Be(expectedResult);
        }

        private static IEnumerable<TestCaseData> CreateAcceptStrategies()
        {
            yield return new TestCaseData(new Player(), new Player(), 4, 2, true).SetName("Player 1 Wins");
            yield return new TestCaseData(new Player(), new Player(), 5, 3, true).SetName("Player 1 Wins on Advantage");
            yield return new TestCaseData(new Player(), new Player(), 2, 4, true).SetName("Player 2 Wins");
            yield return new TestCaseData(new Player(), new Player(), 3, 5, true).SetName("Player 2 Wins On Advantage");
            yield return new TestCaseData(new Player(), new Player(), 4, 3, false).SetName("No win");
            yield return new TestCaseData(new Player(), new Player(), 3, 4, false).SetName("No win");
            yield return new TestCaseData(new Player(), new Player(), 3, 3, false).SetName("No win");
            yield return new TestCaseData(new Player(), new Player(), 1, 1, false).SetName("No win");
        }

        [TestCaseSource(nameof(CreateScores))]
        public void Strategy_Score_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, string expectedResult)
        {
            var strategy = new WinStrategy();
            for (var i = 0; i < scoreLoop1; i++)
            {
                player1.Scores();
            }

            for (var i = 0; i < scoreLoop2; i++)
            {
                player2.Scores();
            }

            var actualResult = strategy.GetScore(player1, player2);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
        private static IEnumerable<TestCaseData> CreateScores()
        {
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="DJokovic"}, 4, 2, "Mark wins").SetName("Mark 1 Wins");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="DJokovic"}, 5, 3, "Mark wins").SetName("Player 1 Wins on Advantage");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="DJokovic"}, 2, 4, "DJokovic wins").SetName("Player 2 Wins");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="DJokovic"}, 3, 5, "DJokovic wins").SetName("Player 2 Wins On Advantage");
        }                                                                           
    }
}
