using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public abstract class BaseSodokuSolver : ISodokuSolver
    {
        protected Sodoku _sodoku;
        protected Node _curNode;
        private ICollection<Node> _visitedNodes;


        public abstract Sodoku Solve();
        protected abstract void AddVisitedNode();
        protected abstract void RemoveVisitedNode();
        protected abstract Node GetPreviousNode(); 


        protected void DisplaySodoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(_sodoku.Grid[i, j]?.Value ?? 0);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        protected void RevertNode()
        {
            if (_curNode.CanChange) { _curNode.Value = 0; }
            RemoveVisitedNode();
            _curNode.FailedValues = new List<int>();
            _curNode = GetPreviousNode();
            if(!_curNode.CanChange){ RevertNode(); }
            _curNode.FailedValues.Add(_curNode.Value);
            _curNode.CalculatePossibilities(_sodoku);
        }
    }
}
