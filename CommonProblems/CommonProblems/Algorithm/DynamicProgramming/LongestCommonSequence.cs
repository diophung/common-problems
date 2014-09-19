using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.DynamicProgramming
{
	public class LongestCommonSequence
	{
		int[,] _seq;

		/// <summary>
		/// Determine the longest similarity of 2 strings (if delete certain characters out of both)
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns></returns>
		public string GetLongestCommonSequence(string first, string second)
		{
			first = first ?? "";
			second = second ?? "";
			int firstSize = string.IsNullOrEmpty(first) ? 0 : first.Length;
			int secondSize = string.IsNullOrEmpty(second) ? 0 : second.Length;
			_seq = new int[firstSize + 1, secondSize + 1];

			//bottom-up approach to populate the common sequence
			//start from bottom-up, with right-to-left scannning
			for (int i = firstSize - 1; i >= 0; i--)
			{
				for (int j = secondSize - 1; j >= 0; j--)
				{
					if (first.ElementAt(i) == second.ElementAt(j))
					{
						//if sharing the same common character at this place
						_seq[i, j] = _seq[i + 1, j + 1] + 1; 
					}
					else
					{
						//if not, choose the longest subsequence
						_seq[i, j] = Math.Max(_seq[i + 1, j], _seq[i, j + 1]); 
					}
				}
			}

			StringBuilder lcs = new StringBuilder();
			int f = 0; int s = 0;

			//get the longest sequence
			while (f < firstSize && s < secondSize)
			{
				if (first.ElementAt(f) == second.ElementAt(s))
				{
					lcs.Append(first.ElementAt(f));
					f++; 
					s++;
				}
				else if (_seq[f + 1, s] >= _seq[f, s + 1])
					f++;
				else
					s++;	
				
			}
			return lcs.ToString();
		}
	}
}
