using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day04 : Solver
    {
        private readonly IEnumerable<int> numbers;
        private readonly IEnumerable<Board> boards;

        public Day04(string input)
        {
            IEnumerable<string> numbersAndBoards = input.Split("\r\n");

            this.numbers = numbersAndBoards.ElementAt(0).Split(',').Select(i => int.Parse(i));

            List<Board> boards = new List<Board>();

            for (int i = 2; i < numbersAndBoards.Count(); i += 6)
            {
                // TODO: Creation of boards should be encapsulated in the class.
                Board board = new Board();

                for (int j = 0; j < 5; j++)
                {
                    IEnumerable<int> row = numbersAndBoards.ElementAt(i + j).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i));

                    int[] convertedRow = new int[]
                    {
                        row.ElementAt(0),
                        row.ElementAt(1),
                        row.ElementAt(2),
                        row.ElementAt(3),
                        row.ElementAt(4),
                    };

                    board.Numbers[j] = convertedRow.Select(i => new BingoNumber() { Number = i }).ToArray();
                }

                boards.Add(board);
            }

            this.boards = boards;
        }

        public override long SolvePart1()
        {
            bool exit = false;

            Board winnerBoard = null;
            int lastNumberCalled = 0;

            foreach (int number in this.numbers)
            {
                foreach (Board board in this.boards)
                {
                    board.MarkNumberIfExists(number);

                    if (board.Won())
                    {
                        winnerBoard = board;
                        lastNumberCalled = number;

                        exit = true;
                        break;
                    }
                }

                if (exit)
                {
                    break;
                }
            }

            long sumOfUnmarkedNumbers = winnerBoard.CalculateSumOfUnmarkedNumbers();

            return sumOfUnmarkedNumbers * lastNumberCalled;
        }

        public override long SolvePart2()
        {
            bool exit = false;

            Board lastWinnerBoard = null;
            int lastNumberCalled = 0;

            int numberOfWonBoards = 0;

            foreach (int number in this.numbers)
            {
                foreach (Board board in this.boards)
                {
                    board.MarkNumberIfExists(number);

                    if (board.Won() && !board.MarkedAsWon)
                    {
                        board.MarkAsWon();

                        if (++numberOfWonBoards == this.boards.Count())
                        {
                            lastWinnerBoard = board;
                            lastNumberCalled = number;

                            exit = true;
                            break;
                        }
                    }
                }

                if (exit)
                {
                    break;
                }
            }

            long sumOfUnmarkedNumbers = lastWinnerBoard.CalculateSumOfUnmarkedNumbers();

            return sumOfUnmarkedNumbers * lastNumberCalled;
        }

        private class Board
        {
            public BingoNumber[][] Numbers = new BingoNumber[5][];
            public bool MarkedAsWon;

            public void MarkNumberIfExists(int number)
            {
                foreach (BingoNumber[] row in this.Numbers)
                {
                    foreach (BingoNumber bingoNumber in row)
                    {
                        if (bingoNumber.Number == number)
                        {
                            bingoNumber.Mark();
                        }
                    }
                }
            }

            public bool Won()
            {
                foreach (BingoNumber[] row in this.Numbers)
                {
                    if (row.All(bn => bn.Marked))
                    {
                        return true;
                    }
                }

                for (int i = 0; i < this.Numbers.ElementAt(0).Length; i++)
                {
                    if (this.Numbers.All(n => n[i].Marked))
                    {
                        return true;
                    }
                }

                return false;
            }

            public long CalculateSumOfUnmarkedNumbers()
            {
                long sum = 0;

                foreach (BingoNumber[] row in this.Numbers)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (!row[i].Marked)
                        {
                            sum += row[i].Number;
                        }
                    }
                }

                return sum;
            }

            internal void MarkAsWon()
            {
                this.MarkedAsWon = true;
            }
        }

        private class BingoNumber
        {
            public int Number;
            public bool Marked { get; private set; }

            internal void Mark()
            {
                this.Marked = true;
            }
        }
    }
}