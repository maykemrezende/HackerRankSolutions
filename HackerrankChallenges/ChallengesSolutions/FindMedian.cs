using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class FindMedian
    {
        public static int Solution(int[] arr)
        {
            arr = arr.OrderBy(a => a).ToArray();
            var median = arr.Length / 2;

            return arr[median];
        }
    }
}
