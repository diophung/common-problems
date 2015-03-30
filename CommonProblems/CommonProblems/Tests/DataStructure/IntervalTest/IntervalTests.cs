using System.Collections.Generic;
using CommonProblems.DataStructure.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interval = CommonProblems.DataStructure.Intervals.Interval;
namespace CommonProblems.Tests.DataStructure.IntervalTest
{
	[TestClass]
	public class IntervalTests
	{
		[TestMethod()]
		public void TestOverlappingIntervals()
		{
			List<Interval> list = new List<Interval>
			{
				new Interval(1, 3), 
				new Interval(9, 16), 
				new Interval(2, 5)
			};

			bool b = CheckOverlappingIntervals.HasConflictOpt(list);
			bool b2 = CheckOverlappingIntervals.HasConflict(list);
			Assert.IsTrue(b);
			Assert.IsTrue(b2);
		}
	}
}
