using System;
using System.Reflection;
using System.Text;

namespace Ex02
{
    internal class UserInterface
    {
        private const string k_QuitKey = "Q";
        private const char k_XSign = 'X';
        private const char k_OSign = 'O';
        private const char k_EmptySign = ' ';

        public void GetGameSettingsFromUser(out int o_BoardSize, out bool o_IsComputerPlayer)
        {
            o_BoardSize = GetValidBoardSize();
            o_IsComputerPlayer = GetValidGameMode();
        }

        private int GetValidBoardSize() 
        {
            int boardSize = 0;
            int minBoardSize = TicTacToeBoard.k_MinBoardSize;
            int maxBoardSize = TicTacToeBoard.k_MaxBoardSize;

            Console.WriteLine("Please enter board size (a number between {0} and {1}):", minBoardSize, maxBoardSize);
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out boardSize) || boardSize < minBoardSize || boardSize > maxBoardSize)
            {
                Console.WriteLine("Invalid input! Board size should be a number between {0} and {1}", minBoardSize, maxBoardSize);
                userInput = Console.ReadLine();
            }

            return boardSize;
        }

        private bool GetValidGameMode() 
        {
            int gameModeChoice;

            Console.WriteLine("Please choose game mode: press {0} for 2 players, press {1} for player against computer", TicTacToeBoard.k_TwoPlayerMode, TicTacToeBoard.k_ComputerMode);
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out gameModeChoice) || (gameModeChoice != TicTacToeBoard.k_TwoPlayerMode && gameModeChoice != TicTacToeBoard.k_ComputerMode))
            {
                Console.WriteLine("Invalid Choice! Please enter {0} for 2 players and {1} for player against computer", TicTacToeBoard.k_TwoPlayerMode, TicTacToeBoard.k_ComputerMode);
                userInput = Console.ReadLine();
            }

            return gameModeChoice == TicTacToeBoard.k_ComputerMode;
        }

        public void GetValidNextMoveFromUser(int i_BoardSize, out int o_RowNumber, out int o_ColumnNumber, out bool o_WasQKeyPressed)
        {
            bool isValidInput = false;
            o_WasQKeyPressed = false;
            o_RowNumber = 0;
            o_ColumnNumber = 0;

            Console.WriteLine("Please enter row and column (seperated by comma) or '{0}' to exit", k_QuitKey);
            while (!isValidInput)
            {
                string userInput = Console.ReadLine();
                bool isQuitPressed = (userInput == k_QuitKey);
                bool isMoveValid = !isQuitPressed && isValidTwoNumbersSplitByComma(userInput, out o_RowNumber, out o_ColumnNumber) && isValidRowAndColumn(o_RowNumber, o_ColumnNumber, i_BoardSize);

                if (isQuitPressed || isMoveValid)
                {
                    isValidInput = true;
                    o_WasQKeyPressed = isQuitPressed;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid row and column");
                }
            }
        }

        private bool isValidRowAndColumn(int i_RowNumber, int i_ColumnNumber, int i_BoardSize)
        {
            bool isValidRowAndCol = i_RowNumber > 0 && i_RowNumber <= i_BoardSize && i_ColumnNumber > 0 && i_ColumnNumber <= i_BoardSize;

            return isValidRowAndCol;
        }

        private bool isValidTwoNumbersSplitByComma(string i_StringToSplit, out int o_FirstNumber, out int o_SecondNumber)
        {
            bool isValidTwoNumbersAndComma = true;
            int lengthOfStringToSplit = i_StringToSplit.Length;
            bool hasFoundComma = false;
            StringBuilder firstNumberStringBuilder = new StringBuilder();
            StringBuilder secondNumberStringBuilder = new StringBuilder();

            o_FirstNumber = 0;
            o_SecondNumber = 0;
            for (int i = 0; i < lengthOfStringToSplit; ++i)
            {
                char currentChar = i_StringToSplit[i];
                if (currentChar == ',')
                {
                    if (hasFoundComma)
                    {
                        isValidTwoNumbersAndComma = false;
                    }
                    hasFoundComma = true;
                }
                else
                {
                    if (!hasFoundComma)
                    {
                        firstNumberStringBuilder.Append(currentChar);
                        string rowString = firstNumberStringBuilder.ToString();
                        if (!int.TryParse(rowString, out o_FirstNumber))
                        {
                            isValidTwoNumbersAndComma = false;
                        }
                    }
                    else
                    {
                        secondNumberStringBuilder.Append(currentChar);
                        string columnString = secondNumberStringBuilder.ToString();
                        if (!int.TryParse(columnString, out o_SecondNumber))
                        {
                            isValidTwoNumbersAndComma = false;
                        }
                    }
                }
            }

            return isValidTwoNumbersAndComma;
        }


        public void DrawBoard(TicTacToeBoard i_GameBoard)
        {
            int boardSize = i_GameBoard.GetLength();

            Console.Write("    ");
            for (int i = 1; i <= boardSize; ++i)
            {
                Console.Write($"{i}   ");
            }

            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                Console.Write($"{row + 1} |");
                for (int col = 0; col < boardSize; col++)
                {
                    char cellSign = getCellCharacter(i_GameBoard[row, col]);
                    Console.Write($" {cellSign} |");
                }

                Console.WriteLine();
                if (row < boardSize - 1)
                {
                    Console.Write("  ");
                    for (int j = 0; j < boardSize; j++)
                    {
                        Console.Write("====");
                    }

                    Console.Write("=");
                    Console.WriteLine();
                }
            }
        }

        private char getCellCharacter(eCellState i_CellState)
        {
            char cellChar = ' ';

            switch(i_CellState)
            {
                case eCellState.X:
                    cellChar = k_XSign;
                    break;
                case eCellState.O:
                    cellChar = k_OSign;
                    break;
                case eCellState.Empty:
                    cellChar = k_EmptySign;
                    break;
            }

            return cellChar;
        }

        public bool AskForRematch()
        {
            bool isValidInput = false;
            bool isContinueToRematch = false;

            while (!isValidInput)
            {
                Console.WriteLine("Would you like to play another round? (Y/N):");
                string userInput = Console.ReadLine();
                if (userInput == "Y")
                {
                    isContinueToRematch = true;
                    isValidInput = true;
                }
                else if(userInput == "N")
                {
                    isContinueToRematch = false;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                }
            }

            return isContinueToRematch;
        }

        public void AnnounceTurn(string i_PlayerName)
        {
            Console.WriteLine($"Player {i_PlayerName}'s turn.");
        }

        public void AnnounceGameStopped()
        {
            Console.WriteLine("Game stopped by User");
        }


        public void AnnounceInvalidMove()
        {
            Console.WriteLine("Invalid move! The cell is either full or out of bounds. Try again.");
        }

        public void AnnounceGameOver(string i_LoserName, string i_WinnerName, int i_WinnerScore)
        {
            Console.WriteLine($"Player {i_LoserName} created a sequence and lost!");
            Console.WriteLine($"Player {i_WinnerName} Won! Score: {i_WinnerScore}");
        }

        public void AnnounceTie()
        {
            Console.WriteLine("It's a tie! The board is full.");
        }

        public void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}
