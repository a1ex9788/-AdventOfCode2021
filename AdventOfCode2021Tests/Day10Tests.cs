using AdventOfCode2021;
using AdventOfCode2021Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day10Tests : Tester
    {
        protected override Solver Solver => new Day10(Resources.Day10Input);

        protected override string Part1Output => Resources.Day10Part1Output;
        protected override string Part2Output => Resources.Day10Part2Output;

        [TestMethod]
        [DataRow("[({(<(())[]>[[{[]{<()<>>\r\n[(()[<>])]({[<{<<[]>>(\r\n{([(<{}[<>[]}>{[]{[(<()>\r\n(((({<>}<{<{<>}{[]{[]{}\r\n[[<[([]))<([[{}[[()]]]\r\n[{[{({}]{}}([{[{{{}}([]\r\n{<[[]]>}<{[{[{[]{()[[[]\r\n[<(<(<(<{}))><([]([]()\r\n<{([([[(<>()){}]>(<<{{\r\n<{([{{}}[<[[[<>{}]]]>[]]", 26397)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day10(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("[({(<(())[]>[[{[]{<()<>>\r\n[(()[<>])]({[<{<<[]>>(\r\n{([(<{}[<>[]}>{[]{[(<()>\r\n(((({<>}<{<{<>}{[]{[]{}\r\n[[<[([]))<([[{}[[()]]]\r\n[{[{({}]{}}([{[{{{}}([]\r\n{<[[]]>}<{[{[{[]{()[[[]\r\n[<(<(<(<{}))><([]([]()\r\n<{([([[(<>()){}]>(<<{{\r\n<{([{{}}[<[[[<>{}]]]>[]]", 288957)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day10(input).SolvePart2());
        }
    }
}