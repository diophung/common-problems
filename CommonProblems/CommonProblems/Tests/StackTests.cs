using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm;
using CommonProblems.Algorithm.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class StackTests
	{
		[TestMethod]
		public void TestUnsortedStackSort()
		{
			Stack<int> unsorted = new Stack<int>();
			unsorted.Push(4);
			unsorted.Push(3);
			unsorted.Push(1);
			unsorted.Push(2);
			Assert.IsFalse(StackAlgo.IsStackSorted(unsorted));

			Assert.IsTrue(StackAlgo.IsStackSorted(StackAlgo.SortStack(unsorted)));
		}

		[TestMethod]
		public void TestStackWhichAlreadySorted()
		{
			Stack<int> presorted = new Stack<int>();

			presorted.Push(1);
			presorted.Push(2);
			presorted.Push(3);
			presorted.Push(4);

			Assert.IsTrue(StackAlgo.IsStackSorted(presorted));
			Assert.IsTrue(StackAlgo.IsStackSorted(StackAlgo.SortStack(presorted)));
		}
		[TestMethod]
		public void TestStackWithIdentical()
		{
			Stack<int> identical = new Stack<int>();
			identical.Push(3);
			identical.Push(1);
			identical.Push(2);

			Assert.IsFalse(StackAlgo.IsStackSorted(identical));
			Assert.IsTrue(StackAlgo.IsStackSorted(StackAlgo.SortStack(identical)));
		}

		[TestMethod]
		public void TestSortEmptyStack()
		{
			Stack<int> emptyOrOnlyOne = new Stack<int>();
			Assert.IsTrue(StackAlgo.IsStackSorted(emptyOrOnlyOne));

			emptyOrOnlyOne.Push(1);
			Assert.IsTrue(StackAlgo.IsStackSorted(emptyOrOnlyOne));
			Assert.IsTrue(StackAlgo.IsStackSorted(StackAlgo.SortStack(emptyOrOnlyOne)));

		}
	}
}
