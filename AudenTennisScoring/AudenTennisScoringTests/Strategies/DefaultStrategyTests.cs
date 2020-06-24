using System.Collections.Generic;
using AudenTennisScoring;
using AudenTennisScoring.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests.Strategies
{
    [TestFixture]
    public class DefaultStrategyTests
    {
        [TestCaseSource(nameof(CreateAcceptStrategies))]
        public void Strategy_Accepts_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, bool expectedResult )
        {
            var strategy = new DefaultStrategy();
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
            yield return new TestCaseData(new Player(), new Player(), 0, 1, true).SetName("0 15 test");
            yield return new TestCaseData(new Player(), new Player(), 3, 1, true).SetName("40 15 test");
            yield return new TestCaseData(new Player(), new Player(), 1, 3, true).SetName("15 40 test");
            yield return new TestCaseData(new Player(), new Player(), 2, 1, true).SetName("30 15 test");
            yield return new TestCaseData(new Player(), new Player(), 1, 2, true).SetName("15 30 test");
            yield return new TestCaseData(new Player(), new Player(), 2, 2, false).SetName("30 all");
            yield return new TestCaseData(new Player(), new Player(), 3, 3, false).SetName("Deuce");
            yield return new TestCaseData(new Player(), new Player(), 4, 3, false).SetName("Player 1 advantage");
            yield return new TestCaseData(new Player(), new Player(), 3, 4, false).SetName("Player 2 advantage");
        }

        [TestCaseSource(nameof(CreateScores))]
        public void Strategy_Score_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, string expectedResult)
        {
            var strategy = new DefaultStrategy();
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
            yield return new TestCaseData(new Player(), new Player(), 0, 1, "0 15").SetName("0 15 test");
            yield return new TestCaseData(new Player(), new Player(), 3, 1, "40 15").SetName("40 15 test");
            yield return new TestCaseData(new Player(), new Player(), 1, 3, "15 40").SetName("15 40 test");
            yield return new TestCaseData(new Player(), new Player(), 2, 1, "30 15").SetName("30 15 test");
            yield return new TestCaseData(new Player(), new Player(), 1, 2, "15 30").SetName("15 30 test");
        }                                                                           
    }
}
