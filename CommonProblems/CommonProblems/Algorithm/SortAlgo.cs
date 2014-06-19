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


		#region Quick Sort
		public void QuickSort(int[] A, int lo, int hi)
		{
			if (lo < hi)
			{
				int pivot = Partition(A, lo, hi);
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
		#endregion

		#region Merge Sort

		//Merge the array
		void DoMerge(int[] numbers, int left, int mid, int right)
		{
			int[] temp = new int[numbers.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1); //end of left portion
			tmp_pos = left; //start location
			num_elements = (right - left + 1); //total elements to process 

			//start moving for both parts
			while ((left <= left_end) && (mid <= right))
			{
				if (numbers[left] <= numbers[mid]) //if left side smaller than right side
					temp[tmp_pos++] = numbers[left++]; //store that number to temp
				else
					temp[tmp_pos++] = numbers[mid++]; //store that number to temp
			}

			//copy those which were not moved in left hand side
			while (left <= left_end)
				temp[tmp_pos++] = numbers[left++];

			//copy those which were not moved in the right hand side
			while (mid <= right)
				temp[tmp_pos++] = numbers[mid++];

			//copy the whole array from temp to the output
			for (i = 0; i < num_elements; i++)
			{
				numbers[right] = temp[right];
				right--;
			}
		}

		public void MergeSort_Recursive(int[] numbers, int left, int right)
		{
			int mid;

			if (right > left)
			{
				mid = (right + left) / 2;
				MergeSort_Recursive(numbers, left, mid);
				MergeSort_Recursive(numbers, (mid + 1), right);

				DoMerge(numbers, left, (mid + 1), right);
			}
		}
		#endregion
	}

}

