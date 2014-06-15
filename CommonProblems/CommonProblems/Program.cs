using System.ComponentModel.Design.Serialization;
using System.Management.Instrumentation;
using CommonProblems.Algorithm;
using CommonProblems.BaseDataStructure;
using CommonProblems.Graph;
using CommonProblems.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems
{
	public class Program
	{
		public static void Main(string[] args)
		{
			EfficientPower();

			TreeBasedAlgo();

			BinarySearchTreeAlgo();

			SortAlgos();

			Console.ReadLine();
		}

		/// <summary>
		/// Faster way to pow()
		/// </summary>
		public static void EfficientPower()
		{
			var ep = new EfficientPower();
			var timer = new Stopwatch();

			int c = 0;
			var r = (Int64)Math.Pow(2, 10);
			var rand = new Random();
			for (int i = 0; i < r; i++)
			{
				//Normal
				timer.Reset();
				int x = rand.Next();
				int toPower = rand.Next();
				timer.Start();
				ep.NormalPowerMethod(x, toPower);
				timer.Stop();
				long normalPowerTime = timer.ElapsedTicks;


				//Efficient
				timer.Start();
				timer.Reset();
				ep.EfficientPowerMethod(x, toPower);
				timer.Stop();
				long efficientPowerTime = timer.ElapsedTicks;

				if (efficientPowerTime > normalPowerTime)
				{
					c++;
				}
			}

			Console.WriteLine(Math.Pow(-2, -1.2));
			Console.WriteLine("Run test : " + r + " times");
			Console.WriteLine("EfficientPower slower than NormalPower: " + c + " times");
			Console.WriteLine("Probable reasons being: 1) Math.Pow() impl include several checkings - which incur overheads");
			Console.WriteLine("MSDN: Math.Pow() - http://msdn.microsoft.com/en-us/library/system.math.pow(v=vs.110).aspx");
			Console.WriteLine("MSDN: Math.Exp() - http://msdn.microsoft.com/en-us/library/system.math.exp.aspx");
			Console.WriteLine("2) The Math.Pow() underlying impl uses a slow method compare to Math.Exp()");

			//Console.ReadLine();
		}

		/// <summary>
		/// DFS, BFS and traverse
		/// </summary>
		public static void TreeBasedAlgo()
		{
			Tree t = new Tree();
			t.Root = new TreeNode { Id = 1, NodeName = "root", NodeValue = 1 };
			TreeNode n2 = new TreeNode { Id = 2, NodeName = "2", NodeValue = 2 };
			TreeNode n3 = new TreeNode { Id = 3, NodeName = "3", NodeValue = 3 };
			TreeNode n4 = new TreeNode { Id = 4, NodeName = "4", NodeValue = 4 };



			TreeNode n5 = new TreeNode { Id = 5, NodeName = "5", NodeValue = 8 };
			TreeNode n6 = new TreeNode { Id = 6, NodeName = "6", NodeValue = 9 };
			TreeNode n7 = new TreeNode { Id = 7, NodeName = "7", NodeValue = 8 };

			TreeNode n8 = new TreeNode { Id = 8, NodeName = "8", NodeValue = 2 };
			TreeNode n9 = new TreeNode { Id = 9, NodeName = "9", NodeValue = 3 };
			TreeNode n10 = new TreeNode { Id = 10, NodeName = "10", NodeValue = 4 };


			n6.Children.Add(n8);
			n7.Children.Add(n9);
			n7.Children.Add(n10);

			n2.Children.Add(n5);
			n3.Children.Add(n6);
			n4.Children.Add(n7);

			t.Root.Children.Add(n2);
			t.Root.Children.Add(n3);
			t.Root.Children.Add(n4);

			var bfsAlgo = new BFS();
			var dfsAlgo = new DFS();
			var bfsNode = bfsAlgo.Search(t, 2);
			var dfsNode = dfsAlgo.RecursiveSearch(t.Root, 4);

			if (bfsNode != null)
				Console.WriteLine("BFS:{0} - name:{1} - value:{2}", bfsNode.Id, bfsNode.NodeName, bfsNode.NodeValue);
			else
				Console.WriteLine("BFS: 8 not found");

			if (dfsNode != null)
				Console.WriteLine("DFS:{0} - name:{1} - value:{2}", dfsNode.Id, dfsNode.NodeName, dfsNode.NodeValue);
			else
				Console.WriteLine("DFS: 2 not found");

			Console.WriteLine("DFS traverse");
			dfsAlgo.RecursiveTraverse(t, t.Root);

			Console.WriteLine("BFS traverse");
			bfsAlgo.RecursiveTraverse(t, t.Root);

			//Console.ReadLine();
		}

		public static void BinarySearchTreeAlgo()
		{
			BinaryTreeNode n0 = new BinaryTreeNode { Id = 0, NodeName = "0", NodeValue = 0 };
			BinaryTreeNode n1 = new BinaryTreeNode { Id = 1, NodeName = "1", NodeValue = 1 };
			BinaryTreeNode n2 = new BinaryTreeNode { Id = 2, NodeName = "2", NodeValue = 2 };
			BinaryTreeNode n3 = new BinaryTreeNode { Id = 3, NodeName = "3", NodeValue = 3 };
			BinaryTreeNode n4 = new BinaryTreeNode { Id = 4, NodeName = "4", NodeValue = 4 };
			BinaryTreeNode n5 = new BinaryTreeNode { Id = 5, NodeName = "5", NodeValue = 5 };
			BinaryTreeNode n6 = new BinaryTreeNode { Id = 6, NodeName = "6", NodeValue = 6 };

			n1.LeftNode = n0;
			n1.RightNode = n2;
			n1.Children.Add(n0);
			n1.Children.Add(n2);

			n4.LeftNode = n3;
			n4.RightNode = n5;
			n4.Children.Add(n3);
			n4.Children.Add(n5);

			n5.RightNode = n6;
			n5.Children.Add(n6);

			BinaryTreeNode root = new BinaryTreeNode { Id = 99, NodeName = "root", NodeValue = 3 };
			root.LeftNode = n1;
			root.RightNode = n4;
			root.Children.Add(n1);
			root.Children.Add(n4);
			BinaryTree tree = new BinaryTree();
			tree.BinaryRoot = root;

			//Traverse 
			DFS dfs = new DFS();
			Console.WriteLine("Traversing BinaryTree");
			dfs.RecursiveTraverse(tree, tree.BinaryRoot);

			//BST
			BST bst = new BST();
			var nodeFound = bst.BinaryTreeSearchAlgo(tree.BinaryRoot, 5);

			if (nodeFound != null) Console.WriteLine("ID:{0} - value = {1}", nodeFound.Id, nodeFound.NodeValue);
			else Console.WriteLine("Not found");
		}

		public static void SortAlgos()
		{
			Console.WriteLine("\nInsertionSort");
			int[] A = { 3, 5, 6, 7, 2, 2, 4, 5, 6, 19, 34, 28, 43 };
			SortAlgo sortAlgo = new SortAlgo();

			A = new int[]{ 3, 5, 6, 7, 2, 2, 4, 5, 6, 19, 34, 28, 43 };
			foreach (var i in sortAlgo.InsertionSort(A)) {
				Console.Write("{0}\t", i);
			}
			Console.WriteLine("\nBubbleSort");
			A = new int[] { 3, 5, 6, 7, 2, 2, 4, 5, 6, 19, 34, 28, 43 };
			foreach (var i in sortAlgo.BubleSort(A)) {
				Console.Write("{0}\t", i);
			}

			A = new int[] { 3, 5, 6, 7, 2, 2, 4, 5, 6, 19, 34, 28, 43 };
			sortAlgo.QuickSort(A,0,A.Length-1);
			Console.WriteLine("\nQuickSort");
			foreach (var i in A)
			{
				Console.Write("{0}\t", i);
			}
		}
	}
}
