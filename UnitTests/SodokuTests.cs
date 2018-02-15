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
        public void Test1()
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
    }
}
