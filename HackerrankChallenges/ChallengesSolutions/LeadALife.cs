using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public class LeadALife
    {
        public static int calculateProfit(int n, List<int> earning, List<int> cost, int e)
        {
            var dp = new int[10,10];           

            for (int j = 0; j < 2*n-1; j++)
            {
                for (int i = 0; i < e+1; i++)
                {
                    if (j == 0) //first day
                        dp[i,j] = i * earning[j];
                    else if (j % 2 != 0)
                    {
                        var maxEarnings = new List<int>();
                        for (var p = i; p < e+1; p++)
                        {
                            var div = decimal.Divide(j, 2M);
                            if (dp[p,j-1] >= (p-i) * cost[(int)Math.Floor(div)])
                            {
                                maxEarnings.Add(dp[p,j-1] - (p-i)*cost[(int)Math.Floor(div)]);
                            }
                        }
                        dp[i, j] = maxEarnings.Max();
                    }
                    else if (j % 2 == 0)
                    {
                        var maxEarnings = new List<int>();
                        var div = decimal.Divide(j, 2M);
                        for (var p = 0; p < e + 1 - i; p++)
                        {
                            maxEarnings.Add(dp[p,j-1] + (e-p-i) * cost[(int)Math.Floor(div)]);
                        }

                        dp[e - i, j] = maxEarnings.Max();
                    }                        
                }
            }
            return dp[-1, -1];
        }


        public static int calculateProfit(int n, List<int> earning, List<int> cost, int e)
        {
            //n = total days of work
            //e = totalEnergy

            var maxEarning = 0;           
            var energyAux = e;            
            var daysWorked = 0;            
            var max = 0;

            for (var day = 0; day < n; day++)
            {
                var lastDay = n - 1;
                if (day != lastDay)
                {
                    var earningCurrentDay = earning[day];
                    var costCurrentDay = cost[day];

                    if (earningCurrentDay > costCurrentDay) // worked full energy
                    {
                        maxEarning += earning[day] * energyAux;
                        e = 0;
                        max = 0;

                        var earnNextDay = earning[day + 1] * energyAux;
                        var earnToday = cost[day] * energyAux;

                        if (earnNextDay > earnToday && maxEarning > 0)
                        {
                            maxEarning -= cost[day] * energyAux; // remove earning for this day, because I'll earn more tomorrow
                            e = energyAux;
                        }
                    }
                    else
                    {
                        daysWorked++;
                        max = Math.Max(max, earning[day]);
                    }
                }
                else
                {
                    if (earning[day] <= cost[day])                    
                        daysWorked++;                    

                    max = Math.Max(max, earning[day]);

                    if (e > 0)
                        maxEarning += energyAux * max;
                }
            }

            if (daysWorked == n)
            {
                earning = earning.OrderBy(e => e).ToList();
                maxEarning = earning[n - 1] * energyAux;
            }

            return maxEarning;
        }

        public static int calculateProfitDynamicProgramming(int n, List<int> earning, List<int> cost, int e)
        {
            var earningArray = earning.ToArray();
            var costArray = cost.ToArray();

            var afterWorkPreviousDay = new int[e + 1];
            var afterEatPreviousDay = new int[e + 1];

            for (int day = 0; day < n; day++)
            {
                var afterWork = AfterWork(afterEatPreviousDay, day, e, costArray);
                var afterEat = AfterEat(afterWorkPreviousDay, day, e, costArray);

                Array.Copy(afterWork, afterWorkPreviousDay, e+1);
                Array.Copy(afterEat, afterEatPreviousDay, e+1);
            }

            return 0;
        }

        private static int[] AfterWork(int[] afterEatPreviousDay, int day, int energy, int[] cost)
        {
            var energyArray = new int[energy+1];
            for (var energyLeft = energy; energyLeft >= 0; energyLeft--)            
                energyArray[energyLeft] = Math.Abs(afterEatPreviousDay[day] - cost[day]) * (Math.Abs(energy - energyLeft));
            

            return energyArray;
        }

        private static int[] AfterEat(int[] afterWorkPreviousDay, int day, int energy, int[] cost)
        {
            var energyArray = new int[energy + 1];
            for (var energyLeft = energy; energyLeft >= 0; energyLeft--)
                energyArray[energyLeft] = Math.Abs(afterWorkPreviousDay[day] - cost[day]) * (Math.Abs(energy - energyLeft));

            return energyArray;
        }
    }
}
