using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class IntToRomanNumberTests
    {
        [Theory]
        [InlineData(20)]
        public void TestIntToRomanNumber(int test1)
        {
            var result = IntToRomanNumber.ToRoman(test1);

            result.Should().Be("XX");
        }

        [Theory]
        [InlineData(3999)]
        public void TestIntToRomanNumber1(int test1)
        {
            var result = IntToRomanNumber.ToRoman(test1);

            result.Should().Be("MMMCMXCIX");
        }
    }
}
