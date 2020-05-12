namespace HackerrankChallenges
{
    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode(int data, SinglyLinkedListNode next)
        {
            this.data = data;
            this.next = next;
        }

        public int data { get; set; }
        public SinglyLinkedListNode next { get; set; }    
    }
}
