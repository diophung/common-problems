﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.DynamicProgramming
{
	public class LongestCommonSequence
	{
		int[,] seq;

		/// <summary>
		/// Determine the longest similarity of 2 strings (if delete certain characters out of both)
		/// </summary>
		/// <param name="firstSeq"></param>
		/// <param name="secondSeq"></param>
		/// <returns></returns>
		public string GetLongestCommonSequence(string firstSeq, string secondSeq)
		{
			firstSeq = firstSeq ?? "";
			secondSeq = secondSeq ?? "";
			int firstSize = string.IsNullOrEmpty(firstSeq) ? 0 : firstSeq.Length;
			int secondSize = string.IsNullOrEmpty(secondSeq) ? 0 : secondSeq.Length;
			seq = new int[firstSize + 1, secondSize + 1];

			//bottom-up approach to populate the common sequence
			//start from bottom-up, with right-to-left scannning
			for (int i = firstSize - 1; i >= 0; i--)
			{
				for (int j = secondSize - 1; j >= 0; j--)
				{
					if (firstSeq.ElementAt(i) == secondSeq.ElementAt(j))
					{
						//if sharing the same common character at this place
						seq[i, j] = seq[i + 1, j + 1] + 1;
					}
					else
					{
						//if not, choose the longest subsequence
						seq[i, j] = Math.Max(seq[i + 1, j], seq[i, j + 1]);
					}
				}
			}

			StringBuilder lcs = new StringBuilder();
			int f = 0; int s = 0;

			//get the longest sequence
			while (f < firstSize && s < secondSize)
			{
				if (firstSeq.ElementAt(f) == secondSeq.ElementAt(s))
				{
					lcs.Append(firstSeq.ElementAt(f));
					f++;
					s++;
				}
				else if (seq[f + 1, s] >= seq[f, s + 1])
					f++;
				else
					s++;

			}
			return lcs.ToString();
		}
	}
}
