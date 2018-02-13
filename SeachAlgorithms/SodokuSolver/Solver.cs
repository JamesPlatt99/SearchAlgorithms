using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class Solver
    {
        Sodoku _sodoku;
        Stack<Node> _visitedNodes = new Stack<Node>();
        Node _curNode;

        public Solver(Sodoku sodoku)
        {
            _sodoku = sodoku;
        }

        public Sodoku Solve()
        {
            bool failed;
            for (int i = 0; i <9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    failed = false;
                    _curNode = _sodoku.Grid[i, j];                    
                    _curNode.CalculatePossibilities(_sodoku);
                    _visitedNodes.Push(_curNode);
                    
                    while(_curNode.PotentialValues.Count == 0)
                    {
                        _curNode.Value = 0;
                        RevertNode();
                        failed = true;
                    }
                    if (failed)
                    {
                        _curNode.FailedValues.Add(_curNode.Value);
                        i = _curNode.Row;
                        j = _curNode.Col; 

                    }
                    _curNode.Value = _curNode.PotentialValues.Peek();
                    _sodoku.Grid[i, j] = _curNode;
                }
            }

            DisplaySodoku();
            return _sodoku;
        }

        private void DisplaySodoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(_sodoku.Grid[i,j]?.Value ?? 0);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void RevertNode()
        {
            _visitedNodes.Pop();
            _curNode.FailedValues = new List<int>();
            _curNode = _visitedNodes.Peek();
            _curNode.FailedValues.Add(_curNode.Value);
            _curNode.CalculatePossibilities(_sodoku);
        }
    }
}
