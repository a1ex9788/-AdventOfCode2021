using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class DayXXTests : Tester
    {
        protected override Solver Solver => new DayXX(Resources.DayXXInput);

        protected override string Part1Output => Resources.DayXXPart1Output;
        protected override string Part2Output => Resources.DayXXPart2Output;

        [TestMethod]
        [DataRow("\r\n", -1)]
        public void SolvePart1Test(string numbersList, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new DayXX(numbersList).SolvePart1());
        }
    }
}