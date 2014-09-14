using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseStruct;
using CommonProblems.Graph;

namespace CommonProblems.Algorithm
{
	public class BST
	{
		public BinaryTreeNode BinaryTreeSearchAlgo(BinaryTreeNode bt, double value)
		{
			BinaryTreeNode current = bt;

			if (current != null && current.NodeValue == value) 
				return current;

			if (bt == null || (bt.LeftNode == null && bt.RightNode == null)) 
				return null;

			if (current != null && value <= current.NodeValue) return BinaryTreeSearchAlgo(bt.LeftNode, value);

			else return BinaryTreeSearchAlgo(bt.RightNode, value);
		}
	}
}
