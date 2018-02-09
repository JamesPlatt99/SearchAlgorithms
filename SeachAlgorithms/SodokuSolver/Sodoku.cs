using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.SodokuSolver
{
    class Sodoku
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
        
        public bool ValidateRow(int row)
        {
            var rowValues = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                rowValues.Add(Grid[row,i].Value);
            }
            return (rowValues.Distinct().Count() == 9 && rowValues.Any(n => n == 0));
        }
        private bool ValidateCol(int col)
        {
            var colValues = new List<int>();
            for(int i = 0; i<9; i++)
            {
                colValues.Add(Grid[i,col].Value);
            }
            return (colValues.Distinct().Count() == 9 && colValues.Any(n => n == 0));
        }       

        #endregion
    }
}
