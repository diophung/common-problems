using CommonProblems.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonProblems.Tests
{
	[TestClass]
	public class MergeIntervalTests
	{
		[TestMethod]
		public void TestOverlap()
		{
			int c = 0;
			MergeIntervals impl = new MergeIntervals();
			impl.Add(1, 3);
			impl.Add(5, 6);
			c = impl.Compute();
			Assert.AreEqual(3, c);
			impl.Add(2, 9);
			impl.Add(10, 20);
			c = impl.Compute();
			Assert.AreEqual(18, c);

			impl.Add(9, 10);
			c = impl.Compute();
			Console.WriteLine("TestOverlap:{0}", impl.Compute());
			Assert.AreEqual(19, c);
		}

		[TestMethod]
		public void TestNoOverlap()
		{
			MergeIntervals impl = new MergeIntervals();
			impl.Add(1, 3);
			impl.Add(5, 6);
			impl.Add(7, 9);
			impl.Add(10, 20);

			int c = impl.Compute();
			Console.WriteLine("TestNoOverlap:{0}", impl.Compute());
			Assert.AreEqual(15, c);
		}

		[TestMethod]
		public void TestTotalOverlap()
		{
			MergeIntervals impl = new MergeIntervals();
			impl.Add(1, 9);
			impl.Add(5, 6);
			impl.Add(2, 9);
			impl.Add(4, 9);

			int c = impl.Compute();
			Console.WriteLine("TestTotalOverlap:{0}", impl.Compute());
			Assert.AreEqual(8, c);
		}

		[TestMethod]
		public void TestRandom()
		{
			MergeIntervals impl = new MergeIntervals();
			impl.Add(1, 3);
			impl.Add(2, 6);
			impl.Add(8, 9);

			int c = impl.Compute();
			Console.WriteLine("TestTotalOverlap:{0}", impl.Compute());
			Assert.AreEqual(6, c);
		}
	}
}