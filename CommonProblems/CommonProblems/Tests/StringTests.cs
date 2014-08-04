using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class StringTests
	{
		[TestMethod]
		public void TestEmptyString()
		{
			Assert.IsTrue(string.IsNullOrEmpty(StringAlgo.RemoveDuplicateChar(string.Empty)));
		}

		[TestMethod]
		public void TestRemoveDuplicateString()
		{
			string actual = "aabbc";
			string expected = "abc";

			Assert.IsTrue(StringAlgo.RemoveDuplicateChar(actual).Equals(expected));

			actual = "abcabcaa";
			Assert.IsTrue(StringAlgo.RemoveDuplicateChar(actual).Equals(expected));

			actual = "abc";
			Assert.IsTrue(StringAlgo.RemoveDuplicateChar(actual).Equals(expected));


		}
	}
}
