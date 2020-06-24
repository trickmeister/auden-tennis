using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AudenTennisScoring;
using AudenTennisScoring.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests.Strategies
{
    [TestFixture]
    public class ScoreEqualsStrategyTests
    {
        [TestCaseSource(nameof(CreateAcceptStrategies))]
        public void Strategy_Accepts_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, bool expectedResult )
        {
            var strategy = new ScoreEqualsStrategy();
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
            yield return new TestCaseData(new Player(), new Player(), 0, 0, true).SetName("Love All test");
            yield return new TestCaseData(new Player(), new Player(), 1, 1, true).SetName("15 All test");
            yield return new TestCaseData(new Player(), new Player(), 2, 2, true).SetName("30 All test");
            yield return new TestCaseData(new Player(), new Player(), 3, 3, true).SetName("15 0 test");
            yield return new TestCaseData(new Player(), new Player(), 2, 1, false).SetName("30 15 test");
            yield return new TestCaseData(new Player(), new Player(), 3, 1, false).SetName("40 15 test");
            yield return new TestCaseData(new Player(), new Player(), 3, 0, false).SetName("30 0 test");
        }

        [TestCaseSource(nameof(CreateScores))]
        public void Strategy_Score_Correctly(Player player1, Player player2, int scoreLoop1, int scoreLoop2, string expectedResult)
        {
            var strategy = new ScoreEqualsStrategy();
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
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="Federer"}, 0, 0, "Mark 0  Federer 0" ).SetName("Love All test");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="Federer"}, 1, 1, "15 All").SetName("15 All test");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="Federer"}, 2, 2, "30 All").SetName("30 All test");
            yield return new TestCaseData(new Player{Name="Mark"}, new Player{Name="Federer"}, 3, 3, "Deuce").SetName("Deuce test");
        }
    }
}
