using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Detect whether a string contain only unique characters
/// </summary>
public class UniqueCharacter
{
	//public const string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

	/// <summary>
	/// Whether a string contains only unique characters
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	public bool IsUnique(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return false;
		}
		Hashtable charsMap = new Hashtable();

		//store the count of each character
		for (int i = 0; i < str.Length; i++)
		{
			if (!charsMap.ContainsKey(str[i]))
			{
				charsMap.Add(str[i], 1);
			}
			else
			{
				//increase the count of this char
				int currentCount = (int) charsMap[str[i]] ;
				currentCount++;
				charsMap[str[i]] = currentCount;
			}
		}

		
		for (int i = 0; i < str.Length; i++)
		{
			//duplicate char
			if (charsMap.ContainsKey(str[i]) && (int) charsMap[str[i]] > 1)
			{
				return false;
			}
		}

		return true;
	}
}