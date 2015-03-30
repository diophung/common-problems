using CommonProblems.Algorithm.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CommonProblems.Tests.DataStructure.String
{
    [TestFixture]
    public class GetNearByWordsTests
    {
        [TestCase("hi","go")]
        public void TestPositiveGetNearByWord(string word, string expectedFirstMatch)
        {
            GetNearByWords finder = new GetNearByWords();
            var nearby = finder.getNearbyWords(word);

            Assert.IsTrue(nearby.Count == 1);
            Assert.IsTrue(nearby.ElementAt(0) == expectedFirstMatch);
        }
    }
}
