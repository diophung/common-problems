using CommonProblems.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests.Algorithm
{
	[TestClass]
	public class BacktrackRecursionTest
	{
		[TestMethod]
		public void TestQueenProblem()
		{
			BacktrackRecursion backtrackRecursion = new BacktrackRecursion();
			backtrackRecursion.QueensProblem();
		}
	}
}