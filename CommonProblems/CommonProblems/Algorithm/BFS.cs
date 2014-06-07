using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseDataStructure;
using CommonProblems.Graph;

namespace CommonProblems.Algorithm
{
	public class BFS
	{
		public TreeNode Search(Tree searchInTree, double valueToSearch)
		{
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

			while (queue.Count != 0)
			{
				var n = queue.Dequeue();
				if (n.NodeValue == valueToSearch) return n;


				foreach (var child in n.Children)
				{
					//if this node is not yet visited
					if (!visitedNodes.Any(x => x.NodeValue == child.NodeValue))
					{
						//BFS algo: mark children as visited
						visitedNodes.Add(child);

						//start scaning - BFS
						queue.Enqueue(child);
					}
				}
			}

			return null;//not found
		}
	}
}
