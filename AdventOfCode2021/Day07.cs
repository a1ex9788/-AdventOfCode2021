using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day07 : Solver
    {
        private readonly IEnumerable<int> horizontalPositions;

        public Day07(string input)
        {
            this.horizontalPositions = input.Split(',').Select(i => int.Parse(i));
        }

        public override long SolvePart1()
        {
            int median = CalculateMedian(horizontalPositions);

            return CalculateFuel(median);

            long CalculateFuel(int selectedPosition)
            {
                return this.horizontalPositions.Select(hp => Math.Abs(hp - selectedPosition)).Sum();
            }
        }

        public override long SolvePart2()
        {
            double average = CalculateAverage(horizontalPositions);

            long a = CalculateFuel((int)Math.Floor(average));
            long b = CalculateFuel((int)Math.Ceiling(average));

            return Math.Min(a, b);

            long CalculateFuel(int selectedPosition)
            {
                return this.horizontalPositions.Select(hp => CalculateSumatorian(Math.Abs(hp - selectedPosition))).Sum();
            }
        }

        private static int CalculateMedian(IEnumerable<int> numbers)
        {
            int[] numbersCopy = numbers.ToArray();

            Array.Sort(numbersCopy);

            return numbersCopy[numbersCopy.Length / 2];
        }

        private static double CalculateAverage(IEnumerable<int> numbers)
        {
            return (double)numbers.Sum() / numbers.Count();
        }

        private static int CalculateSumatorian(int number)
        {
            int sumatorian = 0;

            for (int i = 0; i <= number; i++)
            {
                sumatorian += i;
            }

            return sumatorian;
        }
    }
}