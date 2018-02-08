using System;
using System.Linq;
using System.Net;
using SeachAlgorithms.Searches;
using System.Diagnostics;

namespace SeachAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
            int choice = 0;
            while(!int.TryParse(Console.ReadLine(), out choice)){
                DisplayMenu();
            }
            switch (choice)
            {
                case 1:
                    SearchWordList();
                    break;
                case 2:
                    break;
            }
            Console.ReadLine();

        }

        static void DisplayMenu()
        {
            Console.WriteLine("James' Super Search Algorithm Stuff!!!1!!");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("   1. Search words");
            Console.WriteLine("   2. Sodoku Solver");
            Console.WriteLine("");
            Console.Write(" :");
        }

        static void SearchWordList()
        {
            Console.WriteLine();
            Console.Write("Word to search for: ");
            string word = Console.ReadLine();

            var client = new WebClient();
            var words = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
            var comparableWords = words.Select(n => new ComparableWord(n));
            var sorter = new Sorting.MergeSort<ComparableWord>();
            sorter.Sort(comparableWords.ToList());
            var binarySearch = new BinarySearch<ComparableWord>(comparableWords);
            var linearSearch = new LinearSearch<ComparableWord>(comparableWords);

            SearchWordList(word, binarySearch);
            SearchWordList(word, linearSearch);
        }

        static void SearchWordList(string word, Searches.ISearcher<ComparableWord> searcher)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            Console.WriteLine(searcher.ExistsInData(new ComparableWord(word)));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
