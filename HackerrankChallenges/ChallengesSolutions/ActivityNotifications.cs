using System.Linq;

namespace HackerrankChallenges.ChallengesSolutions
{
    public class ActivityNotifications
    {
        const int MAX_EXPENDITURE = 200;

        public static int Solution(int[] expenditure, int d)
        {
            int n = expenditure.Length;
            int notifications = 0;
            int[] tempArray = new int[MAX_EXPENDITURE + 1];

            // Carry a temp array of the last expenditures in d days
            for (int i = 0; i < d; i++)            
               tempArray[expenditure[i]] = tempArray[expenditure[i]] + 1;            

            for (int i = d; i < n; i++)
            {
                int cursor = 0;
                int currentAmount = expenditure[i];
                double median = 0;
                int left = -1;
                int right = -1;
                for (int j = 0; j <= MAX_EXPENDITURE; j++)
                {
                    cursor += tempArray[j];
                    if (d % 2 == 1)
                    {
                        // odd 
                        if (cursor >= d / 2 + 1)
                        {
                            median = j;
                            break;
                        }
                    }
                    else
                    {
                        // even
                        if (cursor == d / 2)
                            left = j;

                        if (cursor > d / 2 && left != -1)
                        {
                            right = j;
                            median = (left + right) / 2.0;
                            break;
                        }

                        if (cursor > d / 2 && left == -1)
                        {
                            median = j;
                            break;
                        }
                    }
                }

                if (currentAmount >= 2 * median)
                    notifications++;

                //update temp array: slide 1 index to right
                tempArray[expenditure[i - d]] = tempArray[expenditure[i - d]] - 1;
                tempArray[expenditure[i]] = tempArray[expenditure[i]] + 1;
            }

            return notifications;
        }
    }
}
