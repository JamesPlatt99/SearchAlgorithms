using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class BreadthFirstSolver : BaseSodokuSolver
    {
        
        private Queue<Node> _visitedNodes = new Queue<Node>();

        #region Public Methods
        public BreadthFirstSolver(Sodoku sodoku)
        {
            this._sodoku = sodoku;
        }

        public override Sodoku Solve()
        {
            bool failed;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    failed = false;
                    _curNode = _sodoku.Grid[i, j];
                    _curNode.CalculatePossibilities(_sodoku);
                    AddVisitedNode();
                    while (_curNode.PotentialValues.Count == 0)
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

        #endregion

        #region Overrides

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
