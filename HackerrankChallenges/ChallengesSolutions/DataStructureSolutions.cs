using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class DataStructureSolutions
    {
        public static void RotateArray(int[] array, int d, int n)
        {
            if (d > n)
                d = d - n;

            var tempArr = array.Take(d).ToArray();
            array = array.Skip(d).ToArray();
            array = array.Concat(tempArr).ToArray();

            Console.WriteLine(string.Join(' ', array));
        }

        public static int[] matchingStrings(string[] strings, string[] queries)
        {
            var results = new List<int>();

            foreach (var query in queries)
            {
                var count = strings.Where(s => s == query).ToArray().Count();
                results.Add(count);
            }

            return results.ToArray();
        }
    }
}
