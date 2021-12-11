using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day25Tests : Tester
    {
        protected override Solver Solver => new Day25(Resources.Day25Input);

        protected override string Part1Output => Resources.Day25Part1Output;
        protected override string Part2Output => Resources.Day25Part2Output;

        [TestMethod]
        [DataRow("\r\n", -1)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day25(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("\r\n", -1)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day25(input).SolvePart2());
        }
    }
}