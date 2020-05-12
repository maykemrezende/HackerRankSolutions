using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;

namespace HackerrankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var teste = LeetCodeSolutions.AddTwoNumbers(l1, l2);
        }
    }
}
