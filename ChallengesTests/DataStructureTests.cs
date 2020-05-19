using FluentAssertions;
using HackerrankChallenges;
using HackerrankChallenges.ChallengesSolutions;
using Xunit;

namespace ChallengesTests
{
    public class DataStructureTests
    {
        [Fact]
        public void TestBSTHeight()
        {
            var tree = new Node(1)
            {
                Left = new Node(2),
                Right = new Node(3)
            };
            tree.Left.Left = new Node(4);
            tree.Left.Right = new Node(5);

            var result = DataStructureSolutions.HeightOfBST(tree);
            result.Should().Be(3);
        }
    }
}
