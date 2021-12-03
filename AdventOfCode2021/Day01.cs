using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day01 : Solver
    {
        private readonly IEnumerable<int> depthMeasurements;

        public Day01(string input)
        {
            this.depthMeasurements = input.Split("\r\n").Select(i => int.Parse(i));
        }

        public override long SolvePart1()
        {
            int numberOfTimesDepthMeasurementIncreases = 0;
            int lastDepthMeasurement = int.MaxValue;

            foreach (int depthMeasurement in this.depthMeasurements)
            {
                if (lastDepthMeasurement < depthMeasurement)
                {
                    numberOfTimesDepthMeasurementIncreases++;
                }

                lastDepthMeasurement = depthMeasurement;
            }

            return numberOfTimesDepthMeasurementIncreases;
        }

        public override long SolvePart2()
        {
            int numberOfTimesSumOfMeasurementsInSlidingWindowIncreases = 0;
            int lastSum = int.MaxValue;

            for (int i = 2; i < this.depthMeasurements.Count(); i++)
            {
                int currentSum = depthMeasurements.ElementAt(i)
                    + depthMeasurements.ElementAt(i - 1)
                    + depthMeasurements.ElementAt(i - 2);

                if (lastSum < currentSum)
                {
                    numberOfTimesSumOfMeasurementsInSlidingWindowIncreases++;
                }

                lastSum = currentSum;
            }

            return numberOfTimesSumOfMeasurementsInSlidingWindowIncreases;
        }
    }
}