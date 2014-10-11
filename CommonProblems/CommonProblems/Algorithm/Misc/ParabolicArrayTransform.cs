using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.Sorting;
using CommonProblems.DataStructure.LinkedList;

namespace CommonProblems.Algorithm.Misc {
	public static class ParabolicArrayTransform {
		//problem: given a int[] in sorted ascending order, 
		//output the int[] where x' = A*x^2 + B*x + C, also in sorted ascending order
		//To be achieved in O(n)
		public static int[] MapArrayFn(int[] input, int A, int B, int C) {
			int[] mapped = new int[input.Length];

			for (int i = 0; i < input.Length; i++) {
				mapped[i] = MapFunction(input[i], A, B, C);
			}

			var sortAlgo = new SortAlgo();
			sortAlgo.QuickSort(mapped,0, mapped.Length - 1);

			return mapped;
		}

		static int MapFunction(int x, int A, int B, int C) {
			return A * x * x + B * x + C;
		}
	}
}
