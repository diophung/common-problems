using System;
using CommonProblems.Algorithm;
using NUnit.Framework;
namespace CommonProblems.Tests.Algorithm.Recursion
{
	[TestFixture]
	public class PermutationTests
	{

		[TestCase("a", 1)]
		[TestCase("", 1)]
		[TestCase("ab", 2)]
		[TestCase("123", 6)]
		[TestCase("22", 2)]
		public void PermutationPositiveTests(string input, int expectedResults)
		{
			var perms = Permutation.Permute(input);
			Console.WriteLine("Permutation of :"+ input);
			foreach (var s in perms)
			{
				Console.WriteLine(s);
			}
			Assert.IsTrue(perms.Count == expectedResults);
		}
	}
}