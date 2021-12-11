using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day07Tests : Tester
    {
        protected override Solver Solver => new Day07(Resources.Day07Input);

        protected override string Part1Output => Resources.Day07Part1Output;
        protected override string Part2Output => Resources.Day07Part2Output;

        [TestMethod]
        [DataRow("16,1,2,0,4,2,7,1,2,14", 37)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day07(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("16,1,2,0,4,2,7,1,2,14", 168)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day07(input).SolvePart2());
        }
    }
}