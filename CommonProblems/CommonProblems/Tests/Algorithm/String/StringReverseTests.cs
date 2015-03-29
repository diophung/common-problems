using System;
using CommonProblems.Algorithm.String;
using CommonProblems.Helper;
using NUnit.Framework;

namespace CommonProblems.Tests.Algorithm.String
{
	[TestFixture]
	public class StringReverseTests
	{
		[TestCase("abc", "cba")]
		[TestCase("", "")]
		[TestCase(null, null)]
		public void StringReversePositiveTests(string actual, string expected)
		{

			StringReverse sv = new StringReverse();
			string result = sv.Reverse(actual);
			Console.WriteLine("{0} ---> {1}", actual, result);
			Assert.IsTrue(result.EqualsIgnoreCase(expected));
		}

		[TestCase("", null)]
		[TestCase(null, "")]
		[TestCase(null, "a")]
		[TestCase("a", null)]
		[TestCase("a", "")]
		[TestCase("", "a")]
		public void StringReverseNegativeTests(string actual, string expected)
		{
			StringReverse sv = new StringReverse();
			string result = sv.Reverse(actual);
			Assert.IsFalse(result.EqualsIgnoreCase(expected));
		}
	}
}