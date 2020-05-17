using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class ClosestNumbersTests
    {
        [Theory]
        [InlineData(new int[] { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854 })]
        public void TestClosestNumbers(int[] test1)
        {
            var result = ClosestNumbers.ClosestNumbersResolution(test1);

            result.Should().BeEquivalentTo(new int[] { -20, 30 });
        }
    }
}
