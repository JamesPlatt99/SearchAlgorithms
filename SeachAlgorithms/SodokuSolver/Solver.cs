using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    class Solver
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
                        RevertNode();
                        failed = true;
                    }
                    _curNode.Value = _curNode.PotentialValues.Peek();
                    if (failed)
                    {
                        _curNode.FailedValues.Add(_curNode.Value);
                        i = _curNode.Row;
                        j = _curNode.Col; 

                    }
                }
            }

            return _sodoku;
        }

        private void RevertNode()
        {
            _visitedNodes.Pop();
            _curNode = _visitedNodes.Peek();
        }
    }
}
