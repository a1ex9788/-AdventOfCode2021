using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day13 : Solver
    {
        private readonly IEnumerable<(int X, int Y)> points;
        private readonly IEnumerable<Fold> folds;

        public Day13(string input)
        {
            string[] pointsAndFolds = input.Split("\r\n\r\n");

            this.points = pointsAndFolds[0].Split("\r\n").Select(paf =>
            {
                string[] points = paf.Split(',');

                return (int.Parse(points[0]), int.Parse(points[1]));
            });

            this.folds = pointsAndFolds[1].Split("\r\n").Select(paf =>
            {
                Match match = Regex.Match(paf, @"fold along (\w)=(\d*)");

                return new Fold()
                {
                    Coordinate = match.Groups[1].Value == "x" ? Coordinate.X : Coordinate.Y,
                    Number = int.Parse(match.Groups[2].Value),
                };
            });
        }

        public override long SolvePart1()
        {
            Fold firstFold = folds.First();

            return ApplyFoldAndGetPoints(this.points, firstFold).Count();
        }

        public override long SolvePart2()
        {
            List<(int X, int Y)> currentPoints = this.points.ToList();

            foreach (Fold fold in this.folds)
            {
                currentPoints = ApplyFoldAndGetPoints(currentPoints, fold).ToList();
            }

            bool[,] points = new bool[39, 6];

            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    if (currentPoints.Contains((i, j)))
                    {
                        points[i, j] = true;
                    }
                }
            }

            string code = "";

            for (int j = 0; j < points.GetLength(1); j++)
            {
                for (int i = 0; i < points.GetLength(0); i++)
                {
                    code += points[i, j] ? '#' : '.';
                }

                code += "\n";
            }

            Console.WriteLine(code);

            return currentPoints.Count();
        }

        private static IEnumerable<(int X, int Y)> ApplyFoldAndGetPoints(IEnumerable<(int X, int Y)> initialPoints, Fold firstFold)
        {
            List<(int X, int Y)> currentPoints = new List<(int X, int Y)>();

            if (firstFold.Coordinate == Coordinate.X)
            {
                foreach ((int x, int y) in initialPoints.ToList())
                {
                    if (x < firstFold.Number)
                    {
                        (int, int) currentPoint = (x, y);

                        if (!currentPoints.Contains(currentPoint))
                        {
                            currentPoints.Add(currentPoint);
                        }
                    }
                    else
                    {
                        (int, int) newPoint = (x - 2 * (x - firstFold.Number), y);

                        if (!currentPoints.Contains(newPoint))
                        {
                            currentPoints.Add(newPoint);
                        }
                    }
                }
            }
            else
            {
                foreach ((int x, int y) in initialPoints.ToList())
                {
                    if (y < firstFold.Number)
                    {
                        (int, int) currentPoint = (x, y);

                        if (!currentPoints.Contains(currentPoint))
                        {
                            currentPoints.Add(currentPoint);
                        }
                    }
                    else
                    {
                        (int, int) newPoint = (x, y - 2 * (y - firstFold.Number));

                        if (!currentPoints.Contains(newPoint))
                        {
                            currentPoints.Add(newPoint);
                        }
                    }
                }
            }

            return currentPoints;
        }

        private class Fold
        {
            public Coordinate Coordinate;
            public int Number;
        }

        private enum Coordinate
        {
            X, Y
        }
    }
}