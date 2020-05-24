using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class ChooseFlask
    {
        public static int Solution(List<int> requirements, int flaskTypes, List<List<int>> markings)
        {
            var requiLength = requirements.Count;
            var indexToReturn = -1;
            var sumOfMarking = 0L;
            var sumOfMarkingPrev = long.MaxValue;
            var j = 0;
            var requirementsUsedQtd = 0;
            var wastes = 0L;
            var markingsArray = markings.Select(Enumerable.ToArray).ToArray();
            var requirementsArray = requirements.ToArray();

            requirementsArray = CountingSort(requirementsArray);
            var maxRequirements = requirementsArray[requirementsArray.Length - 1];

            for (int i = 0; i < flaskTypes; i++)
            {
                var flasksOfType = markingsArray.Where(m => m[0] == i).ToArray();
                var maxMeasu = flasksOfType[flasksOfType.Length - 1][1];

                if (maxMeasu >= maxRequirements)
                {
                    var flaskIndex = 0;
                    for (int p = 0; p < flasksOfType.Length; p++) 
                    {
                        var flask = flasksOfType[p];

                        flaskIndex = flask[0];
                        var flaskMeasurement = flask[1];

                        for (j = requirementsUsedQtd; j < requirementsArray.Length;)
                        {
                            if (flaskMeasurement >= requirementsArray[j])
                            {
                                var waste = flaskMeasurement - requirementsArray[j];
                                wastes += waste;
                                requirementsUsedQtd++;
                                j = requirementsUsedQtd;
                            }
                            else
                                break;                        
                        }

                        if (wastes > 0)                        
                            sumOfMarking += wastes;

                        wastes = 0L;
                    }

                    requirementsUsedQtd = 0;

                    if (indexToReturn < flaskIndex && sumOfMarking < sumOfMarkingPrev)
                    {
                        sumOfMarkingPrev = sumOfMarking;
                        indexToReturn = flaskIndex;
                    }
                    sumOfMarking = 0L;
                }
            }

            return indexToReturn;
        }

        private static int[] CountingSort(int[] requirements)
        {
            int[] countOfElements = new int[requirements.Max()+1];

            for (int i = 0; i < requirements.Length; i++)
            {
                int value = requirements[i];
                countOfElements[value]++;
            }

            for (int i = 1; i < countOfElements.Length; i++)            
                countOfElements[i] = countOfElements[i] + countOfElements[i - 1];
            

            int[] sortedArray = new int[requirements.Length];

            for (int i = requirements.Length - 1; i >= 0; i--)
            {
                int value = requirements[i];
                int position = countOfElements[value] - 1;
                sortedArray[position] = value;

                countOfElements[value]--;
            }

            return sortedArray;
        }


        public static int Solution2(List<int> requirements, int flaskTypes, List<List<int>> markings)
        {
            var maxRequirements = requirements[requirements.Count - 1];
            var requiLength = requirements.Count;
            var indexToReturn = -1;
            var sumOfMarking = 0L;
            var sumOfMarkingPrev = 100000L;
            var j = 0;
            var requirementsUsedQtd = 0;
            var markingsOfFlask = new List<List<int>>();

            for (int i = 0; i < markings.Count; i++)
            {
                markingsOfFlask.Add(markings[i]);

                if (markings[i][0] < markings[i + 1][0])
                {
                    //faço o calculo e continuo o loop
                    //faço o loop dos requirements
                } 
            }

            return 0;
        }


    }
}
