using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests
{
	[TestClass]
	public  class OverloadingTest
	{
		public  void g(int a, double b)
		{
			Console.WriteLine(a + b);
		}

		public  void g(double a, int b)
		{
			Console.WriteLine(a - b);
		}

		[TestMethod]
		public  void TestOverload()
		{
			g(3,6.00);
		}
	}
}
