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
	public class TreeTraverseTest {

		[TestMethod]
		public void TestTreeTraverse() {
			/*
			 
			  1
			 / \
			 2  3
			/ \  \
		    4  5  6
		
			*/
			BinaryTreeNode root = new BinaryTreeNode(1);
			BinaryTreeNode n2 = new BinaryTreeNode(2);
			BinaryTreeNode n3 = new BinaryTreeNode(3);
			BinaryTreeNode n4 = new BinaryTreeNode(4);
			BinaryTreeNode n5 = new BinaryTreeNode(5);
			BinaryTreeNode n6 = new BinaryTreeNode(6);

			n2.LeftNode = n4;
			n2.RightNode = n5;
			n3.RightNode = n6;
			root.LeftNode = n2;
			root.RightNode = n3;

			string inOrder = TreeTraverse.InOrder(root);
			string postOrder = TreeTraverse.PostOrder(root);
			string preOrder = TreeTraverse.PreOrder(root);

			Assert.IsTrue(inOrder == "425136");
			Assert.IsTrue(postOrder == "452631");
			Assert.IsTrue(preOrder == "124536");
		}
	}
}
