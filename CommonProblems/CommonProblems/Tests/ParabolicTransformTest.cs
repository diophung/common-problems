using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.Algorithm.Misc;
using CommonProblems.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonProblems.Tests {
	[TestClass]
	public class ParabolicTransformTest {

		[TestMethod]
		public void TestParabolicTransform() {
			int[] oneElementInput = new[] { 0 };
			int[] oneElementOutput = ParabolicArrayTransform.MapArrayFn(oneElementInput, 1, 1, 1);

			Assert.IsTrue(oneElementOutput.Length == 1);
			Assert.IsTrue(oneElementOutput[0] == 1);
			Assert.IsTrue(oneElementOutput.IsSortedAsc());

			int[] negativeInput = new[] { -4, -3, -2, 0 };
			int[] outputOfNegativeInput = ParabolicArrayTransform.MapArrayFn(negativeInput, 1, 1, 1);
			Assert.IsTrue(outputOfNegativeInput.Length == 4);
			Assert.IsTrue(outputOfNegativeInput.IsSortedAsc());

			int[] increasing = new[] { 0, 1, 2, 3, 4 };
			int[] output = ParabolicArrayTransform.MapArrayFn(increasing, -2, 1, 2);
			Assert.IsTrue(output.IsSortedAsc());
			Assert.IsTrue(output.Length == 5);
			Assert.IsTrue(output[4] == 2);
		}
	}
}
