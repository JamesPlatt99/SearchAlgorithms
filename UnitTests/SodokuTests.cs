using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeachAlgorithms;
using SeachAlgorithms.Searches;
using SeachAlgorithms.SodokuSolver;
using System.IO;
using System.Linq;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class SodokuTests
    {
        [TestMethod]
        public void ValidateRulesDFS()
        {
            var sodoku = new Sodoku("sodoku.txt");
            var solver = new DepthFirstSolver(sodoku);            
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());

            sodoku = new Sodoku("1.txt");
            solver = new DepthFirstSolver(sodoku);
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());

            sodoku = new Sodoku("2.txt");
            solver = new DepthFirstSolver(sodoku);
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());
        }

        [TestMethod]
        public void ValidateOriginalPositionsDFS()
        {
            var orgSodoku = new Sodoku("sodoku.txt");
            var solvedSodoku = new Sodoku("sodoku.txt");
            var solver = new DepthFirstSolver(solvedSodoku);
            solver.Solve();
            for(int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if(orgSodoku.Grid[x,y].Value != 0)
                    {
                        Assert.AreEqual(orgSodoku.Grid[x, y].Value, solvedSodoku.Grid[x, y].Value);
                    }
                }
            }
        }

        [TestMethod]
        public void ValidateRulesBFS()
        {
            var sodoku = new Sodoku("sodoku.txt");
            var solver = new BreadthFirstSolver(sodoku);
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());

            sodoku = new Sodoku("1.txt");
            solver = new BreadthFirstSolver(sodoku);
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());

            sodoku = new Sodoku("2.txt");
            solver = new BreadthFirstSolver(sodoku);
            solver.Solve();
            Assert.IsTrue(sodoku.Validate());
        }

        [TestMethod]
        public void ValidateOriginalPositionsBFS()
        {
            var orgSodoku = new Sodoku("sodoku.txt");
            var solvedSodoku = new Sodoku("sodoku.txt");
            var solver = new BreadthFirstSolver(solvedSodoku);
            solver.Solve();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (orgSodoku.Grid[x, y].Value != 0)
                    {
                        Assert.AreEqual(orgSodoku.Grid[x, y].Value, solvedSodoku.Grid[x, y].Value);
                    }
                }
            }
        }
    }
}
