using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class LeetCodeSolutions
    {
        public static  ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var str1 = new StringBuilder();
            var str2 = new StringBuilder();

            var sum = Sum(l1, l2, str1, str2);

            return sum;
        }

        private static ListNode Sum(ListNode l1, ListNode l2, StringBuilder str1, StringBuilder str2)
        {
            if (l1 is null && l2 is null)
            {
                str1.ToString().Reverse();
                return ReturnNew(, str2.ToString().Reverse().ToString());
            }

            str1.Append(l1.val);
            str2.Append(l2.val);

            l1 = l1.next;
            l2 = l2.next;            

            return Sum(l1, l2, str1, str2);
        }

        private static ListNode ReturnNew(string str1, string str2)
        {
            var sum = Convert.ToInt32(str1) + Convert.ToInt32(str2);
            var sumString = sum.ToString();
            var firstNode = new ListNode(sumString[0]);
            var nextNode = firstNode;
            int i = 1;

            while (nextNode != null)
            {
                var toAdd = new ListNode(sumString[i]);
                nextNode.next = toAdd;
            }

            return firstNode;
        }
    }
}
