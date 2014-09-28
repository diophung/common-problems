using System.Collections.Generic;
using System.Linq;

namespace CommonProblems.Algorithm.Sorting
{
	public static class StackAlgo
	{

		//Problem: Sort a stack into descending order (using another stack)
		public static Stack<int> SortStack(Stack<int> unsorted)
		{
			if (unsorted == null ) return new Stack<int>();

			Stack<int> sorted = new Stack<int>();

			while (unsorted.Any())
			{
				int temp = unsorted.Pop();

				//doing bubble sort: swap the top of each stack
				while (sorted.Any() && sorted.Peek() > temp)
				{
					unsorted.Push(sorted.Pop());
				}
				sorted.Push(temp);
			}

			return sorted;
		}

		/// <summary>
		/// Check if a stack sorted in ascending order
		/// </summary>
		/// <param name="stack"></param>
		/// <returns></returns>
		public static bool IsStackSorted(Stack<int> stack)
		{

			if (stack == null || stack.Count == 0 || stack.Count == 1) return true;

			IList<int> sortedList = new List<int>();
			foreach (int i in stack)
			{
				sortedList.Add(i);
			}

			var sortedArr = sortedList.ToArray();
			for (int i = 0; i < sortedArr.Length - 1; i++)
			{
				if (sortedArr[i] < sortedArr[i + 1])
				{
					return false;
				}
			}

			return true;
		}
	}
}