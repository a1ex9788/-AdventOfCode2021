﻿using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day01Tests : Tester
    {
        protected override Solver Solver => new Day01(Resources.Day01Input);

        protected override string Part1Output => Resources.Day01Part1Output;
        protected override string Part2Output => Resources.Day01Part2Output;

        [TestMethod]
        [DataRow("199\r\n200\r\n208\r\n210\r\n200\r\n207\r\n240\r\n269\r\n260\r\n263", 7)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day01(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("607\r\n618\r\n618\r\n617\r\n647\r\n716\r\n769\r\n792", 5)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day01(input).SolvePart2());
        }
    }
}