using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day13Tests : Tester
    {
        protected override Solver Solver => new Day13(Resources.Day13Input);

        protected override string Part1Output => Resources.Day13Part1Output;
        protected override string Part2Output => Resources.Day13Part2Output;

        [TestMethod]
        [DataRow("6,10\r\n0,14\r\n9,10\r\n0,3\r\n10,4\r\n4,11\r\n6,0\r\n6,12\r\n4,1\r\n0,13\r\n10,12\r\n3,4\r\n3,0\r\n8,4\r\n1,10\r\n2,14\r\n8,10\r\n9,0\r\n\r\nfold along y=7\r\nfold along x=5", 17)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day13(input).SolvePart1());
        }
    }
}