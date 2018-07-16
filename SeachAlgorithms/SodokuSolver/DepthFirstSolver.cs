using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class DepthFirstSolver : BaseSodokuSolver
    {
        private Stack<Node> _visitedNodes = new Stack<Node>();

        #region Public Methods

        public DepthFirstSolver(Sodoku sodoku)
        {
            _sodoku = sodoku;
        }

        #endregion

        #region Helper Methods

        private Position ResetAndRevertNode(Position curPos)
        {
            RevertNode();
            ResetCurPos(curPos);
            return curPos;
        }

        private Position ResetCurPos(Position curPos)
        {
            _curNode.FailedValues.Add(_curNode.Value);
            curPos.row = _curNode.Row;
            curPos.col = _curNode.Col;
            return curPos;
        }
        #endregion

        #region Overrides
        protected override Position ProcessNode(Position curPos)
        {
            _curNode = _sodoku.Grid[curPos.row, curPos.col];
            _curNode.CalculatePossibilities(_sodoku);
            AddVisitedNode();
            while (_curNode.PotentialValues.Count == 0)
            {
                curPos = ResetAndRevertNode(curPos);
            }
            _curNode.Value = _curNode.PotentialValues.Peek();
            _sodoku.Grid[curPos.row, curPos.col] = _curNode;
            return curPos;
        }

        protected override void AddVisitedNode()
        {
            _visitedNodes.Push(_curNode);
        }

        protected override void RemoveVisitedNode()
        {
            _visitedNodes.Pop();
        }

        protected override Node GetPreviousNode()
        {
            return _visitedNodes.Peek();
        }

        #endregion
    }
}
