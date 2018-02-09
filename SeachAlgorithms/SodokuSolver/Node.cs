using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    class Node
    {
        public int Value;
        public bool CanChange;
        public int Row;
        public int Col;
        public List<int> FailedValues = new List<int>();

        public Node(int value, int row, int col)
        {
            this.Value = value;
            CanChange = value == 0;
            Row = row;
            Col = col;
        }
        public Stack<int> PotentialValues;

        public void CalculatePossibilities(Sodoku sodoku)
        {
            if (!sodoku.Grid[this.Row, this.Col].CanChange)
            {
                PotentialValues =  new Stack<int>(sodoku.Grid[this.Row, this.Col].Value);
            }
            List<int> possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Where(n=> !FailedValues.Contains(n)).ToList();

            //Validate 3x3 grid            
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (possibilities.Contains(sodoku.Grid[(this.Row / 3) * 3 + i, (this.Col / 3) * 3 + j].Value) && ((this.Row / 3) * 3 + i != this.Row) && ((this.Col / 3) * 3 + j != this.Col))
                    {
                        possibilities.Remove(sodoku.Grid[(this.Row / 3) * 3 + i, (this.Col / 3) * 3 + j].Value);
                    }
                }
            }

            //Validate row and column
            for (int i = 0; i < 9; i++)
            {
                if (possibilities.Contains(sodoku.Grid[this.Row, i].Value) && (i != this.Row))
                {
                    possibilities.Remove(sodoku.Grid[this.Row, i].Value);
                }
                if (possibilities.Contains(sodoku.Grid[i, this.Col].Value) && (i != this.Col))
                {
                    possibilities.Remove(sodoku.Grid[i, this.Col].Value);
                }
            }

            PotentialValues = new Stack<int>(possibilities);
        }
    }
}
