using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> drawnNumbers = new List<string>();
            string[] boardNumbers = new string[25];
            string[] tempArray;
            int counter = 0;
            int boardCounter = 0;
            
            List<Board> Boards = new List<Board>();

            // Read input file
            // get drawnNumbers and populate list of boards
            foreach(string line in System.IO.File.ReadLines("input.txt"))
            {
                if(counter == 0) {
                    // Get drawn numbers
                    drawnNumbers = line.Split(',').ToList<string>();
                    //Console.WriteLine("[{0}]", string.Join(", ", drawnNumbers));
                } else {
                    if(line != "") {
                        tempArray = line.Split(' ');
                        
                        int i = 0;
                        foreach(string value in tempArray) {
                            if(!String.IsNullOrEmpty(value)) {
                                boardNumbers[i+5*boardCounter] = value;
                                i++;
                            }
                        }

                        boardCounter++;

                        if(boardCounter==5) {
                            //Console.WriteLine("[{0}]", string.Join(", ", boardNumbers));
                            // create new board and add to boards list
                            Boards.Add(new Board(boardNumbers));

                            // clear board tracking variables
                            Array.Clear(boardNumbers, 0,boardNumbers.Length);
                            boardCounter = 0;
                        }
                    }
                }
                counter++;
            }

            // Determine winning board
            int result = bingobingo(drawnNumbers, Boards);
            Console.WriteLine($"Result: {result}");
            // Calculate score
            // Sum of unmarked numbers multiplied by last number called

            // Part 2: Last winning board
            int lastWinBoardResult = letTheSquidWin(drawnNumbers, Boards);
            Console.WriteLine($"lastWinBoard result: {lastWinBoardResult}");

        }

        private static int bingobingo(List<String> drawnNumbers, List<Board> Boards) {
            foreach(string number in drawnNumbers) {
                // Console.Write(Environment.NewLine);
                // Console.WriteLine($"Checking number {number}...");
                for(int i = 0; i < Boards.Count(); i++) {
                    // Console.Write(Environment.NewLine);
                    // Console.WriteLine($"Checking board {i}...");
                    if(Boards[i].checkNumber(number)) {
                        // calculate board if board wins
                        return Boards[i].calcBoard() * Convert.ToInt32(number);
                    }
                }
                //Console.ReadLine();
            }
            return -1;
        }

        private static int letTheSquidWin(List<String> drawnNumbers, List<Board> Boards) {
            List<int> winningBoards = new List<int>();
            List<int> winningBoardsResult = new List<int>();

            foreach(string number in drawnNumbers) {
                for(int i = 0; i < Boards.Count(); i++) {
                    if(!winningBoards.Contains(i)) {
                        if(Boards[i].checkNumber(number)) {
                            // calculate board if board wins
                            // Console.WriteLine($"Board {i} wins");
                            winningBoards.Add(i);
                            winningBoardsResult.Add(Boards[i].calcBoard() * Convert.ToInt32(number));
                        }   
                    }
                }
            }
            return winningBoardsResult.Last();
        }
    }


    public class Board {
        // 2D Array for the board
        private string[,] board = new string[5,5];
        private bool[,] boardCheck = new bool[5,5];

        // Constructor
        public Board(string[] boardNumbers) {
            // write board numbers in board and initialise boardCheck
            for(int row = 0; row < 5; row++) {
                for(int column = 0; column < 5; column++) {
                    board[row,column] = boardNumbers[column+row*5];
                    boardCheck[row,column] = false;
                }
            }
        }

        // Check number
        public Boolean checkNumber(string number) {
            // match number if in board
            for(int row = 0; row < 5; row++) {
                for(int column = 0; column < 5; column++) {
                    if(board[row,column] == number) {
                        // update boardCheck
                        boardCheck[row,column] = true;
                        //printBoard();

                        return assessHorizontal(row) || assessVertical(column);          
                    }
                }
            }
 
            return false;
        }
        // Assess horizontal
        private Boolean assessHorizontal(int row) {
            for(int i = 0; i < 5; i++) {
                if(!boardCheck[row, i]) {
                    return false;
                }
            }
            return true;
        }

        // Assess vertical  
        private Boolean assessVertical(int column) {
            for(int i = 0; i < 5; i++) {
                if(!boardCheck[i, column]) {
                    return false;
                }
            }
            return true;
        }  

        // Calculate board
        public int calcBoard() {
            int sum = 0;
            for(int row = 0; row < 5; row++) {
                for(int column = 0; column < 5; column++) {
                    if(!boardCheck[row,column]) {
                        sum += Convert.ToInt32(board[row,column]);
                    }
                }
            }
            return sum;
        }

        // print board
        private void printBoard() {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                
                Console.Write(Environment.NewLine);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(string.Format("{0} ", boardCheck[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
