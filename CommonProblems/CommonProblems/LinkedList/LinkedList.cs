using System.Collections.Generic;

namespace CommonProblems.LinkedLists
{
	public class LinkedList
	{
		public LinkedList()
		{
			nodes = new List<LinkedListNode>();
		}


		public IList<LinkedListNode> nodes { get; set; }
	}
}