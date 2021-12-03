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
            int lasDepthMeasurement = int.MaxValue;

            foreach (int depthMeasurement in this.depthMeasurements)
            {
                if (lasDepthMeasurement < depthMeasurement)
                {
                    numberOfTimesDepthMeasurementIncreases++;
                }

                lasDepthMeasurement = depthMeasurement;
            }

            return numberOfTimesDepthMeasurementIncreases;
        }

        public override long SolvePart2()
        {
            return -1;
        }
    }
}