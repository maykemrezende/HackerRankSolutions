using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static int MyAtoi(string str)
        {
            str = str.Trim();
            if (str[0] == '-' && char.IsDigit(str[1]))            
                return CheckDigit(str);
            else if (char.IsDigit(str[0]))
                return CheckDigit(str);

            return 0;
        }

        private static int CheckDigit(string str)
        {
            var regex = new Regex("[^-0-9]");
            var result = regex.Replace(str, "");

            var number = Convert.ToInt64(result);

            if (number < int.MinValue)
                return int.MinValue;

            if (number > int.MaxValue)
                return int.MaxValue;

            return (int)number;
        }

        public static int MyAtoiWithoutRegex(string str)
        {
            str = str.Trim();

            if (string.IsNullOrEmpty(str))
                return 0;

             if (char.IsDigit(str[0]))
                return CheckDigitWithouRegex(str, 0);
            else if (char.IsLetter(str[0]) is false)
                return CheckDigitWithouRegex(str, 1);

            return 0;
        }

        private static int CheckDigitWithouRegex(string str, int indexToStart)
        {
            int substringStartIndex = indexToStart;
            int substringFinalIndex = 0;
                       
            for (int i = substringStartIndex; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    substringFinalIndex++;
                else
                    break;
            }

            if (substringFinalIndex > 0)
            {
                var number = Convert.ToInt64(str.Substring(substringStartIndex, substringFinalIndex));

                if (str[0] == '-')
                    number *= -1;

                if (number < int.MinValue)
                    return int.MinValue;

                if (number > int.MaxValue)
                    return int.MaxValue;

                return (int)number;
            }

            return 0;
        }
    }
}
