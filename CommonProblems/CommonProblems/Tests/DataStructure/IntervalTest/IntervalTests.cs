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
			List<Interval> hasConflicts = new List<Interval>
			{
				new Interval(1, 3), 
				new Interval(9, 16), 
				new Interval(2, 5)
			};

			List<Interval> noConflict = new List<Interval>
			{
				new Interval(1, 2),
				new Interval(3, 4),
				new Interval(4, 5)
			};
			Assert.IsTrue(CheckOverlappingIntervals.HasConflictOpt(hasConflicts));
			Assert.IsTrue(CheckOverlappingIntervals.HasConflict(hasConflicts));

			Assert.IsFalse(CheckOverlappingIntervals.HasConflictOpt(noConflict));
			Assert.IsFalse(CheckOverlappingIntervals.HasConflictOpt(noConflict));
		}
	}
}
