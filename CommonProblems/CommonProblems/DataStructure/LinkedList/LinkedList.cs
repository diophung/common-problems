using System.Collections.Generic;

namespace CommonProblems.DataStructure.LinkedList
{
	public class LinkedList
	{
		public LinkedList()
		{
			nodes = new List<DoubleLinkedList>();
		}


		public IList<DoubleLinkedList> nodes { get; set; }
	}
}