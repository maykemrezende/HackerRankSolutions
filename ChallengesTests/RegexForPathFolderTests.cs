using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using Xunit;

namespace ChallengesTests
{
    public class RegexForPathFolderTests
    {
        [Theory]
        [InlineData("test/works/maybe")]
        public void TestRegexForPathFolder(string test1)
        {
            var result = RegexForPathFolder.Solution(test1);

            result.Should().Be("maybe");
        }

        [Theory]
        [InlineData("")]
        public void TestRegexForPathFolder1(string test1)
        {
            test1 = string.Empty;
            var result = RegexForPathFolder.Solution(test1);

            result.Should().Be(string.Empty);
        }

        [Theory]
        [InlineData("folder/folder")]
        public void TestRegexForPathFolder2(string test1)
        {
            test1 = string.Empty;
            var result = RegexForPathFolder.Solution(test1);

            result.Should().Be(string.Empty);
        }

        [Theory]
        [InlineData("folder1/folder2/folder3")]
        public void TestRegexForPathFolder3(string test1)
        {
            var result = RegexForPathFolder.SolutionForMiddleFolder(test1);

            result.Should().Be("folder2");
        }
    }
}
