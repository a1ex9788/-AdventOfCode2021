using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day02Tests : Tester
    {
        protected override Solver Solver => new Day02(Resources.Day02Input);

        protected override string Part1Output => Resources.Day02Part1Output;
        protected override string Part2Output => Resources.Day02Part2Output;

        [TestMethod]
        [DataRow("forward 5\r\ndown 5\r\nforward 8\r\nup 3\r\ndown 8\r\nforward 2", 150)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day02(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("forward 5\r\ndown 5\r\nforward 8\r\nup 3\r\ndown 8\r\nforward 2", 900)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day02(input).SolvePart2());
        }
    }
}