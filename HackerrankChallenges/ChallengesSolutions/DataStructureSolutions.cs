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
            d = 7;
            array = new int[] { 1, 2, 3, 4, 5 };
            n = array.Length;
            if (d > n)
                d = d - n;

            var tempArr = array.Take(d).ToArray();
            array = array.Skip(d).ToArray();
            array = array.Concat(tempArr).ToArray();

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
