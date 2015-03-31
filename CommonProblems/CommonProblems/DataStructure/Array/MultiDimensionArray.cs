using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.DataStructure.Array {
	public static class MultiDimensionArray {

		static void Print(int[,] map) {
			for (int i = 0; i < map.Length; i++) {
				for (int j = 0; j < map.Rank; j++) {
					Console.WriteLine(map[i, j] + "\t");
				}
			}
		}

		static void FindPath(int[,] map) {
			for (int i = 0; i < map.Length; i++) {
				for (int j = 0; j < map.Rank; j++) {
					Console.WriteLine(map[i, j] + "\t");
				}
			}
		}
	}

	public class Node
	{
		private bool canReachPacific;
		private bool canReachAlantic;
	}
}
