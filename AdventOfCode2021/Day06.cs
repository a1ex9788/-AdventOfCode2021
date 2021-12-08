using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day06 : Solver
    {
        private readonly IEnumerable<int> fishes;

        private const int ResetPeriod = 7;

        public Day06(string input)
        {
            this.fishes = input.Split(',').Select(i => int.Parse(i));
        }

        public override long SolvePart1()
        {
            return 0;

            long numberOfFishes = 0;

            for (int fish = 0; fish < fishes.Count(); fish++)
            {
                numberOfFishes += CalculateNumberOfFishesInNDays(fishes.ElementAt(fish), 80);
            }

            return numberOfFishes;
        }

        private static long CalculateNumberOfFishesInNDays(int initialFishState, int numberOfDays)
        {
            if (numberOfDays < initialFishState)
            {
                return 1;
            }

            int numberOfCompletedPeriods = numberOfDays / ResetPeriod;
            int numberOfLeftDaysForPeriod = numberOfDays % ResetPeriod;

            long numberOfFishes = 0;

            for (int d = numberOfDays; d > 0; d -= ResetPeriod)
            {
                numberOfFishes += CalculateNumberOfFishesInNDays(8, d);
            }

            return numberOfFishes;
        }

        public override long SolvePart2()
        {
            return 0;
        }
    }
}