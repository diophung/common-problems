using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm
{
	class SortAlgo
	{
		public int[] BubleSort(int[] A)
		{
			for (int i = 0; i < A.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					//if the next smaller than the previous, bubble them
					if (A[i] < A[j])
					{
						var x = A[j];
						A[j] = A[i];
						A[i] = x;
					}
				}
			}
			return A;
		}

		public int[] InsertionSort(int[] A)
		{
			for (int i = 1; i < A.Length; i++)
			{
				int j = i;
				while (j > 0 && A[j - 1] > A[j])
				{
					//swap A[j] with A[j-1]
					var x = A[j];
					A[j] = A[j - 1];
					A[j - 1] = x;
					j--;
				}

			}
			return A;
		}


		public void QuickSort(int[] A, int lo, int hi)
		{
			if (lo < hi)
			{
				int pivot = Partition(A,lo,hi);
				QuickSort(A, lo, pivot - 1);
				QuickSort(A, pivot + 1, hi);
			}
		}
		void Swap(int[] array, int srcIndex, int dstIndex)
		{
			int temp = array[dstIndex];
			array[dstIndex] = array[srcIndex];
			array[srcIndex] = temp;
		}

		/// <summary>
		/// Partion an array, and sort it, then return the index of the pivot
		/// </summary>
		/// <param name="A"></param>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		private int Partition(int[] A, int left, int right)
		{
			int pivotIndex = (left + right) / 2; //choose the middle as pivot, in general it's best for performance
			int pivotValue = A[pivotIndex];
			int storedIndex = left;

			Swap(A, pivotIndex, right); //swap pivotIndex with right, avoid interfering with sorting
			int storeIndex = left;
			for (int i = left; i <= right - 1; i++)
			{
				if (A[i] <= pivotValue)
				{
					Swap(A, i, storedIndex); //move the smaller to the left
					storedIndex++;
				}
			}

			Swap(A, storedIndex, right); //move pivot to its final place.
			return storedIndex;
		}
	}

}

