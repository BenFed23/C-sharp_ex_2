using System;


namespace Ex02
{
    internal class GameEngine
    {
        private const int k_NoDirection = 0;
        private const int k_PositiveDirection = 1;
        private const int k_NegativeDirection = -1;

        public bool IsFullRowColumnOrDiagonalInBoard(TicTacToeBoard i_Board)
        {
            int boardSize = i_Board.GetLength();
            bool isFullRow = false;
            bool isFullColumn = false;
            bool isFullLeftToRightDiagonal = false;
            bool isFullRightToLeftDiagonal = false;

            for (int i = 0; i < boardSize; ++i)
            {
                if(checkIfLineIsFull(i_Board, i, 0, k_NoDirection, k_PositiveDirection))
                {
                    isFullRow = true;
                }

                if (checkIfLineIsFull(i_Board, 0, i, k_PositiveDirection, k_NoDirection))
                {
                    isFullColumn = true;
                }
            }

            if (checkIfLineIsFull(i_Board, 0, 0, k_PositiveDirection, k_PositiveDirection))
            {
                isFullLeftToRightDiagonal = true;
            }

            if (checkIfLineIsFull(i_Board, 0, boardSize - 1, k_PositiveDirection, k_NegativeDirection))
            {
                isFullRightToLeftDiagonal = true;
            }

            return (isFullRow || isFullColumn || isFullLeftToRightDiagonal || isFullRightToLeftDiagonal);
        }

        private bool checkIfLineIsFull(TicTacToeBoard i_Board, int i_StartRowIndex, int i_StartColumnIndex, 
            int i_RowDirection, int i_ColumnDirection)
        {
            int boardSize = i_Board.GetLength();
            bool isLineFull = true;
            eCellState firstInLine = i_Board.GetCellValue(i_StartRowIndex, i_StartColumnIndex);

            if(firstInLine == eCellState.Empty)
            {
                isLineFull = false;
            }

            if(isLineFull)
            {
                int currentRowIndex = i_StartRowIndex;
                int currentColumnIndex = i_StartColumnIndex;
                for( int i = 0; i< boardSize; ++i ) 
                {
                    if (i_Board.GetCellValue(currentRowIndex, currentColumnIndex) != firstInLine) 
                    {
                        isLineFull = false;
                    }

                    currentRowIndex += i_RowDirection;
                    currentColumnIndex += i_ColumnDirection;
                }
            }

            return isLineFull;
        }

        public bool isFullBoard (TicTacToeBoard i_Board)
        {
            return i_Board.CheckIfBoardIsFull();
        }

        public static bool MinDamage(TicTacToeBoard i_GameBoard, eCellState i_ComputerSign)
        {
            bool successMove = true;
            const int k_InitialMaxRisk = 100;
            int minRisk = k_InitialMaxRisk;
            int minCellRow = 0;
            int minCellColumn = 0;

            for (int i = 0; i < i_GameBoard.GetLength(); i++)
            {
               for(int j = 0; j < i_GameBoard.GetLength(); j++)
               {
                    int rowOCount = 0;
                    int columnOCount = 0;
                    int leftDiagonalOCount = 0;
                    if (i_GameBoard.IsCellEmpty(i, j))
                    {
                        GetCellRisk(i_GameBoard, i_ComputerSign, i, j,out rowOCount, out columnOCount, out leftDiagonalOCount);
                        int maxCellOCount = Math.Max(rowOCount, columnOCount);
                        int maxCellDiagonalOCount = Math.Max(leftDiagonalOCount, maxCellOCount);
                        int maxOcount = Math.Max(maxCellOCount, maxCellDiagonalOCount);
                        if (maxOcount < minRisk)
                        {
                            minCellRow = i;
                            minCellColumn = j;
                            minRisk = maxOcount;
                        }
                    }
               }
            }

            if(minRisk < i_GameBoard.GetLength() - 1)
            {
                i_GameBoard.FillCell(minCellRow, minCellColumn, i_ComputerSign);
            }
            else
            {
                successMove = false;
            }

            return successMove;
        }

        public static void RandomMove(TicTacToeBoard i_GameBoard, eCellState i_ComputerSign)
        {
            Random random = new Random();
            int startRow = random.Next(0, i_GameBoard.GetLength());
            int startCol = random.Next(0, i_GameBoard.GetLength());

            for (int i = 0; i < i_GameBoard.GetLength(); i++)
            {
                int row = (startRow + i) % i_GameBoard.GetLength();
                for (int j = 0; j < i_GameBoard.GetLength(); j++)
                {
                    int col = (startCol + j) % i_GameBoard.GetLength();
                    if (i_GameBoard.IsCellEmpty(row, col))
                    {
                        i_GameBoard.FillCell(row, col, i_ComputerSign);
                        return; 
                    }
                }
            }
        }

        public static void ComputerMove(TicTacToeBoard i_GameBoard, eCellState i_ComputerSign) 
        {
            bool ismoveMade = MinDamage(i_GameBoard, i_ComputerSign);

            if (!ismoveMade)
            {
                RandomMove(i_GameBoard, i_ComputerSign);
            }
        }

       
        public static void GetCellRisk(TicTacToeBoard i_GameBoard , eCellState i_ComputerSign, 
            int i_ExtendIndex , int i_InnerIndex , out int o_RowOCount , out int o_ColumnOCount , out int o_LeftDiagonalOCount)
        {
            o_RowOCount = 0;
            o_ColumnOCount = 0;
            o_LeftDiagonalOCount = 0;
            for (int k = 0; k < i_GameBoard.GetLength(); k++)
            {
                if (i_GameBoard.GetCellValue(i_ExtendIndex, k) == i_ComputerSign)
                {
                    o_RowOCount++;
                }

                if (i_GameBoard.GetCellValue(k, i_InnerIndex) == i_ComputerSign)
                {
                    o_ColumnOCount++;
                }

                if (i_ExtendIndex == i_InnerIndex && i_GameBoard.GetCellValue(k, k) == i_ComputerSign)
                {
                    o_LeftDiagonalOCount++;
                }
            }
        }

        public eCellState GetWinningSign(eCellState i_Player1Sign, eCellState i_Player2Sign, eCellState i_CurrentPlayerSign)
        {
            return (i_CurrentPlayerSign == i_Player1Sign) ? i_Player2Sign : i_Player1Sign;
        }
    }
}
