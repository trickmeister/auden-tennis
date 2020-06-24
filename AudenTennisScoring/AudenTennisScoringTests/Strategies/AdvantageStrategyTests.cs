using System.Collections.Generic;
using AudenTennisScoring;
using AudenTennisScoring.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests.Strategies
{
    [TestFixture]
    public class AdvantageStrategyTests
    {
        [TestCaseSource(nameof(CreateAcceptStrategies))]
        public void Strategy_Accepts_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, bool expectedResult )
        {
            var strategy = new AdvantageStrategy();
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
            yield return new TestCaseData(new Player(), new Player(), 4, 3, true).SetName("Player 1 Advantage");
            yield return new TestCaseData(new Player(), new Player(), 3, 4, true).SetName("Player 2 Advantage");
            yield return new TestCaseData(new Player(), new Player(), 2, 2, false).SetName("No Advantage");
            yield return new TestCaseData(new Player(), new Player(), 4, 2, false).SetName("No Advantage");
            yield return new TestCaseData(new Player(), new Player(), 2, 4, false).SetName("No Advantage");
        }

        [TestCaseSource(nameof(CreateScores))]
        public void Strategy_Score_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, string expectedResult)
        {
            var strategy = new AdvantageStrategy();
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
            yield return new TestCaseData(new Player{Name = "Mark"}, new Player{Name = "Murray"}, 4, 3, "Advantage Mark").SetName("Player 1 Advantage");
            yield return new TestCaseData(new Player{Name = "Mark"}, new Player{Name = "Murray"}, 3, 4, "Advantage Murray").SetName("Player 2 Advantage");
        }                                                                           
    }
}
