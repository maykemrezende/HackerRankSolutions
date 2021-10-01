using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;

namespace HackerrankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = new List<int> { 1, 2, 3 };
            var secondLine = new List<int> { 4, 5, 6 };
            var thirdLine = new List<int> { 9, 8, 9 };

            var matrix = new List<List<int>> { firstLine, secondLine, thirdLine };

            var camelcaseQtd = Solutions.DiagonalDifference(matrix);
            Console.WriteLine("camelcaseQtd: {0}", camelcaseQtd);
            Console.ReadKey();
        }
    }
}
