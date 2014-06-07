using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.DataStructure
{
	public class TreeNode:Vertex
	{
		public IList<TreeNode> Children { get; set; }
	}
}
