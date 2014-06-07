using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseDataStructure;
using CommonProblems.Graph;
namespace CommonProblems.Algorithm
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
				if (r.NodeValue == valueToSearch) 
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
	}
}
