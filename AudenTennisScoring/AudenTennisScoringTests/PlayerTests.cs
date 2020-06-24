using System.Collections.Generic;
using AudenTennisScoring;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests
{
    [TestFixture]
    public class PlayerTests
    {
        [TestCaseSource(nameof(CreatePoints))]
        public void Players_Points_AreCorrectly_Calculated(int currentPoints, int expectedPoints)
        {
            var player = new Player {Points = currentPoints};
            player.Scores();
            player.Points.Should().Be(expectedPoints);
        }

        private static IEnumerable<TestCaseData> CreatePoints()
        {
            yield return new TestCaseData(0, 15);
            yield return new TestCaseData(15, 30);
            yield return new TestCaseData(30, 40);
            yield return new TestCaseData(40, 41);
            yield return new TestCaseData(41, 42);
        }
    }
}