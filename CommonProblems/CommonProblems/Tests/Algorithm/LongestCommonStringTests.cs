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
		LongestCommonString _lcs;
		public LongestCommonStringTests()
		{
			_lcs = new LongestCommonString();
		}
		[TestMethod]
		public void TestLcsOfEmptyString()
		{
			string shouldEmpty = _lcs.GetLongestCommonSubstring("", string.Empty);
			Assert.IsTrue(string.IsNullOrEmpty(shouldEmpty));

			string should = _lcs.GetLongestCommonSubstring("", "abc");
			Assert.IsTrue(string.IsNullOrEmpty(should));

			string should2 = _lcs.GetLongestCommonSubstring("abc123", "abc456abc1");
			Assert.IsTrue(should2.Length == 4);

			string should3 = _lcs.GetLongestCommonSubstring("a1b2c3d4", "a1b1c1a2b2c2a3b3c3");
			Assert.IsTrue(should3.Length == 6);
		}
	}
}
