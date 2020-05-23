using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerrankChallenges.ChallengesSolutions
{
    public class MeetupSchedule
    {
        public static int countMeetings(List<int> firstDay, List<int> lastDay)
        {
            if (firstDay.Count == 0 || lastDay.Count == 0) return 0;
            if (firstDay.Count != lastDay.Count) return 0;

            var meetingsScheduled = new HashSet<int>();

            meetingsScheduled.Add(firstDay[0]);

            firstDay.RemoveAt(0);
            lastDay.RemoveAt(0);

            var list = SortByPriority(firstDay, lastDay);

            for (int investor = 0; investor < list.Count; investor++)
            {
                var indexInvestor = list[investor].investorIndex;
                var firstDayOfInvestor = firstDay[indexInvestor];
                var lastDayOfInvestor = lastDay[indexInvestor];

                for (int day = firstDayOfInvestor; day <= lastDayOfInvestor; day++)
                {
                    if (!meetingsScheduled.Contains(day))
                    {
                        meetingsScheduled.Add(day);
                        break;
                    }
                }                    
            }            
            
            return meetingsScheduled.Count;
        }

        private static List<(int investorIndex, int daysAvailable)> SortByPriority(List<int> firstDay, List<int> lastDay)
        {
            var differencesCount = new int[lastDay.Max()];

            for (int i = 0; i < firstDay.Count; i++)
            {
                int diff = Math.Abs(firstDay[i] - lastDay[i]);
                differencesCount[diff]++;
            }

            for (int i = 1; i < differencesCount.Length; i++)            
                differencesCount[i] = differencesCount[i] + differencesCount[i - 1];            

            var investorsSortedByPriority = new List<(int, int)>();
            investorsSortedByPriority.AddRange(Enumerable.Repeat((0,0), firstDay.Count));

            for (int i = firstDay.Count - 1; i >= 0; i--)
            {
                int daysForInvestor = Math.Abs(firstDay[i] - lastDay[i]);
                int position = differencesCount[daysForInvestor] - 1;
                investorsSortedByPriority[position] = (i, daysForInvestor);

                differencesCount[daysForInvestor]--;
            }

            return investorsSortedByPriority;
        }
    }
}
