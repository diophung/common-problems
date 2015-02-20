using System.Collections.Generic;
using System.Text;

namespace CommonProblems.Algorithm.String
{
	/// <summary>
	/// Test if a certain set of chars can build a given word
	/// </summary>
	public class StringCanBuildWords
	{
		char[] chars { get; set; }

		//initial with a set of characters
		public StringCanBuildWords(char[] initChars)
		{
			chars = new char[initChars.Length];

			//copy the set of chars
			for (int i = 0; i < initChars.Length; i++)
			{
				chars[i] = initChars[i];
			}
		}

		/// <summary>
		/// Solving problem: given a char[], check if this char[] can build a word
		/// For e.g.: chars ="abchello" --> can build "hello", but cannot build "hi"
		/// </summary>
		/// <param name="word">the word to build</param>
		/// <returns></returns>
		public bool CanBuildWord(string word)
		{
			//Solution 1: Use Dictionary / Hashtable / Hashmap to store the count of each characters. Compare 2 Dictionary.
			//Solution 2: If ASCII characters, use int[256] where the index is the ASCII code (calculate by '<char>'- 'a'), the value is the count of that character.

			//Solution 1 implementation

			if (string.IsNullOrEmpty(word)) {
				return true;
			}
			
			if (this.chars == null || this.chars.Length == 0) {
				return false;
			}
			//build the string
			StringBuilder str = new StringBuilder();
			for (int i = 0; i < chars.Length; i++)
			{
				str.Append(chars[i]);
			}

			var dict1 = BuildCountOfChar(str.ToString());
			var dict2 = BuildCountOfChar(word);

			//compare the count of each char
			foreach (var c in dict2.Keys)
			{
				if (!dict1.ContainsKey(c))
				{
					return false; //missing this character
				}

				if (dict1[c] < dict2[c])
				{ 
					//not matching exact count of characters
					return false;
				}
			}

			return true;
		}

		private Dictionary<char, int> BuildCountOfChar(string word)
		{
			Dictionary<char, int> countsOfChar = new Dictionary<char, int>();

			for (int i = 0; i < word.Length; i++)
			{
				if (!countsOfChar.ContainsKey(word[i]))
				{
					countsOfChar[word[i]] = 1; //store the instance
				}
				else
				{
					countsOfChar[word[i]]++;
				}
			}

			return countsOfChar;
		}
	}
}