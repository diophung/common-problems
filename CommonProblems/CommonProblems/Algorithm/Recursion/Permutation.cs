using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProblems.Algorithm
{
	public class Permutation
	{
		/// <summary>
		/// return all possible permuations of a string (without duplicated output), seperated by pipe "|"
		/// </summary>
		/// <param name="original"></param>
		public string StringPermute(string original)
		{
			try
			{
				IDictionary<string, bool> dict = new Dictionary<string, bool>();
				StringBuilder allResults = new StringBuilder();
				if (string.IsNullOrEmpty(original))
				{
					Console.WriteLine(original);
					return "";
				}

				if (original.Length == 1)
				{
					Console.WriteLine(original);
					return original;
				}

				if (original.Length > 1)
				{
					Permute(string.Empty, original, dict, allResults);
				}

				return allResults.ToString().Substring(0, allResults.Length - 1);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// Algo
		///		If there is no character left to print, stop
		///		Else :
		///			find a character and add it to the string soFar
		///			use permuatation to find the output from the rest
		private void Permute(string soFar, string remaining, IDictionary<string, bool> dict, StringBuilder allResults)
		{
			//soFar: the string created by permuation
			//remaining: the rest of the group
			//dict: the dictionary used to check for duplication
			if (string.IsNullOrEmpty(remaining))
			{
				//avoid output duplication
				if (!dict.ContainsKey(soFar))
				{
					dict[soFar] = true;
					allResults.Append(soFar + "|");
					Console.WriteLine(soFar);
				}
			}
			for (int i = 0; i < remaining.Length; i++)
			{
				//permute
				string temp = remaining.Substring(0, i) + remaining.Substring(i + 1);

				Permute(soFar + remaining.ElementAt(i), temp, dict, allResults);
			}
		}
	}
}
