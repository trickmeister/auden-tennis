using AudenTennisScoring;
using FluentAssertions;
using NUnit.Framework;

namespace AudenTennisScoringTests
{
    [TestFixture]
    public class TempTest
    {


        //Used constructor instead of setup as only want DB creation to be done once
        [Test]
        public void Class1Test()
        {
            new Class1().Name.Should().Be("Mark");
        }
    }
}