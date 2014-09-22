using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm
{
	[TestClass]
	public class LongestCommonStringTests
	{
		LongestCommonSequence _lcs;
		public LongestCommonStringTests()
		{
			_lcs = new LongestCommonSequence();
		}
		[TestMethod]
		public void TestLcsOfEmptyString()
		{
			string shouldEmpty = _lcs.GetLongestCommonSequence("", string.Empty);
			Assert.IsTrue(string.IsNullOrEmpty(shouldEmpty));

			string should = _lcs.GetLongestCommonSequence("", "abc");
			Assert.IsTrue(string.IsNullOrEmpty(should));

			string should2 = _lcs.GetLongestCommonSequence("abc123", "abc456abc1");
			Assert.IsTrue(should2.Length == 4);

			string should3 = _lcs.GetLongestCommonSequence("a1b2c3d4", "a1b1c1a2b2c2a3b3c3");
			Assert.IsTrue(should3.Length == 6);
		}
	}
}
