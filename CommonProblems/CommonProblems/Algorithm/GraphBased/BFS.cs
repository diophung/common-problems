using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CommonProblems.DataStructure.Graphs;
using Debug = System.Diagnostics.Debug;
namespace CommonProblems.Algorithm.GraphBased {
	public class BFS {

		public static void PrintTreeByLevel(TreeNode root) {
			//print the tree by each level
			Queue<TreeNode> nodes = new Queue<TreeNode>();
			nodes.Enqueue(root);
			nodes.Enqueue(new TreeNode(0)); //for new line

			while (nodes.Count > 0) {
				TreeNode n = nodes.Dequeue();
				if (n != null) {
					if (n.Id == 0) 
						Console.Write("\r\n"); //new line
					else
						Console.Write(n.Id + "\t");
				}

				if (n != null && n.Children != null && n.Children.Count > 0) {
					foreach (var c in n.Children) {
						nodes.Enqueue(c);
					}
					nodes.Enqueue(new TreeNode(0));//new lines
				}
			}
		}
		public void NonRecursiveTraverse(Tree treeToTraverse, TreeNode startWithNode) {
			Queue<TreeNode> queue = new Queue<TreeNode>();
			IList<TreeNode> visitedNodes = new List<TreeNode>();
			TreeNode root = treeToTraverse.Root;
			queue.Enqueue(root); //start checking root

			while (queue.Count != 0) {
				var n = queue.Dequeue();
				Console.WriteLine("{0}", n.Id);

				foreach (var child in n.Children) {
					if (!visitedNodes.Any(x => x.Equals(child))) {
						visitedNodes.Add(child);
						queue.Enqueue(child);
					}
				}
			}
		}
		public TreeNode Search(Tree searchInTree, double valueToSearch) {
			/*
				1. Enqueue the root node
				2. Dequeue a node and examine it
					- If the element sought is found in this node, quit the search and return a result.
					- Otherwise enqueue any successors (the direct child nodes) that have not yet been discovered.
				3. If the queue is empty, every node on the graph has been examined – quit the search and return "not found".
				4. If the queue is not empty, repeat from Step 2.
			 */

			Queue<TreeNode> queue = new Queue<TreeNode>();
			IList<TreeNode> visitedNodes = new List<TreeNode>();

			TreeNode root = searchInTree.Root;
			queue.Enqueue(root); //start checking root

			while (queue.Count != 0) {
				var n = queue.Dequeue();
				if (Math.Abs(n.NodeValue - valueToSearch) < TOLERANCE) return n;
				foreach (var child in n.Children) {
					if (!visitedNodes.Any(x => x.NodeValue == child.NodeValue)) {
						visitedNodes.Add(child);

						queue.Enqueue(child);
					}
				}
			}

			return null;//not found
		}

		const double TOLERANCE = 0.00000001;
	}
}
