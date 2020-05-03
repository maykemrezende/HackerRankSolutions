using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;

namespace HackerrankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 1, 3, 2 };
            var camelcaseQtd = Solutions.Birthday(list, 3, 2);
            Console.WriteLine("camelcaseQtd: {0}", camelcaseQtd);
            Console.ReadKey();
        }
    }
}
