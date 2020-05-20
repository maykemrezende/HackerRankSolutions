using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    
    public class Test
    {
        [Fact]
        public void Testa()
        {
            int numFeatures = 5;
            int topFeatures = 2;
            List<string> possibleFeatures = new List<string> { "anacell", "betacelular", "cetracular", "deltacellular", "eurocell" };
            int numFeatureRequests = 3;
            List<string> featureRequests = new List<string> { "best services provided by anacell", "betacellular has great services", "anacell provides much better services than all other" };

            var teste = IceCreamParlorSolution.PopularNFeatures(numFeatures, topFeatures, possibleFeatures, numFeatureRequests, featureRequests);
        }

        [Fact]
        public void Testa2()
        {
            int logFileSize = 5;
            string[] logLines = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };

            var teste = IceCreamParlorSolution.reorderLines(logFileSize, logLines);
        }
    }
}
