using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class TestUniqueCharacterAlgo
	{
		UniqueCharacter _algo { get; set; }
		public TestUniqueCharacterAlgo()
		{
			_algo = new UniqueCharacter();
		}
		[TestMethod]
		public void TestNullOrEmptyString()
		{
			string toTest = "";
			Assert.IsFalse(_algo.IsUnique(toTest));
			Assert.IsFalse(_algo.IsUnique(string.Empty));
			Assert.IsFalse(_algo.IsUnique(null));
		}

		[TestMethod]
		public void TestNormalString()
		{
			string toTest = "abc";
			Assert.IsTrue(_algo.IsUnique(toTest));
		}
		[TestMethod]
		public void TestDuplicateString()
		{
			string s = " a a b c";
			Assert.IsFalse(_algo.IsUnique(s));
		}
		[TestMethod]
		public void TestNonMatch()
		{
			string s = "1 2 3 a b c d e";
			Assert.IsFalse(_algo.IsUnique(s));
		}
	}
}
