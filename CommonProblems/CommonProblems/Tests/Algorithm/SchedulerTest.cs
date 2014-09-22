using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.DynamicProgramming;
using CommonProblems.Algorithm.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm
{
	[TestClass]
	public class SchedulerTest
	{

		[TestMethod]
		public void TestSchedulingWithOverlap()
		{
			var i1 = new Event(1,6);
			var i2 = new Event(6, 10);
			var i3 = new Event(1, 10);
			var i4 = new Event(3, 4);
			var i5 = new Event(2, 12);
			var i6 = new Event(8, 12);
			var i7 = new Event(6, 12);
			Assert.IsFalse(i1.IsOverlap(i2)); //not overlap left
			Assert.IsTrue(i1.IsOverlap(i4)); //superset
			Assert.IsTrue(i4.IsOverlap(i3)); //subset
			Assert.IsTrue(i5.IsOverlap(i6)); //overlap right
			Assert.IsTrue(i2.IsOverlap(i7)); //same start
			Assert.IsTrue(i6.IsOverlap(i7)); //same end
			List<Event> list = new List<Event>();

			list.Add(i1);
			list.Add(i2);
			list.Add(i3);

			Assert.IsTrue(list.ContainsOverlapped());

			var list2 = new List<Event>();
			list2.Add(i1);
			list2.Add(i2);
			Assert.IsFalse(list2.ContainsOverlapped());
		}
	}
}
