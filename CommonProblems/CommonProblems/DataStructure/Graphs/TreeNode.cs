using System.Collections.Generic;
using System.Linq;

namespace CommonProblems.DataStructure.Graphs {
	public class TreeNode : Vertex {
		public TreeNode() {}
		public TreeNode(int id)
			: base(id, "", 0) {

		}

		public TreeNode(int id, string name) : base(id, name, 0)
		{
			
		}
		protected bool Equals(TreeNode other) {
			return Equals(_children, other._children);
		}

		public override int GetHashCode() {
			return (_children != null ? _children.GetHashCode() : 0);
		}

		private IList<TreeNode> _children;
		public IList<TreeNode> Children {
			get {
				if (_children == null || !_children.Any()) {
					_children = new List<TreeNode>();
				}
				return _children;
			}
			set {
				_children = value;
			}
		}

		public override bool Equals(object obj) {
			TreeNode t = (TreeNode)obj;
			return (t.Id == this.Id);
		}
	}
}
