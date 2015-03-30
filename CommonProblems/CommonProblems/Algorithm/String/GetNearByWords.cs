using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.String
{
    public class GetNearByWords
    {
        public List<string> getNearbyWords(string word)
        {
            List<string> output = new List<string>();
            var words = nearByPermutations(word, 0);
            foreach (var w in words)
            {
                if (isWord(w))
                {
                    output.Add(w);
                }
            }
            return output;
        }

        List<string> nearByPermutations(string word, int index)
        {
            if (index >= word.Length)
            {
                return new List<string> { "" };
            }

            List<string> subWord = nearByPermutations(word, index + 1);
            List<char> chars = getNearbyChars(word.ElementAt(index));
            return Permute(subWord, chars);
        }


        List<string> Permute(List<string> words, List<char> chars)
        {
            List<string> results = new List<string>();

            foreach (var letter in chars)
            {
                foreach (var subword in words)
                {
                    results.Add(letter + subword);
                }
            }
            return results;
        }

        //sample data
        bool isWord(string w)
        {
            if (w == "go" || w == "hi") return true;
            return false;
        }

        //sample data
        List<char> getNearbyChars(char ch)
        {
            switch (ch)
            {
                case 'h':
                    return new List<char> { 'g', 'j' };
                case 'i':
                    return new List<char> { 'u', 'o' };
                default:
                    return new List<char>();
            }
        }
    }
}
