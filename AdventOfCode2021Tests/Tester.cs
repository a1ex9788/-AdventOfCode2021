using AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public abstract class Tester
    {
        protected abstract Solver Solver { get; }

        protected abstract string Part1Output { get; }
        protected abstract string Part2Output { get; }

        [TestMethod]
        public void Part1Test()
        {
            Assert.AreEqual(Convert.ToInt64(this.Part1Output), this.Solver.SolvePart1());
        }

        [TestMethod]
        public void Part2Test()
        {
            Assert.AreEqual(Convert.ToInt64(this.Part2Output), this.Solver.SolvePart2());
        }
    }
}