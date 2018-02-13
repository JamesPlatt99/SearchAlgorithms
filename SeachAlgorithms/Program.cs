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
        private static List<ComparableWord> _sortedWords;
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

        static List<ComparableWord> SortWords()
        {
            Console.WriteLine("Sorting words...");
            var client = new WebClient();
            var words = client.DownloadString("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Split("\n");
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
            var solver = new Solver(sodoku);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            solver.Solve();
            stopwatch.Stop();
            Console.WriteLine(sodoku.Validate());
            Console.WriteLine("Done in: {0}",stopwatch.Elapsed);
        }

        static void SearchWordList()
        {
            List<ComparableWord> comparableWords = _sortedWords ?? (_sortedWords = SortWords());
            Console.WriteLine();
            Console.Write("Word to search for: ");
            string word = Console.ReadLine();

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
