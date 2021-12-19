using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day14 : Solver
    {
        private readonly string polymerRate;
        private readonly IEnumerable<PairInsertion> pairInsertions;

        public Day14(string input)
        {
            string[] polymerRateAndPairInsertions = input.Split("\r\n\r\n");

            this.polymerRate = polymerRateAndPairInsertions[0];
            this.pairInsertions = polymerRateAndPairInsertions[1].Split("\r\n").Select(prapi =>
            {
                string[] elementsAndResult = prapi.Split(" -> ");

                return new PairInsertion()
                {
                    FirstElement = elementsAndResult[0][0],
                    SecondElement = elementsAndResult[0][1],
                    Result = elementsAndResult[1][0],
                };
            });
        }

        public override long SolvePart1()
        {
            string currentPolymer = this.polymerRate.Clone() as string;

            for (int i = 0; i < 10; i++)
            {
                currentPolymer = SimulateOneStep(currentPolymer);
            }

            Dictionary<char, int> elementOcurrencies = new Dictionary<char, int>();

            foreach (char element in this.pairInsertions.Select(pi => pi.Result).Distinct())
            {
                elementOcurrencies.Add(element, currentPolymer.Where(cp => cp == element).Count());
            }

            return elementOcurrencies.Max(eo => eo.Value) - elementOcurrencies.Min(eo => eo.Value);
        }

        public override long SolvePart2()
        {
            return 0;
        }

        private string SimulateOneStep(string initialPolymer)
        {
            string nextPolymer = "";

            for (int i = 0; i < initialPolymer.Length - 1; i++)
            {
                nextPolymer += initialPolymer[i] + "" + GetElementResult(initialPolymer[i], initialPolymer[i + 1]);
            }

            return nextPolymer + initialPolymer[initialPolymer.Length - 1];
        }

        private char GetElementResult(char firstElement, char secondElement)
        {
            return this.pairInsertions.First(pi => pi.FirstElement == firstElement
                && pi.SecondElement == secondElement).Result;
        }

        private class PairInsertion
        {
            public char FirstElement, SecondElement;
            public char Result;
        }
    }
}