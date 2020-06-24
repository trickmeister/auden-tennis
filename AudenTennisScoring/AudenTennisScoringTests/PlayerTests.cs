using System.Collections.Generic;
using AudenTennisScoring;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisTests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;
        [OneTimeSetUp]
        public void Setup()
        {
            _player = new Player();
        }

        [TestCaseSource(nameof(CreatePoints))]
        public void Players_Points_AreCorrectly_Calculated( int expectedPoints)
        {
            _player.Scores();
            _player.Points.Should().Be(expectedPoints);
        }

        private static IEnumerable<TestCaseData> CreatePoints()
        {
            yield return new TestCaseData(15);
            yield return new TestCaseData(30);
            yield return new TestCaseData(40);
            yield return new TestCaseData(41);
            yield return new TestCaseData(42);
        }
    }
}