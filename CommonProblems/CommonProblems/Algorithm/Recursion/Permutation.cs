using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CommonProblems.Algorithm
{
	public class Permutation
	{
		/// return all possible permuations of a string (without duplicated output), seperated by pipe "|"
		public string GetDistinctPermutation(string word)
		{
			IDictionary<string, bool> dict = new Dictionary<string, bool>();
			StringBuilder output = new StringBuilder();
			if (string.IsNullOrEmpty(word)) 
				return "";

			if (word.Length >= 1) {
				PermuteDistinct(string.Empty, word, dict, output);
			}

			return output.ToString().Substring(0, output.Length - 1); //strip off last "|"
		}

		/// Algo
		///		If there is no character left to print, stop
		///		Else :
		///			find a character and add it to the string builtWord
		///			use permuatation to find the output from the rest
		///  Complexity: O(n!) since there are n! way to permute
		private void PermuteDistinct(string created, string word, IDictionary<string, bool> addedWords, StringBuilder output)
		{
			if (string.IsNullOrEmpty(word))
			{
				if (!addedWords.ContainsKey(created)) //uniqueness
				{
					addedWords[created] = true;
					output.Append(created + "|");
				}
			}

			if (!string.IsNullOrEmpty(word))
			{
				for (int i = 0; i < word.Length; i++)
				{
					string subword = word.Substring(0, i) + word.Substring(i + 1); //extract the character at i
					PermuteDistinct(created + word.ElementAt(i), subword, addedWords, output);
				}
			}
		}


		public static List<string> Permute(string s)
		{
			List<string> permutations = new List<string>();

			if (s == null) return null;
			if (s.Length == 0)
			{
				permutations.Add("");
				return permutations;
			}

			Char first = s.ElementAt(0);
			string remainder = s.Substring(1);
			List<string> words = Permute(remainder);

			foreach (string w in words)
			{
				for (int i = 0; i <= w.Length; i++)
				{
					permutations.Add(insertCharAt(w, first, i));
				}
			}
			return permutations;
		}

		static string insertCharAt(string word, char ch, int index)
		{
			string start = word.Substring(0, index);
			string end = word.Substring(index);
			return start + ch + end;
		}
	}
}
