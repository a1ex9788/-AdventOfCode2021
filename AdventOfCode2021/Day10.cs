using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day10 : Solver
    {
        private readonly IEnumerable<string> lines;

        public Day10(string input)
        {
            this.lines = input.Split("\r\n");
        }

        public override long SolvePart1()
        {
            int syntaxErrorScore = 0;

            foreach (string line in this.lines)
            {
                char firstIllegalChar = GetFirstIllegalChar(line);

                if (firstIllegalChar == default)
                {
                    continue;
                }

                switch (firstIllegalChar)
                {
                    case ')':
                        syntaxErrorScore += 3;
                        break;

                    case ']':
                        syntaxErrorScore += 57;
                        break;

                    case '}':
                        syntaxErrorScore += 1197;
                        break;

                    case '>':
                        syntaxErrorScore += 25137;
                        break;

                    default:
                        throw new Exception("Char not permitted.");
                }
            }

            return syntaxErrorScore;
        }

        public override long SolvePart2()
        {
            List<long> scores = new List<long>();

            foreach (string line in this.lines)
            {
                char firstIllegalChar = GetFirstIllegalChar(line);

                if (firstIllegalChar != default)
                {
                    continue;
                }

                string lineCompletion = CalculateCompletion(line);
                long score = 0;

                foreach (char c in lineCompletion)
                {
                    switch (c)
                    {
                        case ')':
                            score = score * 5 + 1;
                            break;

                        case ']':
                            score = score * 5 + 2;
                            break;

                        case '}':
                            score = score * 5 + 3;
                            break;

                        case '>':
                            score = score * 5 + 4;
                            break;

                        default:
                            throw new Exception("Char not permitted.");
                    }
                }

                scores.Add(score);
            }

            long[] sortedScores = scores.ToArray();
            Array.Sort(sortedScores);

            return sortedScores[sortedScores.Length / 2];
        }

        private static char GetFirstIllegalChar(string line)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (IsOpeningChar(line[i]))
                {
                    stack.Push(line[i]);
                }
                else
                {
                    char lastChar = stack.Pop();

                    if (!AreOppositeChars(lastChar, line[i]))
                    {
                        return line[i];
                    }
                }
            }

            return default;
        }

        private static bool IsOpeningChar(char c)
        {
            return c == '(' || c == '[' || c == '{' || c == '<';
        }

        private static bool AreOppositeChars(char openingChar, char closingChar)
        {
            return GetOppositeChar(openingChar) == closingChar;
        }

        private static char GetOppositeChar(char openingChar)
        {
            switch (openingChar)
            {
                case '(':
                    return ')';

                case '[':
                    return ']';

                case '{':
                    return '}';

                case '<':
                    return '>';

                default:
                    throw new Exception("Char not permitted.");
            }
        }

        private static string CalculateCompletion(string line)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (IsOpeningChar(line[i]))
                {
                    stack.Push(line[i]);
                }
                else
                {
                    stack.Pop();
                }
            }

            string completion = "";

            foreach (char c in stack)
            {
                completion += GetOppositeChar(c);
            }

            return completion;
        }
    }
}