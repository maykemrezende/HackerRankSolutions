using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class ClosestNumbers
    {
        public static int[] ClosestNumbersResolution(int[] arr)
        {
            var pairs = new List<int>();
            arr = arr.OrderBy(x => x).ToArray();       
            int arrLength = arr.Length;
            var smallestDifference = arr[1] - arr[0];
            pairs.Add(arr[0]);
            pairs.Add(arr[1]);

            for (int i = 1; i < arrLength - 1; i++)
            {
                if (arr[i+1] - arr[i] < smallestDifference)
                {
                    pairs = null;
                    pairs = new List<int>();
                    pairs.Add(arr[i]);
                    pairs.Add(arr[i+1]);
                    smallestDifference = Math.Abs(arr[i + 1] - arr[i]);
                }
                else if (arr[i + 1] - arr[i] == smallestDifference)
                {
                    pairs.Add(arr[i]);
                    pairs.Add(arr[i + 1]);
                }
            }
            return pairs.ToArray();
        }
    }
}
