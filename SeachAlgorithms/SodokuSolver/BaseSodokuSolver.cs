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

        public BaseSodokuSolver(Sodoku sodoku)
        {
            _sodoku = sodoku;
        }


        protected abstract void AddVisitedNode();
        protected abstract void RemoveVisitedNode();
        protected abstract Position ProcessNode(Position curPos);
        protected abstract Node GetPreviousNode(); 


        public Sodoku Solve()
        {
            var curPos = new Position();
            for (curPos.col = 0; curPos.col < 9; curPos.col++)
            {
                for (curPos.row = 0; curPos.row < 9; curPos.row++)
                {
                    curPos = ProcessNode(curPos);
                }
            }
            DisplaySodoku();
            return _sodoku;
        }
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
