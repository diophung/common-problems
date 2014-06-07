using System.Collections.Generic;
using System.Linq;
using CommonProblems.Graph;

namespace CommonProblems.BaseDataStructure
{
	public class TreeNode : Vertex
	{
		private IList<TreeNode> _children;
		public IList<TreeNode> Children
		{
			get
			{
				if (_children == null || !_children.Any())
				{
					_children = new List<TreeNode>();
				}
				return _children;
			}
			set
			{
				_children = value;
			}
		}

		public override bool Equals(object obj)
		{
			TreeNode t = (TreeNode)obj;
			return (t.Id == this.Id);
		}
	}
}
