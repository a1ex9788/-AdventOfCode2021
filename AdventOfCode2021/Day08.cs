using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day08 : Solver
    {
        private readonly IEnumerable<Pattern> patterns;

        public Day08(string input)
        {
            this.patterns = input.Split("\r\n").Select(i =>
            {
                string[] wiresAndSegments = i.Split(" | ");

                return new Pattern()
                {
                    Wires = wiresAndSegments[0].Split(' '),
                    Segments = wiresAndSegments[1].Split(' '),
                };
            });
        }

        public override long SolvePart1()
        {
            IEnumerable<string> numbersOcurrenciesWithUniqueNumberOfSegments =
                this.patterns.SelectMany(p => p.Segments.Where(s => HasUniqueNumberOfSegments(s)));

            return numbersOcurrenciesWithUniqueNumberOfSegments.Count();
        }

        public override long SolvePart2()
        {
            string possibleWires = "abcdefg";
            long sum = 0;

            foreach (Pattern pattern in this.patterns)
            {
                IDictionary<string, int> combinations = new Dictionary<string, int>();

                string oneWiresCombination = pattern.Wires.First(w => w.Count() == 2);
                string fourWiresCombination = pattern.Wires.First(w => w.Count() == 4);
                string sevenWiresCombination = pattern.Wires.First(w => w.Count() == 3);
                string eightWiresCombination = pattern.Wires.First(w => w.Count() == 7);

                combinations[oneWiresCombination] = 1;
                combinations[fourWiresCombination] = 4;
                combinations[sevenWiresCombination] = 7;
                combinations[eightWiresCombination] = 8;

                char wireForSegmentA = possibleWires.First(pw =>
                    !oneWiresCombination.Contains(pw)
                    && !fourWiresCombination.Contains(pw)
                    && sevenWiresCombination.Contains(pw)
                    && eightWiresCombination.Contains(pw));

                IEnumerable<string> unknownPatterns = pattern.Wires.Except(new List<string>()
                {
                    oneWiresCombination,
                    fourWiresCombination,
                    sevenWiresCombination,
                    eightWiresCombination,
                });

                IEnumerable<char> commonWiresInUnknownDigits = possibleWires.Where(pw => unknownPatterns.All(up => up.Contains(pw)));

                char wireForSegmentG = commonWiresInUnknownDigits.First(cwiud => cwiud != wireForSegmentA);

                string nineWiresCombination = pattern.Wires.First(w => w.Count() == 6
                    && w.All(c => (fourWiresCombination + wireForSegmentA + wireForSegmentG).Contains(c)));
                combinations[nineWiresCombination] = 9;
                unknownPatterns = unknownPatterns.Except(new List<string>() { nineWiresCombination });

                char wireForSegmentE = eightWiresCombination.First(w => !nineWiresCombination.Contains(w));

                string twoWiresCombination = unknownPatterns.First(up => up.Length == 5
                    && up.Contains(wireForSegmentE));
                combinations[twoWiresCombination] = 2;
                unknownPatterns = unknownPatterns.Except(new List<string>() { twoWiresCombination });

                char wireForSegmentB = possibleWires.First(pw => !(oneWiresCombination + twoWiresCombination).Contains(pw));

                string threeWiresCombination = unknownPatterns.First(up => up.Length == 5
                    && !up.Contains(wireForSegmentB));
                combinations[threeWiresCombination] = 3;
                unknownPatterns = unknownPatterns.Except(new List<string>() { threeWiresCombination });

                string fiveWiresCombination = unknownPatterns.First(up => up.Length == 5);
                combinations[fiveWiresCombination] = 5;
                unknownPatterns = unknownPatterns.Except(new List<string>() { fiveWiresCombination });

                string zeroWiresCombination = unknownPatterns.First(up => oneWiresCombination.All(owc => up.Contains(owc)));
                combinations[zeroWiresCombination] = 0;
                unknownPatterns = unknownPatterns.Except(new List<string>() { zeroWiresCombination });

                string sixWiresCombination = unknownPatterns.First();
                combinations[sixWiresCombination] = 6;

                int renderedNumber = 0;

                int numberOfDigits = pattern.Segments.Count();

                for (int i = 0; i < numberOfDigits; i++)
                {
                    string currentString = pattern.Segments.ElementAt(i);

                    string key = combinations.Keys.First(k => k.Length == currentString.Length
                        && k.All(c => currentString.Contains(c)));

                    renderedNumber += combinations[key] * (int)Math.Pow(10, numberOfDigits - i - 1);
                }

                sum += renderedNumber;
            }

            return sum;
        }

        private static bool HasUniqueNumberOfSegments(string segment)
        {
            switch (segment.Length)
            {
                // Number 1.
                case 2:
                    return true;
                // Number 4.
                case 4:
                    return true;
                // Number 7.
                case 3:
                    return true;
                // Number 8.
                case 7:
                    return true;

                default:
                    return false;
            }
        }

        private class Pattern
        {
            public IEnumerable<string> Wires;
            public IEnumerable<string> Segments;
        }
    }
}