using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day03Tests : Tester
    {
        protected override Solver Solver => new Day03(Resources.Day03Input);

        protected override string Part1Output => Resources.Day03Part1Output;
        protected override string Part2Output => Resources.Day03Part2Output;

        [TestMethod]
        [DataRow("00100\r\n11110\r\n10110\r\n10111\r\n10101\r\n01111\r\n00111\r\n11100\r\n10000\r\n11001\r\n00010\r\n01010", 198)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day03(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("00100\r\n11110\r\n10110\r\n10111\r\n10101\r\n01111\r\n00111\r\n11100\r\n10000\r\n11001\r\n00010\r\n01010", 230)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day03(input).SolvePart2());
        }
    }
}