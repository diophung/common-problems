namespace CommonProblems.DataStructure.LinkedList
{
	public class LinkedListNode {
		public int Data {get;set;}
		public LinkedListNode Next {get;set;}
	
		public LinkedListNode(int d) {
			this.Data = d;
			this.Next = null;
		}
	
		public LinkedListNode(int d, LinkedListNode n ) {
			this.Data = d;
			this.Next = n;
		}
	}
}