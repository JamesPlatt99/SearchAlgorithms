using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeachAlgorithms;
using SeachAlgorithms.Searches;
using System.Linq;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class WordSearcherTests
    {
        [TestMethod]
        public void BinarySearchTests()
        {
            var client = new WebClient();
            var words = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
            var comparableWords = words.Select(n => new ComparableWord(n));
            var sorter = new SeachAlgorithms.Sorting.MergeSort<ComparableWord>();
            comparableWords = sorter.Sort(comparableWords.ToList());
            var binarySearch = new BinarySearch<ComparableWord>(comparableWords);

            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("overnumerousness")));
            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("overnuMeroUsness")));
            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("ZZZ")));
            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("alphabet")));
            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("2")));
            Assert.IsTrue(binarySearch.ExistsInData(new ComparableWord("ace")));
            Assert.IsFalse(binarySearch.ExistsInData(new ComparableWord("ZassadfsdfZZ")));
        }
        
        [TestMethod]
        public void LinearSearchTests()
        {
            var client = new WebClient();
            var words = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
            var comparableWords = words.Select(n => new ComparableWord(n));
            var linearSearch = new LinearSearch<ComparableWord>(comparableWords);

            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("overnumerousness")));
            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("overnuMeroUsness")));
            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("ZZZ")));
            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("alphabet")));
            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("2")));
            Assert.IsTrue(linearSearch.ExistsInData(new ComparableWord("ace")));
            Assert.IsFalse(linearSearch.ExistsInData(new ComparableWord("ZassadfsdfZZ")));
        }
    }
}
