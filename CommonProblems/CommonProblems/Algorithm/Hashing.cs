using System.Linq;

namespace CommonProblems.Algorithm
{
	public class Hashing
	{
		public static readonly string Alphabet = "abcdefbghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ123456789"; //base-62
		public static readonly int Base = Alphabet.Length; //62

		// convert the ID in database to number: 12345 --> xyz
		public static string Encode(int i)
		{
			if (i == 0) return Alphabet[0].ToString();
			string output = "";
			while (i > 0)
			{
				output += (Alphabet[i%Base]); //convert number to char
				i = i/Base; //keep on hashing
			}
			char[] encoded = output.Reverse().ToArray();
			string result = "";
			foreach (var c in encoded)
			{
				result += c.ToString();
			}
			return result;
		}

		//Convert from abc to 12345 - the ID in database
		public static int Decode(string s)
		{
			int i = 0;
			foreach (var c in s)
			{
				i = (i*Base) + Alphabet.IndexOf(c);
			}
			return i;
		}

	}
}
