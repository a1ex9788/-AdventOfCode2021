using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day14Tests : Tester
    {
        protected override Solver Solver => new Day14(Resources.Day14Input);

        protected override string Part1Output => Resources.Day14Part1Output;
        protected override string Part2Output => Resources.Day14Part2Output;

        [TestMethod]
        [DataRow("NNCB\r\n\r\nCH -> B\r\nHH -> N\r\nCB -> H\r\nNH -> C\r\nHB -> C\r\nHC -> B\r\nHN -> C\r\nNN -> C\r\nBH -> H\r\nNC -> B\r\nNB -> B\r\nBN -> B\r\nBB -> N\r\nBC -> B\r\nCC -> N\r\nCN -> C", 1588)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day14(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("NNCB\r\n\r\nCH -> B\r\nHH -> N\r\nCB -> H\r\nNH -> C\r\nHB -> C\r\nHC -> B\r\nHN -> C\r\nNN -> C\r\nBH -> H\r\nNC -> B\r\nNB -> B\r\nBN -> B\r\nBB -> N\r\nBC -> B\r\nCC -> N\r\nCN -> C", 2188189693529)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day14(input).SolvePart2());
        }
    }
}