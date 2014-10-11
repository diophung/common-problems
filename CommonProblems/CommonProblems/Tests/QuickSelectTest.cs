using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class QuickSelectTest
	{
		[TestMethod]
		public void TestQuickSelectFindNthSmallestAlgo()
		{
			int[] list = { 3, 1, 2, 4, 8, 7, 5, 6 };
			QuickSelectAlgo quickSelect = new QuickSelectAlgo();

			Assert.IsTrue(quickSelect.FindNthSmallest(list, 0, list.Length - 1, 2) == 3);
			Assert.IsTrue(quickSelect.FindNthSmallest(list, 0, list.Length - 1, 7) == 8);
			Assert.IsTrue(quickSelect.FindNthSmallest(list, 0, list.Length - 1, 0) == 1);
			Assert.IsTrue(quickSelect.FindNthSmallest(list, 0, list.Length - 1, -1) == 1);
			Assert.IsTrue(quickSelect.FindNthSmallest(list, 0, list.Length - 1, 9) == 8);
		}
	}
}
