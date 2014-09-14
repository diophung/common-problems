using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm
{
	[TestClass]
	public class BacktrackRecursionTest
	{
		[TestMethod]
		public void QueenProblemTest()
		{
			BacktrackRecursion backtrackRecursion = new BacktrackRecursion();
			backtrackRecursion.QueensProblem();
		}
	}
}
