using System.Collections.Generic;

namespace CommonProblems.DataStructure.Graphs
{
	public class BinaryTree : Tree
	{
		public BinaryTreeNode BinaryRoot { get; set; }

		public BinaryTreeNode LeftChild { get; set; }

		public BinaryTreeNode RightChild { get; set; }

		private IList<BinaryTreeNode> _children;

		public IList<BinaryTreeNode> BinaryChildren
		{
			get { return _children ?? (_children = new List<BinaryTreeNode>()); }

			set { _children = value; }
		}
	}
}
