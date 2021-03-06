﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm
{
	[TestClass]
	public class PermutationTest
	{

		[TestMethod]
		public void TestStringPermutation()
		{
			Permutation permutation = new Permutation();

			var res = permutation.GetDistinctPermutation("abc");
			Assert.IsTrue(res.Equals("abc|acb|bac|bca|cab|cba"));
			Console.WriteLine("*************");
			var res2 = permutation.GetDistinctPermutation("aab");
			Assert.IsTrue(res2.Equals("aab|aba|baa"));
			Console.WriteLine("*************");
			var res3 = permutation.GetDistinctPermutation("aaa");
			Assert.IsTrue(res3.Equals("aaa"));

			Assert.IsTrue(permutation.GetDistinctPermutation("a").Equals("a"));
			Assert.IsTrue(string.IsNullOrEmpty(permutation.GetDistinctPermutation("")));
			Assert.IsTrue(string.IsNullOrEmpty(permutation.GetDistinctPermutation(null)));
		}
	}
}
