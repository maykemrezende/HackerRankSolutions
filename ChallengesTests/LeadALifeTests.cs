using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class LeadALifeTests
    {
        [Fact]
        public void Testa()
        {
            var n = 3;
            var earning = new List<int> { 7, 2, 4 };
            var cost = new List<int> { 7, 3, 6 };
            var e = 5;

            var teste = LeadALife.calculateProfitDynamicProgramming(n, earning, cost, e);
        }
    }
}
