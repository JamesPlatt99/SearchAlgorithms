using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    public class Sodoku
    {
        public Node[,] Grid = new Node[9, 9];

        public Sodoku(String path)
        {
            StreamReader streamReader = new StreamReader(path);
            for(int i = 0; i < 9; i++)
            {
                int[] row = streamReader.ReadLine().ToCharArray().Select(n => int.Parse(n.ToString())).ToArray();
                for(int j = 0; j < 9; j++)
                {
                    Grid[i, j] = new Node(row[j], i, j);
                }
            }
        }

        #region Public Methods

        public bool Validate()
        {
            for(int i = 0; i < 9; i++)
            {
                if(!ValidateRow(i) || !ValidateCol(i))
                {
                    return false;
                }
            }
            for(int i = 0; i <3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!ValidateSquare(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Helper Methods

        private bool ValidateRow(int row)
        {
            var rowValues = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                rowValues.Add(Grid[row,i].Value);
            }
            return (rowValues.Distinct().Count() == 9 && !rowValues.Any(n => n == 0));
        }

        private bool ValidateCol(int col)
        {
            var colValues = new List<int>();
            for(int i = 0; i<9; i++)
            {
                colValues.Add(Grid[i,col].Value);
            }
            return (colValues.Distinct().Count() == 9 && !colValues.Any(n => n == 0));
        }       
        
        private bool ValidateSquare(int row, int col)
        {
            var values = new List<int>();
            for(int i = 0; i <3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    int curVal = Grid[row * 3 + i, col * 3 + j].Value;
                    if (values.Contains(curVal))
                    {
                        return false;
                    }
                    values.Add(curVal);
                }
            }
            return true;
        }
        #endregion
    }
}
