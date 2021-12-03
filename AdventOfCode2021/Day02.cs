using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day02 : Solver
    {
        private readonly IEnumerable<(string Direction, int Value)> commands;

        public Day02(string input)
        {
            this.commands = input.Split("\r\n").Select(i =>
            {
                Match match = Regex.Match(i, @"(\w*)\s(\d)");

                return (match.Groups[1].Value, int.Parse(match.Groups[2].Value));
            });
        }

        public override long SolvePart1()
        {
            int horizontalPosition = 0, depth = 0;

            foreach ((string direction, int value) in this.commands)
            {
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += value;
                        break;

                    case "down":
                        depth += value;
                        break;

                    case "up":
                        depth -= value;
                        break;
                }
            }

            return horizontalPosition * depth;
        }

        public override long SolvePart2()
        {
            int horizontalPosition = 0, depth = 0, aim = 0;

            foreach ((string direction, int value) in this.commands)
            {
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += value;
                        depth += aim * value;
                        break;

                    case "down":
                        aim += value;
                        break;

                    case "up":
                        aim -= value;
                        break;
                }
            }

            return horizontalPosition * depth;
        }
    }
}