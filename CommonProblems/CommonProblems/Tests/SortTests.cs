using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.Sorting;
using CommonProblems.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonProblems.Algorithm;

namespace CommonProblems.Tests
{

	[TestClass]
	public class SortTests
	{
		private int[] _arr = new int[] { 3, 5, 6, 7, 2, 2, 19, 43, 28 };

		private int[] _sortedArr = new int[] { 2, 2, 3, 5, 6, 7, 19, 28, 43 };


		[TestMethod]
		public void TestSortAlgos()
		{

			SortAlgo sortAlgo = new SortAlgo();
			var bubbleSorted = sortAlgo.BubleSort(_arr);
			Assert.IsTrue(_sortedArr.ElementEquals(bubbleSorted));

			var insertionSort = sortAlgo.InsertionSort(_arr);
			Assert.IsTrue(_sortedArr.ElementEquals(insertionSort));

			var clone = new int[] { 3, 5, 6, 7, 2, 2, 19, 43, 28 };
			sortAlgo.QuickSort(clone, 0, _arr.Length - 1);
			Assert.IsTrue(clone.ElementEquals(_sortedArr));

			var quickSortClone = new int[] { 3, 5, 6, 7, 2, 2, 19, 43, 28 };
			sortAlgo.MergeSort(quickSortClone, 0, quickSortClone.Length - 1);
			Assert.IsTrue(quickSortClone.ElementEquals(_sortedArr));
		}
	}
}
