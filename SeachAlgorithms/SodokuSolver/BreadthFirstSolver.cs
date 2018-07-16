using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class BreadthFirstSolver : BaseSodokuSolver
    {
        
        private Queue<Node> _visitedNodes = new Queue<Node>();

        public BreadthFirstSolver(Sodoku sodoku) : base(sodoku) { }

        #region Helper Methods
        #endregion

        #region Overrides
        protected override Position ProcessNode(Position curPos)
        {
            _curNode = _sodoku.Grid[curPos.row, curPos.col];
            _curNode.CalculatePossibilities(_sodoku);
            AddVisitedNode();

            return curPos;
        }

        protected override void AddVisitedNode()
        {
            _visitedNodes.Enqueue(_curNode);
        }

        protected override void RemoveVisitedNode()
        {
            _visitedNodes.Dequeue();
        }

        protected override Node GetPreviousNode()
        {
            return _visitedNodes.Peek();
        }

        #endregion
    }
}
