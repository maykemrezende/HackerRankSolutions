using Bogus;
using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class MeetupScheduleTests
    {
        [Fact]
        public void Testa()
        {
            var firstDay = new List<int>() { 3,1,10,11 };
            var lastDay = new List<int>() { 3,11,10,11};

            //for (int i = 0; i < 1739; i++)
            //    firstDay.Add(new Faker().Random.Number());
            //for (int i = 0; i < 1710; i++)
            //    lastDay.Add(new Faker().Random.Number());

            var teste = MeetupSchedule.countMeetings(firstDay, lastDay);
        }
    }

    public class Teste
    {
        public List<int> FirstDay { get; set; }
        public List<int> LastDay { get; set; }
    }
}
