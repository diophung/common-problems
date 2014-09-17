using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.DynamicProgramming {
	/// <summary>
	/// Problem: given a knapsack with weight capacity W, a list of items N, each item has a weight of w, a value of n.
	/// Find a solution that fill the knapsack with items contains maximal value.
	/// </summary>
	public class Knapsack {
		/// <summary>
		/// Problem: given a knapsack with weight capacity W, a list of items N, each item has a weight of w, a value of n.
		/// Find a solution that fill the knapsack with items contains maximal value.
		/// </summary>
		/// <param name="N">maximum number of items</param>
		/// <param name="W">knapsack maximum weight</param>
		public void SolveKnapsack(int N, int W) {
			Console.WriteLine("*****************");
			Console.WriteLine("Given the list of these [{0}] items, try to pick most valueable items." +
							  "\nKnapsack max weight =[{1}]", N, W);
			Console.WriteLine("*****************");
			//N: number of items
			//W: maximum weight of knapsack
			int[] profit = new int[N + 1];
			int[] weight = new int[N + 1];
			Random r = new Random();
			// generate random instance, items 1..N
			for (int n = 1; n <= N; n++) {
				profit[n] = r.Next(1000);
				weight[n] = r.Next(0, 2 * W);
			}

			// opt[n][w] = max profit of packing items 1..n with weight limit w
			// sol[n][w] = does opt solution to pack items 1..n with weight limit w include item n?
			int[,] optimization = new int[N + 1, W + 1];
			bool[,] selectionTable = new bool[N + 1, W + 1];

			for (int n = 1; n <= N; n++) {
				for (int w = 1; w <= W; w++) {
					// don't take item n
					int option1 = optimization[n - 1, w];

					// take item n
					int option2 = int.MinValue;
					if (weight[n] <= w) {
						option2 = profit[n] + optimization[n - 1, w - weight[n]];
					}

					// select better of two options
					optimization[n, w] = Math.Max(option1, option2); //optimize value
					selectionTable[n, w] = (option2 > option1); //if pick, set to true.
				}
			}

			// determine which items to take
			// bottom-up approach: start with last items in the list
			bool[] take = new bool[N + 1];
			for (int n = N, w = W; n > 0; n--) {
				if (selectionTable[n, w]) {
					take[n] = true;
					w = w - weight[n];
				}
				else {
					take[n] = false;
				}
			}

			// print results
			Console.WriteLine("item" + "\t\t" + "profit" + "\t\t" + "weight" + "\t\t" + "take");
			for (int n = 1; n <= N; n++) {
				Console.WriteLine(n + "\t\t" + profit[n] + "\t\t" + weight[n] + "\t\t" + take[n]);
			}
		}
	}
}
