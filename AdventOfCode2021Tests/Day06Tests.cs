using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day06Tests : Tester
    {
        protected override Solver Solver => new Day06(Resources.Day06Input);

        protected override string Part1Output => Resources.Day06Part1Output;
        protected override string Part2Output => Resources.Day06Part2Output;

        [TestMethod]
        [DataRow("3,4,3,1,2", 5934)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day06(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("3,4,3,1,2", -1)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day06(input).SolvePart2());
        }
    }
}