using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public class RecursionTest
	{
		[TestMethod]
		public void TestStringReversve()
		{
			string s = "abc";
			string reversed = Recursion.ReverseString(s);

			Assert.IsTrue(reversed == "cba");


			string s2 = "1234abcd";
			string rev2 = Recursion.ReverseString(s2);
			Assert.IsTrue(rev2 == "dcba4321");


			string s3 = "";
			Assert.IsTrue(Recursion.ReverseString(s3) == "");

			string s4 = "a";
			Assert.IsTrue(Recursion.ReverseString(s4) == "a");

			
		}
	}
}
