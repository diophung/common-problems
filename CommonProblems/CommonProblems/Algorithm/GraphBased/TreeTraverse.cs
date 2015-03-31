using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.DataStructure.Graphs;

namespace CommonProblems.Algorithm.GraphBased {
	public static class TreeTraverse {
		public static string InOrder(BinaryTreeNode root)
		{
			//Left -> root -> Right
			string path = "";
			if (root == null)
				return "";

			path+=InOrder(root.LeftNode);
			path += root.Id;
			path+=InOrder(root.RightNode);

			return path;
		}

		public static string PreOrder(BinaryTreeNode root) {
			//Root -> Left -> Right
			string path = "";
			if (root == null)
				return "";

			path += root.Id;
			path += PreOrder(root.LeftNode);
			path += PreOrder(root.RightNode);

			return path;
		}

		public static string PostOrder(BinaryTreeNode root) {
			//Left -> Right -> Root
			string path = "";
			if (root == null)
				return "";

			path += PostOrder(root.LeftNode);
			path += InOrder(root.RightNode);
			path += root.Id;

			return path;
		}
	}
}
