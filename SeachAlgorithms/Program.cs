using System;
using System.Linq;
using System.Net;
using SeachAlgorithms.Searches;
using SeachAlgorithms.SodokuSolver;
using System.Diagnostics;
using System.Collections.Generic;

namespace SeachAlgorithms
{
    public class Program
    {
        private static List<ComparableWord> _sortedWordsAll;
        private static List<ComparableWord> _sortedWordsCommon;
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                int choice = 0;
                while (!int.TryParse(Console.ReadLine(), out choice)) {
                    DisplayMenu();
                }
                switch (choice)
                {
                    case 1:
                        SearchWordList();
                        break;
                    case 2:
                        SolveSodoku();
                        break;
                }
                Console.ReadLine();
            }

        }

        static List<ComparableWord> SortWords(IEnumerable<String> words)
        {
            Console.WriteLine("Sorting words...");
            var comparableWords = words.Select(n => new ComparableWord(n));
            var sorter = new Sorting.MergeSort<ComparableWord>();
            return sorter.Sort(comparableWords.ToList());
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

        static void SolveSodoku()
        {
            Console.Write("Please enter filename: ");
            var sodoku = new Sodoku(Console.ReadLine());
            var solver = GetSolver(sodoku);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            solver.Solve();
            stopwatch.Stop();
            Console.WriteLine(sodoku.Validate());
            Console.WriteLine("Done in: {0}",stopwatch.Elapsed);
        }

        static DepthFirstSolver GetSolver(Sodoku sodoku)
        {
            Console.WriteLine("  1. Depth first");
            Console.WriteLine("  2. Breadth first");
            Console.Write("  :");
            switch (Console.ReadLine())
            {
                case "1":
                    return new DepthFirstSolver(sodoku);
                case "2":
                    return new BreadthFirstSolver(sodoku);
                default:
                    return GetSolver(sodoku);
            }
        }

        static void SearchWordList()
        {
            var client = new WebClient();
            var allWords = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
            var commonWords = client.DownloadString("https://raw.githubusercontent.com/first20hours/google-10000-english/master/google-10000-english-usa-no-swears-short.txt").Split("\n");

            List<ComparableWord> AllWords = _sortedWordsAll ?? (_sortedWordsAll = SortWords(allWords));
            List<ComparableWord> CommonWords = _sortedWordsCommon ?? (_sortedWordsCommon = SortWords(commonWords));
            Console.WriteLine();
            Console.Write("Word to search for: ");
            string word = Console.ReadLine();

            var binarySearchAll = new BinarySearch<ComparableWord>(AllWords);
            var linearSearchAll = new LinearSearch<ComparableWord>(AllWords);

            var binarySearchCommon = new BinarySearch<ComparableWord>(CommonWords);
            var linearSearchCommon = new LinearSearch<ComparableWord>(CommonWords);

            SearchWordList(word, binarySearchAll);
            SearchWordList(word, linearSearchAll);

            SearchWordList(word, binarySearchCommon);
            SearchWordList(word, linearSearchCommon);
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
