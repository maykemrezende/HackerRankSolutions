using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    static class Solutions
    {
            
        public static int SquaresBestSolution(int a, int b)
        => (int)Math.Floor(Math.Sqrt(b)) - (int)Math.Ceiling(Math.Sqrt(a)) + 1;
        

        public static void extraLongFactorials(int n)
        {
            Console.WriteLine(Calculate(n));
        }

        public static BigInteger Calculate(int n)
        {
            if (n == 1)
                return 1;

            return n * Calculate(n - 1);
        }

        public static string SuperReducedString(string s)
        {

            for (int i = 1; i < s.Length; i++)
            {
                if (s.Substring(i - 1, 1) == s.Substring(i, 1))
                {
                    s = s.Remove(i-1, 2);
                    i = 0;
                }
            }

            if (s.Length == 0) return "Empty String";

            return s;
        }

        public static int Camelcase(string s)
        {
            var qtd = 1;

            foreach (char c in s)
            {
                if (char.IsUpper(c))                
                    qtd++;
            }

            return qtd;
        }

        public static int[] BreakingRecords(int[] scores)
        {
            var fistScore = scores[0];
            var bestScore = scores[0];
            var worstScore = scores[0];
            var bestScores = new HashSet<int>();
            var worstScores = new HashSet<int>();

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > bestScore)
                {
                    bestScores.Add(scores[i]);
                    bestScore = scores[i];
                }
                else if (scores[i] < worstScore)
                {
                    worstScores.Add(scores[i]);
                    worstScore = scores[i];
                }
            }

            return new int[] { bestScores.Count, worstScores.Count };
        }

        public static string CatAndMouse(int x, int y, int z)
        {
            var unitsCatAFromMouse = Math.Abs(z - x);
            var unitsCatBFromMouse = Math.Abs(z - y);

            if (unitsCatAFromMouse > unitsCatBFromMouse)
                return "Cat B";
            else if (unitsCatAFromMouse < unitsCatBFromMouse)
                return "Cat A";

            return "Mouse C";
        }

        public static int Birthday(List<int> s, int d, int m)
        {
            var count = 0;

            for (int i = 0; i < s.Count(); i++)
            {
                var arraySlice = s.Skip(i).Take(m);

                if (arraySlice.Sum() == d)
                    count++;
            }

            return count;
        }

        public static int DiagonalDifference(List<List<int>> arr)
        {
            int i = -1, j = -1, rightSum = 0, leftSum = 0;

            //summing left diagonal
            foreach (List<int> subList in arr)
            {
                i++;
                foreach (var item in subList)
                {
                    j++;

                    if (i == j)
                        leftSum += item;
                }
                j = -1;
            }

            i = arr.Count();
            j = -1;

            //summing right diagonal
            foreach (List<int> subList in arr)
            {
                i--;
                foreach (var item in subList)
                {
                    j++;

                    if (i == j)
                        rightSum += item;
                }
                j = -1;
            }

            return Math.Abs(leftSum - rightSum);
        }

        public static void miniMaxSum(long[] arr)
        {
            var sumCollection = new HashSet<long>();

            for (int i = 0; i < arr.Length; i++)
            {
                var sum = arr.Sum() - arr[i];
                    sumCollection.Add(sum);
            }

            Console.WriteLine("{0} {1}", sumCollection.Min(), sumCollection.Max());
        }
    }
}
