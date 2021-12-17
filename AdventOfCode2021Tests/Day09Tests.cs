using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day09Tests : Tester
    {
        protected override Solver Solver => new Day09(Resources.Day09Input);

        protected override string Part1Output => Resources.Day09Part1Output;
        protected override string Part2Output => Resources.Day09Part2Output;

        [TestMethod]
        [DataRow("2199943210\r\n3987894921\r\n9856789892\r\n8767896789\r\n9899965678", 15)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day09(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("2199943210\r\n3987894921\r\n9856789892\r\n8767896789\r\n9899965678", 1134)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day09(input).SolvePart2());
        }
    }
}