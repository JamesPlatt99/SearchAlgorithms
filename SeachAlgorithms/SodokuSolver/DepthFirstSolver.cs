using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class DepthFirstSolver
    {
        protected Sodoku _sodoku;
        protected Node _curNode;
        private Stack<Node> _visitedNodes = new Stack<Node>();

        public DepthFirstSolver(Sodoku sodoku)
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
                    AddVisitedNode();
                    
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
        #region Helper Methods
        
        protected void DisplaySodoku()
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
        #endregion

        #region Virtual methods
        protected virtual void RevertNode()
        {
            RemoveVisitedNode();
            _curNode.FailedValues = new List<int>();
            _curNode = _visitedNodes.Peek();
            _curNode.FailedValues.Add(_curNode.Value);
            _curNode.CalculatePossibilities(_sodoku);
        }

        protected virtual void AddVisitedNode()
        {
            _visitedNodes.Push(_curNode);
        }

        protected virtual void RemoveVisitedNode()
        {
            _visitedNodes.Pop();
        }

        #endregion
    }
}
