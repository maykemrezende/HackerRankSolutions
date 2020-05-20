using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public class IceCreamParlorSolution
    {
        public static int[] Solution(int m, int[] arr)
        {
			if (arr.Length == 0) return null;
            var dict = GetDict(arr);
            for (var i = 0; i < m; i++)
            {
                var diff = m - arr[i];
                if (dict.ContainsKey(diff))
                {
                    var list = dict[diff];
                    if (list[0] != i)
                        return new int[] { i+1, list[0]+1 }.OrderBy(x => x).ToArray();

                    if (list.Count > 1)
                        return new int[] { i+1, list[1]+1 }.OrderBy(x => x).ToArray();
                }
            }

            return null;
        }

        private static Dictionary<int, List<int>> GetDict(int[] arr)
        {
            var dict = new Dictionary<int, List<int>>(arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                    dict[arr[i]] = new List<int>(arr.Length);

                dict[arr[i]].Add(i);
            }

            return dict;
        }

        public static List<string> PopularNFeatures(int numFeatures,
                                        int topFeatures,
                                        List<string> possibleFeatures,
                                        int numFeatureRequests,
                                        List<string> featureRequests)
        {
            // WRITE YOUR CODE HERE
            if (topFeatures > numFeatureRequests) 
                return OnlyFeaturesMentionedInFeatureRequests(numFeatures, 
                    topFeatures, 
                    possibleFeatures, 
                    numFeatureRequests, 
                    featureRequests);

            var featuresAndQuantities = new Dictionary<string, int>();
            var mostWantedFeatures = new List<string>();
            foreach(var feature in possibleFeatures)
            {
                var quantity = featureRequests.Where(f => f.Contains(feature)).Count();

                featuresAndQuantities.Add(feature, quantity);                
            }

            var dicOrdered = featuresAndQuantities.OrderByDescending(x => x.Value).ToArray();

            for (int i = 0; i < topFeatures; i++)
                mostWantedFeatures.Add(dicOrdered[i].Key);

            return mostWantedFeatures;
        }

        private static List<string> OnlyFeaturesMentionedInFeatureRequests(int numFeatures,
                                        int topFeatures,
                                        List<string> possibleFeatures,
                                        int numFeatureRequests,
                                        List<string> featureRequests)
        {
            var featuresMentioned = new List<string>();

            foreach (var feature in possibleFeatures)
            {
                var mentioned = featureRequests.Any(f => f.Contains(feature));

                if (mentioned)
                    featuresMentioned.Add(feature);
            }

            return featuresMentioned;
        }

        public static List<string> reorderLines(int logFileSize, string[] logLines)
        {
            // WRITE YOUR CODE HERE
            if (logLines == null || logLines.Length == 0) return logLines.ToList();

            var letters = new List<string>();
            var digits = new List<string>();

            foreach(var line in logLines)
            {
                if (line.Split(" ")[1].ElementAt(0) < 'a')                
                    digits.Add(line);
                
                else                
                    letters.Add(line);                
            }

            letters.Sort((l1, l2) => 
            {
                string[] letter1 = l1.Split(" "); 
                string[] letter2 = l2.Split(" ");
                var s1Length = letter1.Length;
                var s2Length = letter2.Length;

                for(int i = 1; i < Math.Min(s1Length, s2Length); i++)
                {
                    if (letter1[i] != letter2[i])
                        return letter1[i].CompareTo(letter2[i]);
                }

                return 0;
            });

            for (int i = 0; i < logLines.Length; i++)
            {
                if (i < letters.Count)
                    logLines[i] = letters[i];
                else
                    logLines[i] = digits[i - letters.Count];
            }

            return logLines.ToList();
        }
    }
}
