namespace AdventOfCode2021
{
    public class Day11 : Solver
    {
        private readonly int[,] points;

        private int numberOfFlashes = 0;

        public Day11(string input)
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
            int numberOfStepsToSimulate = 100;

            for (int i = 0; i < numberOfStepsToSimulate; i++)
            {
                this.SimulateOneStep();
            }

            return numberOfFlashes;
        }

        public override long SolvePart2()
        {
            int numberOfStepsSimulated = 0;

            do
            {
                this.SimulateOneStep();

                numberOfStepsSimulated++;
            }
            while (!HasAllZeros());

            return numberOfStepsSimulated;
        }

        private void SimulateOneStep()
        {
            for (int x = 0; x < this.points.GetLength(0); x++)
            {
                for (int y = 0; y < this.points.GetLength(1); y++)
                {
                    this.points[x, y]++;
                }
            }

            bool haveNewPoints;

            do
            {
                haveNewPoints = false;

                for (int x = 0; x < this.points.GetLength(0); x++)
                {
                    for (int y = 0; y < this.points.GetLength(1); y++)
                    {
                        if (this.points[x, y] > 9)
                        {
                            this.points[x, y] = 0;

                            this.numberOfFlashes++;

                            RaisePointIfExistsAndIsNotZero(x + 1, y);
                            RaisePointIfExistsAndIsNotZero(x - 1, y);
                            RaisePointIfExistsAndIsNotZero(x, y + 1);
                            RaisePointIfExistsAndIsNotZero(x, y - 1);
                            RaisePointIfExistsAndIsNotZero(x + 1, y + 1);
                            RaisePointIfExistsAndIsNotZero(x - 1, y - 1);
                            RaisePointIfExistsAndIsNotZero(x + 1, y - 1);
                            RaisePointIfExistsAndIsNotZero(x - 1, y + 1);

                            haveNewPoints = true;
                        }
                    }
                }
            }
            while (haveNewPoints);
        }

        private void RaisePointIfExistsAndIsNotZero(int x, int y)
        {
            if (ExistsPoint(x, y) && this.points[x, y] != 0)
            {
                this.points[x, y]++;
            }
        }

        private bool ExistsPoint(int x, int y)
        {
            return 0 <= x && x < this.points.GetLength(0)
                && 0 <= y && y < this.points.GetLength(1);
        }

        private bool HasAllZeros()
        {
            for (int x = 0; x < this.points.GetLength(0); x++)
            {
                for (int y = 0; y < this.points.GetLength(1); y++)
                {
                    if (this.points[x, y] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}