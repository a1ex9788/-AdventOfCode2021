using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day12 : Solver
    {
        private readonly IEnumerable<(string P1, string P2)> connections;

        public Day12(string input)
        {
            this.connections = input.Split("\r\n").Select(i =>
            {
                string[] path = i.Split('-');

                return (path[0], path[1]);
            });
        }

        public override long SolvePart1()
        {
            IEnumerable<string> possiblePaths = this.CalculateAllPossiblePaths();

            return possiblePaths.Count();
        }

        public override long SolvePart2()
        {
            return 0;
        }

        private IEnumerable<string> CalculateAllPossiblePaths()
        {
            List<Path> possiblePaths = new List<Path>() { new Path() };
            List<string> visitedSmallCaves = new List<string>();
            int numberOfEmptyIterations = 0;

            do
            {
                foreach (Path notEndedPath in possiblePaths.Where(pp => !pp.Ended()).ToList())
                {
                    string lastPoint = notEndedPath.Points.Last();

                    IEnumerable<string> reachablePoints = this.GetReachablePoints(lastPoint);

                    bool newPathAdded = false;

                    foreach (string reachablePoint in reachablePoints.Except(new List<string>() { "start" }))
                    {
                        Path newPath = notEndedPath.Clone();
                        newPath.Points.Add(reachablePoint);

                        if (!possiblePaths.Any(pp => newPath.SameOrLongerPath(pp)))
                        {
                            if (IsSmallCave(reachablePoint))
                            {
                                if (!visitedSmallCaves.Contains(reachablePoint))
                                {
                                    possiblePaths.Add(newPath);
                                    newPathAdded = true;

                                    visitedSmallCaves.Add(reachablePoint);
                                }
                            }
                            else
                            {
                                possiblePaths.Add(newPath);
                                newPathAdded = true;
                            }
                        }
                    }

                    if (newPathAdded)
                    {
                        possiblePaths.Remove(notEndedPath);
                    }
                    else
                    {
                        if (++numberOfEmptyIterations == 10)
                        {
                            return possiblePaths.Select(pp => pp.ToString());
                        }
                    }
                }
            }
            while (possiblePaths.Any(pp => !pp.Ended()));

            return possiblePaths.Select(pp => pp.ToString());
        }

        private IEnumerable<string> GetReachablePoints(string currentPoint)
        {
            List<string> reachablePoints = new List<string>();

            foreach ((string p1, string p2) in this.connections)
            {
                if (p1 == currentPoint)
                {
                    reachablePoints.Add(p2);
                }
                else if (p2 == currentPoint)
                {
                    reachablePoints.Add(p1);
                }
            }

            return reachablePoints;
        }

        private bool IsSmallCave(string possibleSmallCave)
        {
            return possibleSmallCave != "start" && possibleSmallCave.All(c => char.IsLower(c));
        }

        private class Path
        {
            public List<string> Points = new List<string>() { "start" };

            public override string ToString()
            {
                string toString = "";

                foreach (string point in this.Points)
                {
                    toString += point + ',';
                }

                return toString.Remove(toString.Length - 1);
            }

            public bool Ended()
            {
                return Points.Last() == "end";
            }

            public Path Clone()
            {
                return new Path
                {
                    Points = this.Points.ToList()
                };
            }

            public bool SameOrLongerPath(Path anotherPath)
            {
                if (this.Points.Count() > anotherPath.Points.Count())
                {
                    return false;
                }

                for (int i = 0; i < this.Points.Count(); i++)
                {
                    if (this.Points[i] != anotherPath.Points[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}