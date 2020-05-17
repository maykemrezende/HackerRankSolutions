using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using Xunit;

namespace ChallengesTests
{
    public class ActivityNotificationsTests
    {
        [Theory]
        [InlineData(new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5)]
        public void TestActivityNotifications(int[] test1, int days)
        {
            var result = ActivityNotifications.Solution(test1, days);

            result.Should().Be(2);
        }

        [Theory]
        [InlineData(new int[] { 10, 20, 30, 40, 50 }, 3)]
        public void TestActivityNotifications2(int[] test1, int days)
        {
            var result = ActivityNotifications.Solution(test1, days);

            result.Should().Be(1);
        }
    }
}
