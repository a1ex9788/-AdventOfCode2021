using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day09 : Solver
    {
        private readonly int[,] points;

        public Day09(string input)
        {
            string[] rows = input.Split("\r\n");

            this.points = new int[rows[0].Length, rows.Length];

            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = 0; x < rows[y].Length; x++)
                {
                    this.points[x, y] = int.Parse(rows[y][x] + "");
                }
            }
        }

        public override long SolvePart1()
        {
            List<(int x, int y)> lowPoints = CalculateLowPoints();

            return lowPoints.Sum(lp => CalculateRiskLevel(this.points[lp.x, lp.y]));
        }

        public override long SolvePart2()
        {
            List<(int x, int y)> lowPoints = CalculateLowPoints();

            IEnumerable<int> sizesOfThreeLargestBasins = lowPoints.Select(lp => CalculateBasinSize(lp.x, lp.y)).ToList().OrderByDescending(bs => bs).Take(3);

            return sizesOfThreeLargestBasins.ElementAt(0) * sizesOfThreeLargestBasins.ElementAt(1) * sizesOfThreeLargestBasins.ElementAt(2);
        }

        private List<(int x, int y)> CalculateLowPoints()
        {
            List<(int x, int y)> lowPoints = new List<(int x, int y)>();

            for (int x = 0; x < this.points.GetLength(0); x++)
            {
                for (int y = 0; y < this.points.GetLength(1); y++)
                {
                    int currentPointHeight = this.points[x, y];

                    bool PointIsLower(int x, int y)
                    {
                        return ExistsPoint(x, y) && this.points[x, y] <= currentPointHeight;
                    }

                    if (PointIsLower(x + 1, y)
                        || PointIsLower(x - 1, y)
                        || PointIsLower(x, y + 1)
                        || PointIsLower(x, y - 1))
                    {
                        continue;
                    }

                    lowPoints.Add((x, y));
                }
            }

            return lowPoints;
        }

        private bool ExistsPoint(int x, int y)
        {
            return 0 <= x && x < this.points.GetLength(0)
                && 0 <= y && y < this.points.GetLength(1);
        }

        private static int CalculateRiskLevel(int height)
        {
            return height + 1;
        }

        private int CalculateBasinSize(int a, int b)
        {
            List<(int x, int y)> pointsInBasinToAnalyse = new List<(int x, int y)>() { (a, b) };

            int basinSize = 1;
            int wantedHeight = this.points[a, b] + 1;

            do
            {
                List<(int x, int y)> currentPointsToAnalyse = pointsInBasinToAnalyse.ToList();
                pointsInBasinToAnalyse = new List<(int x, int y)>();

                foreach ((int x, int y) in currentPointsToAnalyse)
                {
                    void IncludePointInBasinIfNecessary(int x, int y)
                    {
                        if (ExistsPoint(x, y) && this.points[x, y] == wantedHeight)
                        {
                            (int x, int y) pointToAdd = (x, y);

                            if (!pointsInBasinToAnalyse.Contains(pointToAdd))
                            {
                                pointsInBasinToAnalyse.Add(pointToAdd);
                            }
                        }
                    }

                    IncludePointInBasinIfNecessary(x + 1, y);
                    IncludePointInBasinIfNecessary(x - 1, y);
                    IncludePointInBasinIfNecessary(x, y + 1);
                    IncludePointInBasinIfNecessary(x, y - 1);
                }

                basinSize += pointsInBasinToAnalyse.Count();
                wantedHeight++;
            }
            while (pointsInBasinToAnalyse.Any() && wantedHeight < 9);

            return basinSize;
        }
    }
}