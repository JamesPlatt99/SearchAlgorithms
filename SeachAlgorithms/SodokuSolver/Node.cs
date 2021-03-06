﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class Node
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
        public Queue<int> PotentialValues;

        public void CalculatePossibilities(Sodoku sodoku)
        {
            if (!sodoku.Grid[this.Row, this.Col].CanChange)
            {
                PotentialValues = new Queue<int>(new[] { sodoku.Grid[this.Row, this.Col].Value });
            }
            else
            {
                List<int> possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Where(n=> !FailedValues.Contains(n)).ToList();
                GetPossibleValuesIn3x3(possibilities, sodoku);
                GetPossibleValuesInRowCol(possibilities, sodoku);                
                PotentialValues = new Queue<int>(possibilities);
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == this.GetType())
            {
                return (((Node)obj).Row == this.Row && ((Node)obj).Col == this.Col);
            }
            return false;
        }


        private List<int> GetPossibleValuesIn3x3(List<int> possibilities, Sodoku sodoku)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (possibilities.Contains(sodoku.Grid[(this.Row / 3) * 3 + i, (this.Col / 3) * 3 + j].Value) && sodoku.Grid[(this.Row / 3) * 3 + i, (this.Col / 3) * 3 + j] != this)
                    {
                        possibilities.Remove(sodoku.Grid[(this.Row / 3) * 3 + i, (this.Col / 3) * 3 + j].Value);
                    }
                }
            }
            return possibilities;
        }

        private List<int> GetPossibleValuesInRowCol(List<int> possibilities, Sodoku sodoku)
        {
            for (int i = 0; i < 9; i++)
            {
                if (possibilities.Contains(sodoku.Grid[this.Row, i].Value) && (i != this.Col))
                {
                    possibilities.Remove(sodoku.Grid[this.Row, i].Value);
                }
                if (possibilities.Contains(sodoku.Grid[i, this.Col].Value) && (i != this.Row))
                {
                    possibilities.Remove(sodoku.Grid[i, this.Col].Value);
                }
            }
            return possibilities;
        }
    }
}
