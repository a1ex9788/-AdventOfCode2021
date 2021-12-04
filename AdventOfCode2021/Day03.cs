using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day03 : Solver
    {
        private readonly IEnumerable<string> numbers;

        public Day03(string input)
        {
            this.numbers = input.Split("\r\n");
        }

        public override long SolvePart1()
        {
            string gammaRateInBinary = CalculateGammaRate(this.numbers);
            string epsilonRateInBinary = CalculateEpsilonRate(this.numbers);

            long gammaRate = BinaryToDecimal(long.Parse(gammaRateInBinary));
            long epsilonRate = BinaryToDecimal(long.Parse(epsilonRateInBinary));

            return gammaRate * epsilonRate;
        }

        public override long SolvePart2()
        {
            string oxygenGeneratorRateInBinary = CalculateOxygenGeneratorRate(this.numbers);
            string cO2ScrubberRateInBinary = CalculateCO2ScrubberRate(this.numbers);

            long oxygenGeneratorRate = BinaryToDecimal(long.Parse(oxygenGeneratorRateInBinary));
            long cO2ScrubberRate = BinaryToDecimal(long.Parse(cO2ScrubberRateInBinary));

            return oxygenGeneratorRate * cO2ScrubberRate;
        }

        private static string CalculateGammaRate(IEnumerable<string> numbers, char charToKeepWhenEquallyCommon = '0')
        {
            string gammaRate = "";

            for (int i = 0; i < numbers.ElementAt(0).Length; i++)
            {
                int numberOfZeros = 0;

                foreach (string number in numbers)
                {
                    if (number[i] == '0')
                    {
                        numberOfZeros++;
                    }
                }

                if (numberOfZeros > numbers.Count() / 2)
                {
                    gammaRate += '0';
                }
                else if (numberOfZeros < numbers.Count() / 2)
                {
                    gammaRate += '1';
                }
                else
                {
                    gammaRate += charToKeepWhenEquallyCommon;
                }
            }

            return gammaRate;
        }

        private static string CalculateEpsilonRate(IEnumerable<string> numbers, char charToKeepWhenEquallyCommon = '0')
        {
            string epsilonRate = "";

            for (int i = 0; i < numbers.ElementAt(0).Length; i++)
            {
                int numberOfZeros = 0;

                foreach (string number in numbers)
                {
                    if (number[i] == '0')
                    {
                        numberOfZeros++;
                    }
                }

                if (numberOfZeros < numbers.Count() / 2)
                {
                    epsilonRate += '0';
                }
                else if (numberOfZeros > numbers.Count() / 2)
                {
                    epsilonRate += '1';
                }
                else
                {
                    epsilonRate += charToKeepWhenEquallyCommon;
                }
            }

            return epsilonRate;
        }

        private string CalculateOxygenGeneratorRate(IEnumerable<string> numbers)
        {
            bool MostCommonCriteria(IEnumerable<string> candidates, string candidate, int i)
            {
                string gammaRateInBinary = CalculateGammaRate(candidates, '1');

                return candidate[i] == gammaRateInBinary[i];
            }

            return FindLastNumberMeetingCriteria(numbers, MostCommonCriteria);
        }

        private string CalculateCO2ScrubberRate(IEnumerable<string> numbers)
        {
            bool LeastCommonCriteria(IEnumerable<string> candidates, string candidate, int i)
            {
                string epsilonRateInBinary = CalculateEpsilonRate(candidates, '0');

                return candidate[i] == epsilonRateInBinary[i];
            }

            return FindLastNumberMeetingCriteria(numbers, LeastCommonCriteria);
        }

        private string FindLastNumberMeetingCriteria(IEnumerable<string> numbers, Func<IEnumerable<string>, string, int, bool> criteria)
        {
            List<string> candidates = numbers.ToList();

            for (int i = 0; i < numbers.ElementAt(0).Length && candidates.Count > 1; i++)
            {
                IEnumerable<string> candidatesCopy = candidates.ToList();

                foreach (string candidate in candidatesCopy)
                {
                    if (!criteria.Invoke(candidatesCopy, candidate, i))
                    {
                        candidates.Remove(candidate);
                    }
                }
            }

            return candidates.First();
        }

        private static long BinaryToDecimal(long binary)
        {
            long number = 0, digit;
            const long DIVISOR = 10;

            for (long i = binary, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digit = (long)i % DIVISOR;

                if (digit != 1 && digit != 0)
                {
                    return -1;
                }

                number += digit * (long)Math.Pow(2, j);
            }

            return number;
        }
    }
}