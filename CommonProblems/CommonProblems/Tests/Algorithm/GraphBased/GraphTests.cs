using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.GraphBased;
using CommonProblems.DataStructure.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm.GraphBased {
	[TestClass]
	public class GraphTests {
		[TestMethod]
		public void TestTraverseTreeByLevel() {
			TreeNode root = new TreeNode(1);
			TreeNode n2 = new TreeNode(2);
			TreeNode n3 = new TreeNode(3);
			TreeNode n4 = new TreeNode(4);
			TreeNode n5 = new TreeNode(5);
			TreeNode n6 = new TreeNode(6);


			n2.Children.Add(n4);
			n3.Children.Add(n5);
			n3.Children.Add(n6);
			root.Children.Add(n2);
			root.Children.Add(n3);

			/* Expect output:
					  1
					/  \
					2  3
				   /   /\
				  4   5  6
			*/
			BFS.PrintTreeByLevel(root);
		}
	}
}
