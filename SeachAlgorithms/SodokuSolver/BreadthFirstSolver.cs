using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    class BreadthFirstSolver : DepthFirstSolver
    {
        private Queue<Node> _visitedNodes = new Queue<Node>();
        public BreadthFirstSolver(Sodoku sodoku) : base(sodoku)
        {
            this._sodoku = sodoku;
        }

        protected override void AddVisitedNode()
        {
            _visitedNodes.Enqueue(_curNode);
        }
        protected override void RemoveVisitedNode()
        {
            _visitedNodes.Dequeue();
        }
        protected override void RevertNode()
        {
            RemoveVisitedNode();
            _curNode.FailedValues = new List<int>();
            _curNode = _visitedNodes.Peek();
            _curNode.FailedValues.Add(_curNode.Value);
            _curNode.CalculatePossibilities(_sodoku);
        }
    }
}
