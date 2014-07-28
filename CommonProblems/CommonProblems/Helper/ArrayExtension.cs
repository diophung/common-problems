using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Helper
{
	public static class ArrayExtension
	{
		public static bool ElementEquals(this int[] a, int[] b)
		{
			try
			{
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] != b[i]) return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}
