using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.String
{
	public static class StringAlgo
	{
		
		
		
		/// <summary>
		/// Solving problem: remove all duplicate character in a string
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string RemoveDuplicateChar(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}
			
			//This algo is O(n^2) since the Contains take n comparison
			var strArr = str.ToCharArray();
			string cleaned = "";
			for (int i = 0; i < strArr.Length; i++)
			{
				if (!cleaned.Contains(strArr[i]))
				{
					cleaned += strArr[i];
				}
			}
			
			return cleaned;
		}
		
		
	}
}
