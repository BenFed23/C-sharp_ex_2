using System;


namespace Ex02
{
    internal class UserInterface
    {
        public static void DrawBoard(TicTacToeBoard.CellState[,] i_gameBoard,int i_bordsize) 
        {
            //darw bord like in the picture
            //fill the board
            foreach (char item in i_gameBoard)
            {
                Console.WriteLine(item); 
            }
        }
        public static void ShowMessage(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
