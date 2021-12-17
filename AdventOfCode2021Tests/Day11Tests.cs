using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day11Tests : Tester
    {
        protected override Solver Solver => new Day11(Resources.Day11Input);

        protected override string Part1Output => Resources.Day11Part1Output;
        protected override string Part2Output => Resources.Day11Part2Output;

        [TestMethod]
        [DataRow("5483143223\r\n2745854711\r\n5264556173\r\n6141336146\r\n6357385478\r\n4167524645\r\n2176841721\r\n6882881134\r\n4846848554\r\n5283751526", 1656)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day11(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("5483143223\r\n2745854711\r\n5264556173\r\n6141336146\r\n6357385478\r\n4167524645\r\n2176841721\r\n6882881134\r\n4846848554\r\n5283751526", 195)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day11(input).SolvePart2());
        }
    }
}