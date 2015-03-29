using CommonProblems.Helper;
using NUnit.Framework;

namespace CommonProblems.Tests.Helper
{
	[TestFixture]
	public class StringExtensionTests
	{
		[TestCase(null, null)]
		[TestCase("", "")]
		[TestCase("a", "A")]
		[TestCase("A", "a")]
		[TestCase("AAA", "aaa")]
		[TestCase("1", "1" + "")]
		public void EqualIgnoreCasePositiveTests(string actual, string expected)
		{
			Assert.IsTrue(actual.EqualsIgnoreCase(expected));
		}

		[TestCase("null", null)]
		[TestCase("", null)]
		[TestCase(null, "")]
		[TestCase("1", null)]
		[TestCase("", "null")]
		public void EqualIgnoreCaseNegativeTests(string actual, string expected)
		{
			Assert.IsFalse(actual.EqualsIgnoreCase(expected));
			
		}
	}
}