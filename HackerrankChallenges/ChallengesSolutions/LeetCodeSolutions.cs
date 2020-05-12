using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class LeetCodeSolutions
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var fakeHead = new ListNode(0);
            var l3 = fakeHead;

            int carry = 0;

            while (l1 != null || l2 != null)
            {
                var l1Val = l1 != null ? l1.val : 0;
                var l2Val = l2 != null ? l2.val : 0;

                var currentSum = l1Val + l2Val + carry;
                carry = currentSum / 10;
                var lastDigit = currentSum % 10;               

                var newNode = new ListNode(lastDigit);
                l3.next = newNode;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
                l3 = l3.next;
            }

            if (carry > 0)
            {
                var newNodeForCarry = new ListNode(carry);
                l3.next = newNodeForCarry;
                l3 = l3.next;
            }

            return fakeHead.next;
        }

        public static int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (nums.Any(x => x == complement && Array.IndexOf(nums, x) != i))
                {
                    return new int[] { i, Array.IndexOf(nums, complement) };
                }
            }

            throw new InvalidOperationException();
        }
    }
}
