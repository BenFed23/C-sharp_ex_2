using System;
using System.Text;

namespace Ex02
{
    internal class UserInterface
    {
        public void GetGameSettingsFromUser(out int o_BoardSize, out bool o_isComputerPlayer)
        {
            o_BoardSize = GetValidBoardSize();
            o_isComputerPlayer = GetValidGameMode();
        }

        private int GetValidBoardSize() 
        {
            int boardSize = 0;

            ShowMessage("Please enter board size (a number between 3 and 9):");
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out boardSize) || boardSize < 3 || boardSize > 9)
            {
                ShowMessage("Invalid input! Board size should be a number between 3 and 9");
                userInput = Console.ReadLine();
            }

            return boardSize;
        }

        private bool GetValidGameMode() 
        {
            int gameModeChoice;

            ShowMessage("Please choose game mode: press 1 for 2 players, press 2 for player against computer");
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out gameModeChoice) || (gameModeChoice != 1 && gameModeChoice != 2))
            {
                ShowMessage("Invalid Choice! Please enter 1 for 2 players and 2 for player against computer");
                userInput = Console.ReadLine();
            }

            return gameModeChoice == 2;
        }

        public void GetValidNextMoveFromUser(int i_BoardSize, out int o_rowNumber, out int o_columnNumber, out bool o_wasQKeyPressed)
        {
            bool isValidInput = false;
            o_wasQKeyPressed = false;
            o_rowNumber = 0;
            o_columnNumber = 0;

            ShowMessage("Please enter row and column (seperated by comma) or 'Q' to exit");
            while (!isValidInput)
            {
                string userInput = Console.ReadLine();

                if(userInput == "Q")
                {
                    isValidInput = true;
                    o_wasQKeyPressed = true;
                }
                else if (isValidTwoNumbersSplitByComma(userInput, out o_rowNumber, out o_columnNumber) && isValidRowAndColumn(o_rowNumber, o_columnNumber, i_BoardSize))
                {
                    isValidInput = true;
                }
                else
                {
                    ShowMessage("Invalid input! Please enter a valid row and column");
                }
            }
        }

        private bool isValidRowAndColumn(int i_rowNumber, int i_columnNumber, int i_BoardSize)
        {
            bool isValidRowAndColumn = false;

            if (i_rowNumber <= i_BoardSize && i_columnNumber <= i_BoardSize)
            {
                if(i_rowNumber > 0 && i_columnNumber > 0)
                {
                    isValidRowAndColumn = true;
                }
                else
                {
                    isValidRowAndColumn = false;
                }
            }

            return isValidRowAndColumn;
        }

        private bool isValidTwoNumbersSplitByComma(string i_StringToSplit, out int o_firstNumber, out int o_secondNumber)
        {
            bool isValidTwoNumbersAndComma = true;
            int lengthOfStringToSplit = i_StringToSplit.Length;
            bool hasFoundComma = false;
            StringBuilder firstNumberStringBuilder = new StringBuilder();
            StringBuilder secondNumberStringBuilder = new StringBuilder();
            o_firstNumber = 0;
            o_secondNumber = 0;

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
                        if (!int.TryParse(rowString, out o_firstNumber))
                        {
                            isValidTwoNumbersAndComma = false;
                        }
                    }
                    else
                    {
                        secondNumberStringBuilder.Append(currentChar);
                        string columnString = secondNumberStringBuilder.ToString();
                        if (!int.TryParse(columnString, out o_secondNumber))
                        {
                            isValidTwoNumbersAndComma = false;
                        }
                    }
                }
            }

            return isValidTwoNumbersAndComma;
        }

        
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
