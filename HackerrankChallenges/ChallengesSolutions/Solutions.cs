﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    static class Solutions
    {

        public static int hurdleRace(int k, List<int> height)
        {
            var naturalJumpMax = k;

            var tallest = height.Max();

            if (tallest <= naturalJumpMax)
                return 0;

            return tallest - naturalJumpMax;
        }


        public static int countingValleys(int steps, string path)
        {
            if (steps == 2)
            {
                if (path[0] == 'D' && path[1] == 'U')
                    return 1;
                else if (path[0] == 'U' && path[1] == 'D')
                    return 0;
            }

            var seaLevel = 0;
            var valleyCount = 0;


            var level = 0;


            for (int step = 0; step < steps; step++)
            {
                var stepDirection = path[step];

                if (stepDirection == 'U')
                {
                    ++level;

                    if (level == seaLevel)
                        ++valleyCount;
                }
                else if (stepDirection == 'D')
                    --level;

            }

            return valleyCount;
        }

        public static void bonAppetit(List<int> bill, int k, int b)
        {
            var annaChargedMoney = b;
            var itemDoestEated = k;


            var realBill = IgnoreItemAtPosition(itemDoestEated, bill).ToList();

            var totalPaid = realBill.Sum();
            var totalPaidByAnna = totalPaid / 2;

            if (totalPaidByAnna == annaChargedMoney)
                Console.WriteLine("Bon Appetit");
            else if (totalPaidByAnna < annaChargedMoney)
                Console.WriteLine(annaChargedMoney - totalPaidByAnna);

        }

        public static IEnumerable<int> IgnoreItemAtPosition(int position, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i != position)
                    yield return list[i];
            }
        }

        public static List<List<int>> InvertImage(List<List<int>> image)
        {
            var returning = new List<List<int>>();


            for (int row = image.Count - 1; row >= 0; row--)
            {
                var position = image[row];

                position.Reverse();
                returning.Add(position);
            }

            return returning;
        }

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
                    s = s.Remove(i - 1, 2);
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

        public static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            // s = starting point of Sam's house location, 
            // t = ending location of Sam's house location, 
            // a = location of the Apple tree
            // b = location of the Orange tree

            int[] applesDistances = new int[apples.Length];
            int[] orangesDistances = new int[oranges.Length];

            for (int i = 0; i < apples.Length; i++)
                applesDistances[i] = a + apples[i];


            for (int i = 0; i < oranges.Length; i++)
                orangesDistances[i] = b + oranges[i];

            var applesOnSamsHouse = applesDistances.Where(apple => apple >= s && apple <= t).Count();
            var orangesOnSamsHouse = orangesDistances.Where(orange => orange >= s && orange <= t).Count();

            Console.WriteLine(applesOnSamsHouse);
            Console.WriteLine(orangesOnSamsHouse);
        }

        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            /*
             *  x1, v1: integers, starting position and jump distance for kangaroo 1
                x2, v2: integers, starting position and jump distance for kangaroo 2
             */

            if ((x1 < x2) && ((v1 < v2) || (v1 == v2)))
                return "NO";

            var result = (x1 - x2) % (v2 - v1);
            if (result == 0)
                return "YES";

            return "NO";
        }

        public static List<int> gradingStudents(List<int> grades)
        {
            return MountGrades(grades).ToList();
        }

        private static IEnumerable<int> MountGrades(List<int> grades)
        {
            foreach (var grade in grades)
            {
                if (grade < 38)
                    yield return grade;
                else
                {
                    for (int i = grade; i <= 100; i++)
                    {
                        if (i % 5 == 0)
                        {
                            if (i - grade < 3)
                                yield return i;
                            else
                                yield return grade;

                            break;
                        }
                    }
                }
            }
        }

        public static int divisibleSumPairs(int n, int k, int[] ar)
        {
            /*
             *  n: the integer length of array 
                ar: an array of integers
                k: the integer to divide the pair sum by
             */

            int pairs = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        pairs++;
                }
            }

            return pairs;
        }

        public static string encryption(string s)
        {
            var stringWithoutSpaces = s.Replace(" ", "");
            var root = Math.Sqrt(stringWithoutSpaces.Length);
            var columns = Convert.ToInt32(Math.Floor(root));
            var rows = Convert.ToInt32(Math.Ceiling(root));

            if (rows >= root)
                columns = rows;
            else
                columns = rows + 1;

            var builder = new StringBuilder();

            for (int i = 0; i < columns; i++)
            {
                for (int j = i; j < stringWithoutSpaces.Length; j += columns)
                    builder.Append(stringWithoutSpaces[j]);


                builder.Append(" ");
            }

            return builder.ToString();
        }

        // Complete the insertionSort1 function below.
        public static void insertionSort1(int n, int[] arr)
        {
            var element = arr[n - 1];
            var inserted = false;
            for (int i = n - 2; i >= 0; i--)
            {
                if (inserted && arr[i + 1] < arr[i])
                {
                    var aux = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = aux;
                    Console.WriteLine(string.Join(" ", arr));
                }
                else if (inserted && arr[i + 1] > arr[i])
                    break;
                else
                {
                    if (arr[i] > element)
                    {
                        arr[i + 1] = arr[i];
                        Console.WriteLine(string.Join(" ", arr));
                    }
                    else

                    if (arr[i] < element)
                    {
                        arr[i + 1] = element;
                        inserted = true;
                        Console.WriteLine(string.Join(" ", arr));
                    }
                }

                if (i == 0 && inserted == false)
                {
                    arr[0] = element;
                    Console.WriteLine(string.Join(" ", arr));
                }
            }
        }

        public static void insertionSort(int[] A)
        {
            int n = A.Length, i, j;
            int val = 0;
            var switched = false;
            for (i = 1; i < n; i++)
            {
                val = A[i];
                switched = false;
                for (j = i - 1; j >= 0 && switched != true;)
                {
                    if (val < A[j])
                    {
                        A[j + 1] = A[j];
                        j--;
                        A[j + 1] = val;
                    }
                    else
                        switched = true;

                }
            }
        }

        public static int runningTime(int[] arr)
        {
            int n = arr.Length, i, j;
            int val = 0;
            var switched = false;
            var shifts = 0;
            for (i = 1; i < n; i++)
            {
                val = arr[i];
                switched = false;
                for (j = i - 1; j >= 0 && switched != true;)
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                        shifts++;
                    }
                    else
                        switched = true;

                }
            }

            return shifts;
        }

        public static int[] countingSort1(int[] arr)
        {
            int[] appearances = new int[100];
            int count = 0;

            for (int i = 0; i < appearances.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i == arr[j])
                        count++;
                }

                appearances[i] = count;
                count = 0;
            }
            return appearances;
        }

        public static int[] countingSort2(int[] arr)
        {
            int length = arr.Length;

            int[] returningArray = new int[length];

            //new counting array to stores the count of each unique number in the arr array
            int[] count = new int[100];
            for (int i = 0; i < 100; ++i)
                count[i] = 0;

            for (int i = 0; i < length; ++i)
                ++count[arr[i]];


            //change count[i] so that count[i] now contains actual position of this character in the returning array.
            for (int i = 1; i <= 99; ++i)
                count[i] += count[i - 1];


            // construct the returning array. We have to do it in a reverse order to make the sorting algorithm stable
            for (int i = length - 1; i >= 0; i--)
            {
                returningArray[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }

            //transfer the returning array to the received array.
            for (int i = 0; i < length; ++i)
                arr[i] = returningArray[i];

            return returningArray;
        }        

        private static int[] InsertionSort(int[] arr)
        {
            int n = arr.Length, i, j;
            int val = 0;
            var switched = false;
            var shifts = 0;
            for (i = 1; i < n; i++)
            {
                val = arr[i];
                switched = false;
                for (j = i - 1; j >= 0 && switched != true;)
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                        shifts++;
                    }
                    else
                        switched = true;

                }
            }

            return arr;
        }

        public static string ReverseString(string word)
        {
            char[] chars = word.ToCharArray();
            for (int i = 0; i < word.Length / 2; i++)
            {
                var begin = chars[i];
                var end = chars[word.Length - i - 1];
                chars[i] = end;
                chars[word.Length - i - 1] = begin;
            }
            var sb = new StringBuilder();
            sb.Append(chars);
            return sb.ToString();
        }

        public static bool ArmstrongNumber(int number)
        {
            int i = 10;
            int res = 0;
            int newNum = number;
            while (newNum > 0)
            {
                res += (int)Math.Pow(newNum % 10, 3);
                newNum = number / i;
                i = i * 10;
            }
            return res == number;
        }
    }
        
}
