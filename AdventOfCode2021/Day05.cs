using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day05 : Solver
    {
        private readonly IEnumerable<Line> lines;

        public Day05(string input)
        {
            this.lines = input.Split("\r\n").Select(i =>
            {
                string[] points = i.Split(" -> ");

                string[] firstPoint = points[0].Split(',');
                string[] secondPoint = points[1].Split(',');

                return new Line()
                {
                    X1 = int.Parse(firstPoint[0]),
                    Y1 = int.Parse(firstPoint[1]),
                    X2 = int.Parse(secondPoint[0]),
                    Y2 = int.Parse(secondPoint[1]),
                };
            });
        }

        public override long SolvePart1()
        {
            IEnumerable<Line> horizontalAndVerticalLines = this.lines.Where(l => l.IsHorizontalOrVertical());

            int maxX = horizontalAndVerticalLines.Max(havl => Math.Max(havl.X1, havl.X2)) + 1;
            int maxY = horizontalAndVerticalLines.Max(havl => Math.Max(havl.Y1, havl.Y2)) + 1;

            int[,] diagram = new int[maxX, maxY];

            foreach (Line line in horizontalAndVerticalLines)
            {
                foreach ((int x, int y) in line.GetAllPoints())
                {
                    diagram[x, y]++;
                }
            }

            return CalculateNumberOfPointsWhereTwoLinesOrMoreOverlap(diagram);
        }

        public override long SolvePart2()
        {
            int maxX = this.lines.Max(havl => Math.Max(havl.X1, havl.X2)) + 1;
            int maxY = this.lines.Max(havl => Math.Max(havl.Y1, havl.Y2)) + 1;

            int[,] diagram = new int[maxX, maxY];

            foreach (Line line in this.lines)
            {
                foreach ((int x, int y) in line.GetAllPoints(considerDiagonalLines: true))
                {
                    diagram[x, y]++;
                }
            }

            return CalculateNumberOfPointsWhereTwoLinesOrMoreOverlap(diagram);
        }

        private static long CalculateNumberOfPointsWhereTwoLinesOrMoreOverlap(int[,] diagram)
        {
            int numberOfPointsWhereTwoLinesOrMoreOverlap = 0;

            for (int x = 0; x < diagram.GetLongLength(0); x++)
            {
                for (int y = 0; y < diagram.GetLongLength(1); y++)
                {
                    if (diagram[x, y] >= 2)
                    {
                        numberOfPointsWhereTwoLinesOrMoreOverlap++;
                    }
                }
            }

            return numberOfPointsWhereTwoLinesOrMoreOverlap;
        }

        private class Line
        {
            public int X1, Y1, X2, Y2;

            public bool IsHorizontalOrVertical()
            {
                return X1 == X2 || Y1 == Y2;
            }

            public IEnumerable<(int X, int Y)> GetAllPoints(bool considerDiagonalLines = false)
            {
                List<(int, int)> points = new List<(int, int)>();

                if (X1 == X2 && Y1 != Y2)
                {
                    bool Y1IsLower = Y1 < Y2;
                    int lowEnd = Y1IsLower ? Y1 : Y2;
                    int highEnd = Y1IsLower ? Y2 : Y1;

                    for (int y = lowEnd; y <= highEnd; y++)
                    {
                        points.Add((X1, y));
                    }
                }
                else if (Y1 == Y2 && X1 != X2)
                {
                    bool X1IsLower = X1 < X2;
                    int lowEnd = X1IsLower ? X1 : X2;
                    int highEnd = X1IsLower ? X2 : X1;

                    for (int x = lowEnd; x <= highEnd; x++)
                    {
                        points.Add((x, Y1));
                    }
                }
                else
                {
                    bool X1IsLower = X1 < X2;
                    bool Y1IsLower = Y1 < Y2;

                    int xIncrement = X1IsLower ? 1 : -1;
                    int yIncrement = Y1IsLower ? 1 : -1;

                    for (int x = X1, y = Y1; x != X2 + xIncrement; x += xIncrement, y += yIncrement)
                    {
                        points.Add((x, y));
                    }
                }

                return points.Distinct();
            }
        }
    }
}