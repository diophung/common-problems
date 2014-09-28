using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm
{
	public static class CommonRecursion
	{
		public static string ReverseString(string inStr)
		{
			if (inStr == null || inStr == "") return "";

			else if (inStr.Length == 1) return inStr;

			else return inStr.Substring(inStr.Length - 1, 1) + ReverseString(inStr.Substring(0, inStr.Length - 1));
		}

		public static int Fibonacci(int f)
		{
			
			if (f <  1) throw new NotSupportedException("Fibonacci number must be >=1");
			if (f == 1 || f==2) return 1;

			return Fibonacci(f - 1) + Fibonacci(f - 2);
		}

	}
}
