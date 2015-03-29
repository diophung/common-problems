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
		/// Problem: given a knapsack with weight capacity W, <br></br>
		/// a list of items N, each item has a weight of w, a value of n.<br></br>
		/// Find a solution that fill the knapsack with items contains maximal value.
		/// </summary>
		/// <param name="maxN">maximum number of items</param>
		/// <param name="maxW">knapsack maximum weight</param>
		public void SolveKnapsack(int maxN, int maxW) {
			Console.WriteLine("*****************");
			Console.WriteLine("Given the list of these [{0}] items, try to pick most valueable items." +
							  "\nKnapsack max weight =[{1}]", maxN, maxW);
			Console.WriteLine("*****************");
			
			//N: number of items
			//W: maximum weight of knapsack
			int[] profit = new int[maxN + 1];
			int[] weight = new int[maxN + 1];
			Random r = new Random();
			for (int n = 1; n <= maxN; n++) {
				profit[n] = r.Next(1000);
				weight[n] = r.Next(0, 2 * maxW);
			}

			// optimization[n][w] = max profit of packing items 1..n with weight limit w
			// selection[n][w] = does opt solution to pack items 1..n with weight limit w include item n?
			int[,] optimization = new int[maxN + 1, maxW + 1];
			bool[,] selection = new bool[maxN + 1, maxW + 1];

			for (int n = 1; n <= maxN; n++) {
				for (int w = 1; w <= maxW; w++) {
					// don't take item n
					int option1 = optimization[n - 1, w];

					// take item n
					int option2 = int.MinValue;
					if (weight[n] <= w) {
						option2 = profit[n] + optimization[n - 1, w - weight[n]];
					}

					// select better of two options
					optimization[n, w] = Math.Max(option1, option2); //optimize value
					selection[n, w] = (option2 > option1); //if pick, set to true.
				}
			}

			// determine which items to take
			// bottom-up approach: get the profit at each item, expanding to the whole knapsack
			bool[] take = new bool[maxN + 1];
			for (int n = maxN, w = maxW; n > 0; n--) {
				if (selection[n, w]) {
					take[n] = true;
					w = w - weight[n];
				}
				else {
					take[n] = false;
				}
			}

			// print results
			Console.WriteLine("item" + "\t\t" + "profit" + "\t\t" + "weight" + "\t\t" + "take");
			for (int n = 1; n <= maxN; n++) {
				Console.WriteLine(n + "\t\t" + profit[n] + "\t\t" + weight[n] + "\t\t" + take[n]);
			}
		}
	}
}
