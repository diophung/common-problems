namespace CommonProblems.DataStructure.Graphs {
	public class BinaryTreeNode : TreeNode {
		public BinaryTreeNode(int id) {
			this.Id = id;
		}

		public BinaryTreeNode() { }
		public BinaryTreeNode LeftNode { get; set; }
		public BinaryTreeNode RightNode { get; set; }
	}
}
