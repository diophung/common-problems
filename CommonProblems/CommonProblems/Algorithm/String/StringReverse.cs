using System.Linq;
using System.Text;

namespace CommonProblems.Algorithm.String
{
	/// <summary>
	/// Reverse a string in C-style.<br></br>
	/// C-style means: "abcd" contains five charaters, include <i>null</i> character
	/// </summary>
	public class StringReverse
	{
		public string Reverse(string input)
		{
			if (input == null) return null;
			if (input == string.Empty) return string.Empty;


			StringBuilder sb = new StringBuilder();
			for (int i = input.Length - 1; i >= 0; --i)
			{
				sb.Append(input.ElementAt(i));
			}
			return sb.ToString();
		}
	}
}