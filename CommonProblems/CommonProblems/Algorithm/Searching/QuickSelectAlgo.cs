using System;
using System.Collections.Generic;

namespace CommonProblems.Algorithm.Searching
{
	public class QuickSelectAlgo
	{
		//Problem: find the n-th smallest in a unsorted int array in O(n)
		//n-th is zero-based.
		//Returns the n-th smallest element of list within left..right inclusive (i.e. left <= n <= right).
		public int FindNthSmallest(int[] list, int left, int right, int n)
		{
			if (left == right)
			{
				return list[left];
			}
			//Algorithm: using Quickselect http://en.wikipedia.org/wiki/Quickselect
			//apply the idea of quicksort: break into 2 parts and recursively check
			//for each recursive call, do compare the pivotIndex with the n-th
			int pivotIndex = (left + right) / 2; //select a random pivot to yield linear performance
			pivotIndex = Partition(list, left, right, pivotIndex);

			// The size of the list is not changing with each recursion. Thus, n does not need to be updated with each round.
			if (n == pivotIndex)
				return list[n];
			else if (n < pivotIndex)
				return FindNthSmallest(list, left, pivotIndex - 1, n);
			else
				return FindNthSmallest(list, pivotIndex + 1, right, n);
		}

		int Partition(int[] list, int left, int right, int pivotIndex)
		{
			int pivotValue = list[pivotIndex];
			Swap(list, pivotIndex, right);  // Move pivot value to end
			int storeIndex = left;
			for (int i = left; i < right; i++)
			{
				if (list[i] < pivotValue)
				{
					Swap(list, storeIndex, i);//move to the left
					storeIndex++;
				}
			}
			Swap(list, right, storeIndex);// Move pivot value to its final place
			return storeIndex;
		}

		void Swap(int[] array, int srcIndex, int dstIndex)
		{
			int temp = array[dstIndex];
			array[dstIndex] = array[srcIndex];
			array[srcIndex] = temp;
		}
	}
}