using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Program
    {
        public static void Main() 
        {
            GameEngine engine = new GameEngine();
            TicTacToeBoard board = new TicTacToeBoard(3, 3);
            board.FillCell(0, 0, 'X'); board.FillCell(0, 1, 'O'); board.FillCell(0, 2, 'X');
            board.FillCell(1, 0, 'X'); board.FillCell(1, 1, 'X'); board.FillCell(1, 2, 'O');
            board.FillCell(2, 0, 'O'); board.FillCell(2, 1, 'X'); board.FillCell(2, 2, 'O');

            bool hasWinner = engine.IsFullRowColumnOrDiagonalInBoard(board);
            bool isFull = engine.isFullBoard(board);

            Console.WriteLine($"Expect Winner: False | Actual: {hasWinner}");
            Console.WriteLine($"Expect Full Board: True | Actual: {isFull}");
        }
    }
}
