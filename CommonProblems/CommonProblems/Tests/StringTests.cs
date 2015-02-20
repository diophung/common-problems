using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class StringTests
	{
		[TestMethod]
		public void TestEmptyString()
		{
			Assert.IsTrue(string.IsNullOrEmpty(StringRemoveDuplicateChar.RemoveDuplicateChar(string.Empty)));
		}

		[TestMethod]
		public void TestRemoveDuplicateString()
		{
			string actual = "aabbc";
			string expected = "abc";

			Assert.IsTrue(StringRemoveDuplicateChar.RemoveDuplicateChar(actual).Equals(expected));

			actual = "abcabcaa";
			Assert.IsTrue(StringRemoveDuplicateChar.RemoveDuplicateChar(actual).Equals(expected));

			actual = "abc";
			Assert.IsTrue(StringRemoveDuplicateChar.RemoveDuplicateChar(actual).Equals(expected));

		}
		
		[TestMethod]
		public void TestCanBuildWord(){
			char[] chars = {'a','b','c','d','h','a','t'};
			string word = "hat";

			StringCanBuildWords algo = new StringCanBuildWords(chars);
			Assert.IsTrue(algo.CanBuildWord(word));
			Assert.IsFalse(algo.CanBuildWord("hello"));
			Assert.IsTrue(algo.CanBuildWord(string.Empty));

			algo = new StringCanBuildWords(new char[]{});
			Assert.IsFalse(algo.CanBuildWord("a"));
		}
	}
}
