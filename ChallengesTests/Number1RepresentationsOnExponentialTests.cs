using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class Number1RepresentationsOnExponentialTests
    {
        [Theory]
        [InlineData(20)]
        public void TestNumber1Representations(int test1)
        {
            var result = Number1RepresentationsOnExponential.Solution(test1);

            result.Should().Be(3);
        }

        [Theory]
        [InlineData(1)]
        public void TestNumber1Representations2(int test1)
        {
            var result = Number1RepresentationsOnExponential.Solution(test1);

            result.Should().Be(2);
        }
    }
}
