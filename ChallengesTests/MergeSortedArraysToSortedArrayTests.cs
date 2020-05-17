using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using Xunit;

namespace ChallengesTests
{
    public class MergeSortedArraysToSortedArrayTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 4, 5, 8, 3, 6, 8, 9, 10 })]
        public void TestMerge(int[] test1)
        {
            MergeSortedArraysToSortedArray.Merge(test1, 0, test1.Length / 2, test1.Length);

            test1.Should().BeEquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 8, 8, 9, 10 });
        }
    }
}
