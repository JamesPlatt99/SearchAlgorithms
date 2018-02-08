using System;
using System.Linq;
using System.Net;
using SeachAlgorithms.Searches;
using System.Diagnostics;

namespace SeachAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var stopwatch = new Stopwatch();
            var words = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
            var comparableWords = words.Select(n => new ComparableWord(n));
            var binarySearch = new BinarySearch<ComparableWord>(comparableWords);
            var linearSearch = new LinearSearch<ComparableWord>(comparableWords);

            stopwatch.Start();
            Console.WriteLine(linearSearch.ExistsInData(new ComparableWord("overnumerousness")));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(binarySearch.ExistsInData(new ComparableWord("overnumerousness")));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
