using System;
using System.Collections.Generic;
using System.Linq;
using CommonProblems.DataStructure.Graphs;

namespace CommonProblems.Algorithm.GraphBased
{
	/// <summary>
	/// DFS Algo: traverse/search within all children first, before expand to siblings.
	/// </summary>
	public class DFS
	{
		public TreeNode RecursiveSearch(TreeNode startNode, double valueToSearch)
		{
			if (startNode.NodeValue == valueToSearch)
			{
				return startNode;
			}

			if (!startNode.Children.Any())
			{
				return null; //not found
			}

			foreach (var child in startNode.Children)
			{
				var r = RecursiveSearch(child, valueToSearch);
				if (r!=null && r.NodeValue == valueToSearch) 
					return r;
			}
			return null;
		}

		public void RecursiveTraverse(Tree treeToTraverse, TreeNode startNode)
		{
			List<TreeNode> visitedNodes = new List<TreeNode>();
			visitedNodes.Add(startNode);
			Console.WriteLine("{0}", startNode.Id);

			foreach (var child in startNode.Children)
			{
				if (!visitedNodes.Any(x => x.Equals(child)))
				{
					visitedNodes.Add(child);
					RecursiveTraverse(treeToTraverse, child);
				}
			}
		}
		public void NonRecursiveDfs(Tree treeToTraverse, TreeNode startNode)
		{
			
			/*procedure DFS-iterative(G,v):
		2      let S be a stack
		3      S.push(v)
		4      while S is not empty
		5            v ← S.pop() 
		6            if v is not labeled as discovered:
		7                label v as discovered
		8                for all edges from v to w in G.adjacentEdges(v) do
		9                    S.push(w)*/

			List<TreeNode> visitedNodes = new List<TreeNode>();
			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(startNode);
			visitedNodes.Add(startNode);
			while (stack.Count > 0)
			{
				TreeNode n = stack.Pop();
				if (!visitedNodes.Contains(n))
				{
					visitedNodes.Add(n);
					foreach (var child in n.Children)
					{
						stack.Push(child);
					}
				}
			}
		}

	
	}
}
