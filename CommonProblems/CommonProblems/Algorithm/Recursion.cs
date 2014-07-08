﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm
{
	public static class Recursion
	{
		public static string ReverseString(string inStr)
		{
			if (inStr == null || inStr == "") return "";

			else if (inStr.Length == 1) return inStr;

			else return inStr.Substring(inStr.Length - 1, 1) + ReverseString(inStr.Substring(0, inStr.Length - 1));
		}
	}
}
