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
			string reversed = CommonRecursion.ReverseString(s);

			Assert.IsTrue(reversed == "cba");


			string s2 = "1234abcd";
			string rev2 = CommonRecursion.ReverseString(s2);
			Assert.IsTrue(rev2 == "dcba4321");


			string s3 = "";
			Assert.IsTrue(CommonRecursion.ReverseString(s3) == "");

			string s4 = "a";
			Assert.IsTrue(CommonRecursion.ReverseString(s4) == "a");

			
		}

		[TestMethod]
		public void TestFibonacci()
		{
			//1,1,2,3,5,8,13,21,34,55
			int f1 = CommonRecursion.Fibonacci(1);
			int f2 = CommonRecursion.Fibonacci(2);
			Assert.IsTrue(f1 == 1);
			Assert.IsTrue(f2 == 1);

			int f4 = CommonRecursion.Fibonacci(4);
			Assert.IsTrue(f4==3);
			int f10 = CommonRecursion.Fibonacci(10);
			Assert.IsTrue(f10 == 55);

		}
	}
}
