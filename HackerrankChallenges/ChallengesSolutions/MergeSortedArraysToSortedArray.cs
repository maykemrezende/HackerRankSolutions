using System;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class MergeSortedArraysToSortedArray
    {
        public static void Merge(int[] array, int start, int middle, int end)
        {

            if (array[middle - 1] <= array[middle])            
                return;
            

            int newStart = start;
            int newMiddle = middle;
            int tempIndex = 0;
            int[] tempArray = new int[end - start];

            while (newStart < middle && newMiddle < end)            
                tempArray[tempIndex++] = array[newStart] <= array[newMiddle] ? array[newStart++] : array[newMiddle++];
            

            Array.Copy(array, newStart, array, start + tempIndex, middle - newStart);
            Array.Copy(tempArray, 0, array, start, tempIndex); // if there is any leftovers on the left array, for example {32,36} and {33,34}
        }        
    }
}
