
using System;

namespace CommonProblems.Helper
{
	public static class StringExtension
	{
		public static bool EqualsIgnoreCase(this string self, string compareTo)
		{

			if (self == null && compareTo == null) return true;
			if (self == string.Empty && compareTo == string.Empty) return true;

			return string.Compare(self, compareTo, StringComparison.InvariantCultureIgnoreCase) == 0;
		}
	}
}