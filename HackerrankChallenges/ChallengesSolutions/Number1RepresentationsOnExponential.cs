using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class Number1RepresentationsOnExponential
    {
        public static int Solution(int number)
        {
            if (number == 0) 
                return 1;

            long resultOfPow = 1;

            for (int i = 1; i <= number; i++)
                resultOfPow *= 11L;

            Regex pattern = new Regex("1");
            var mat = pattern.Matches(resultOfPow.ToString());

            return mat.Count;
        }
    }
}
