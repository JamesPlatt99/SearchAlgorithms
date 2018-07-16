using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public static class SodokuSolverFactory
    {
        public static ISodokuSolver GetSodokuSolver(Sodoku sodoku)
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
                    return GetSodokuSolver(sodoku);
            }
        }
    }
}
