using System.Collections.Generic;

namespace CommonProblems.DataStructure.LinkedList
{
	public class LinkedList
	{
		public LinkedList()
		{
			Nodes = new List<DoubleLinkedList>();
		}


		public IList<DoubleLinkedList> Nodes { get; set; }
	}
}