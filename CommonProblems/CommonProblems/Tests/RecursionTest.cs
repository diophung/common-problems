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

		[TestMethod]
		public void TestFibonacci()
		{
			//1,1,2,3,5,8,13,21,34,55
			int f1 = Recursion.Fibonacci(1);
			int f2 = Recursion.Fibonacci(2);
			Assert.IsTrue(f1 == 1);
			Assert.IsTrue(f2 == 1);

			int f4 = Recursion.Fibonacci(4);
			Assert.IsTrue(f4==3);
			int f10 = Recursion.Fibonacci(10);
			Assert.IsTrue(f10 == 55);

		}
	}
}
