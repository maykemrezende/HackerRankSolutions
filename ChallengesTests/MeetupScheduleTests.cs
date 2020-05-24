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
            var firstDay = new List<int>() { 3,3,4,4 };
            var lastDay = new List<int>() { 3,1,2,2};

            //for (int i = 0; i < 1739; i++)
            //    firstDay.Add(new Faker().Random.Number());
            //for (int i = 0; i < 1710; i++)
            //    lastDay.Add(new Faker().Random.Number());

            var teste = MeetupSchedule.countMeetings(firstDay, lastDay);
        }

        [Fact]
        public void Testa2()
        {
            var firstDay = new List<int>() { 1,2,1,2,2 };
            var lastDay = new List<int>() { 3,2,1,3,3};

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
