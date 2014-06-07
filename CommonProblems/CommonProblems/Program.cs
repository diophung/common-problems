using System.ComponentModel.Design.Serialization;
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
			//EfficientPower();
			DfsSearch();
		}

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


			Console.ReadLine();
		}

		public static void DfsSearch()
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

			dfsAlgo.RecursiveTraverse(t, t.Root);
			Console.ReadLine();
		}
	}
}
