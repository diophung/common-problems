using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseStruct;

namespace CommonProblems.Graph
{
	public class BinaryTree : Tree
	{
		public BinaryTreeNode BinaryRoot { get; set; }

		private IList<BinaryTreeNode> _children;

		public IList<BinaryTreeNode> BinaryChildren
		{
			get { return _children ?? (_children = new List<BinaryTreeNode>()); }

			set { _children = value; }
		}
	}
}
