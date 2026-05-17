using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class UserInterface
    {
        public int m_boardSize;

        public void GetGameSettingsFromUser(out int o_BoardSize, out bool o_isComputerPlayer)
        {
            o_BoardSize = GetValidBoardSize();
            this.m_boardSize = o_BoardSize;
            o_isComputerPlayer = GetValidGameMode();
        }

        private int GetValidBoardSize() 
        {
            int boardSize = 0;

            Console.WriteLine("Please enter board size (a number between 3 and 9):");
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out boardSize) || boardSize < 3 || boardSize > 9)
            {
                Console.WriteLine("Invalid input! Board size should be a number between 3 and 9");
                userInput = Console.ReadLine();
            }

            return boardSize;
        }

        private bool GetValidGameMode() 
        {
            int gameModeChoice;

            Console.WriteLine("Please choose game mode: press 1 for 2 players, press 2 for player against computer");
            string userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out gameModeChoice) || (gameModeChoice != 1 && gameModeChoice != 2))
            {
                Console.WriteLine("Invalid Choice! Please enter 1 for 2 players and 2 for player against computer");
                userInput = Console.ReadLine();
            }

            return gameModeChoice == 2;
        }

        public void GetValidNextMoveFromUser(out int o_rowNumber, out int o_columnNumber, out bool o_wasQKeyPressed)
        {
            bool isValidInput = false;
            o_wasQKeyPressed = false;
            o_rowNumber = 0;
            o_columnNumber = 0;

            Console.WriteLine("Please enter row and column (seperated by comma) or 'Q' to exit");
            while (!isValidInput)
            {
                string userInput = Console.ReadLine();

                if(userInput == "Q")
                {
                    isValidInput = true;
                    o_wasQKeyPressed = true;
                }
                else if (isValidTwoNumbersSplitByComma(userInput, out o_rowNumber, out o_columnNumber) && isValidRowAndColumn(o_rowNumber, o_columnNumber))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid row and column");
                }
            }
        }

        private bool isValidRowAndColumn(int i_rowNumber, int i_columnNumber)
        {
            bool isValidRowAndColumn = false;

            if (i_rowNumber <= m_boardSize && i_columnNumber <= m_boardSize)
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
                    if(hasFoundComma)
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
    }
}
