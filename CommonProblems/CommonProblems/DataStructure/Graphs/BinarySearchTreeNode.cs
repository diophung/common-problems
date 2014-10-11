using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.DataStructure.Graphs {
	public class BinarySearchTreeNode {
		public string NodeName { get; set; }

		public int NodeValue { get; set; }
		public BinarySearchTreeNode LeftChild { get; set; }
		public BinarySearchTreeNode RightChild { get; set; }

		public BinarySearchTreeNode(string name, int val, BinarySearchTreeNode left, BinarySearchTreeNode right) {
			LeftChild = left;
			RightChild = right;
			NodeName = name;
			NodeValue = val;
		}
	}
}
