using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class DataStructureSolutions
    {
        public static void RotateArray(int[] array, int d, int n)
        {
            if (d > n)
                d = d - n;

            var tempArr = array.Take(d).ToArray();
            array = array.Skip(d).ToArray();
            array = array.Concat(tempArr).ToArray();

            Console.WriteLine(string.Join(' ', array));
        }

        public static int[] matchingStrings(string[] strings, string[] queries)
        {
            var results = new List<int>();

            foreach (var query in queries)
            {
                var count = strings.Where(s => s == query).ToArray().Count();
                results.Add(count);
            }

            return results.ToArray();
        }

        static void printLinkedList(SinglyLinkedListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.data);
                head = head.next;
            }                
        }

        public static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            if (head == null) return new SinglyLinkedListNode(data, null);

            var headTemp = head;
            while (headTemp != null)
            {
                if (headTemp.next == null)
                {
                    headTemp.next = new SinglyLinkedListNode(data, null);
                    break;
                }

                headTemp = headTemp.next;
            }

            return head;
        }

        public static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            var newHead = new SinglyLinkedListNode(data, null);
            if (llist == null) return newHead;

            newHead.next = llist;

            return newHead;
        }

        public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            var newElement = new SinglyLinkedListNode(data, null);
            if (head == null) return newElement;
            if (position == 0) return newElement.next = head;

            var currentPosition = 0;
            var tempHead = head;

            while (currentPosition < position - 1 && head.next != null)
            {
                head = head.next;
                currentPosition++;
            }

            var nodeAtPosition = head.next;
            head.next = newElement;
            head = head.next;
            head.next = nodeAtPosition;

            return tempHead;
        }

        public static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            if (head == null || position == 0) return null;

            var currentPosition = 0;
            var currentNode = head;
            var previous = default(SinglyLinkedListNode);

            while (currentNode.next != null)
            {
                previous = currentNode;
                currentNode = currentNode.next;

                if (currentPosition == position - 1)
                {
                    previous.next = currentNode.next;
                    break;
                }

                currentPosition++;
            }

            return head;
        }

        public static void reversePrint(SinglyLinkedListNode head)
        {
            var list = new List<int>();
            var currNode = head;

            while (currNode != null)
            {
                list.Add(currNode.data);
                currNode = currNode.next;
            }

            list.Reverse();

            list.ForEach(l => Console.WriteLine(l));            
        }

        public static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode prev = null;
            SinglyLinkedListNode current = head;
            SinglyLinkedListNode next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
            return head;
        }

        public static int getNode(SinglyLinkedListNode head, int positionFromTail)
        {
            //if (head == null) return 0;
            //head = reverse(head);
            //if (positiio)

            //var position = 999;
            //var currPosition = head.next;

            //while(currPosition != null)
            //{
            //    if (position == positionFromTail)
            //        return currPosition.data;

            //    position--;
            //    currPosition = currPosition.next;
            //}

            return 0;
        }

        public static int[] cellCompete(int[] states, int days)
        {
            for (int i = 1; i <= days; i++)
            {
                int[] result = new int[states.Length];
                for (int cellIndex = 0; cellIndex < states.Length; cellIndex++)
                {
                    // if first cell, 0 value is assumed. Otherwise we get the previous cell value
                    var left = cellIndex == 0 ? 0 : states[cellIndex - 1];

                    // if last cell, 0 value is assumed. Otherwise we get the nexr cell value
                    var right = cellIndex == states.Length -1 ? 0 : states[cellIndex + 1];

                    result[cellIndex] = left == right ? 0 : 1;
                }
                states = result;
            }

            return states;
        }

        public static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 != null && head2 == null) return false;
            if (head1 == null && head2 != null) return false;
            if (head1 == null && head2 == null) return false;

            while (head1 != null || head2 != null)
            {
                if (head1 != null && head2 == null) return false;
                if (head1 == null && head2 != null) return false;

                if (head1.data != head2.data)
                    return false;

                head1 = head1.next;
                head2 = head2.next;
            }

            return true;
        }

        public static int HeightOfBST(Node node)
        {
            if (node == null)
                return 0;

            var leftHeight = HeightOfBST(node.Left);
            var rightHeight = HeightOfBST(node.Right);

            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }
    }
}
