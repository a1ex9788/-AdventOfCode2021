using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day12Tests : Tester
    {
        protected override Solver Solver => new Day12(Resources.Day12Input);

        protected override string Part1Output => Resources.Day12Part1Output;
        protected override string Part2Output => Resources.Day12Part2Output;

        [TestMethod]
        [DataRow("start-A\r\nstart-b\r\nA-c\r\nA-b\r\nb-d\r\nA-end\r\nb-end", 10)]
        [DataRow("dc-end\r\nHN-start\r\nstart-kj\r\ndc-start\r\ndc-HN\r\nLN-dc\r\nHN-end\r\nkj-sa\r\nkj-HN\r\nkj-dc", 19)]
        [DataRow("fs-end\r\nhe-DX\r\nfs-he\r\nstart-DX\r\npj-DX\r\nend-zg\r\nzg-sl\r\nzg-pj\r\npj-he\r\nRW-he\r\nfs-DX\r\npj-RW\r\nzg-RW\r\nstart-pj\r\nhe-WI\r\nzg-he\r\npj-fs\r\nstart-RW", 226)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day12(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("\r\n", -1)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day12(input).SolvePart2());
        }
    }
}