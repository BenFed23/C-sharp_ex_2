using System;


namespace Ex02
{
    internal class GameEngine
    {
        public bool IsFullRowColumnOrDiagonalInBoard(TicTacToeBoard i_board)
        {
            int boardSize = i_board.GetLength();
            bool isFullRow = false;
            bool isFullColumn = false;
            bool isFullLeftToRightDiagonal = false;
            bool isFullRightToLeftDiagonal = false;


            for (int i = 0; i < boardSize; ++i)
            {
                if(checkIfLineIsFull(i_board, i, 0, 0, 1))
                {
                    isFullRow = true;
                }

                if (checkIfLineIsFull(i_board, 0, i, 1, 0))
                {
                    isFullColumn = true;
                }
            }

            if (checkIfLineIsFull(i_board, 0, 0, 1, 1))
            {
                isFullLeftToRightDiagonal = true;
            }

            if (checkIfLineIsFull(i_board, 0, boardSize - 1, 1, -1))
            {
                isFullRightToLeftDiagonal = true;
            }

            return (isFullRow || isFullColumn || isFullLeftToRightDiagonal || isFullRightToLeftDiagonal);
        }

        private bool checkIfLineIsFull(TicTacToeBoard i_board, int i_StartRowIndex, int i_StartColumnIndex, int i_Rowdirection, int i_ColumnDirection)
        {
            int boardSize = i_board.GetLength();
            bool isLineFull = true;
            TicTacToeBoard.CellState firstInLine = i_board[i_StartRowIndex, i_StartColumnIndex];

            if(firstInLine == TicTacToeBoard.CellState.Empty)
            {
                isLineFull = false;
            }

            if(isLineFull)
            {
                int currentRow = i_StartRowIndex;
                int currentColumnIndex = i_StartColumnIndex;

                for( int i = 0; i< boardSize; ++i ) 
                {
                    if (i_board[currentRow, currentColumnIndex] != firstInLine) 
                    {
                        isLineFull = false;
                    }

                    currentRow += i_Rowdirection;
                    currentColumnIndex += i_ColumnDirection;
                }
            }

            return isLineFull;
        }

        public bool isFullBoard (TicTacToeBoard i_board)
        {
            return i_board.CheckIfBoardIsFull();
        }

        public static bool MiroringOpponet(TicTacToeBoard i_gameBoard,int i_boardRow ,int i_boardColom, TicTacToeBoard.CellState i_ComputerSign)
        {
            bool successMiroring=true;
            int mirorRow = i_gameBoard.GetLength() - 1 - i_boardRow;
            int mirorColom = i_gameBoard.GetLength() - 1 - i_boardColom;
            if (!i_gameBoard.IsCellEmpty(mirorRow, mirorColom))
            {
                successMiroring = false;
            }
            else
            {   
                i_gameBoard.FillCell(mirorRow, mirorColom, i_ComputerSign);
            }

            return successMiroring;
        }
        public static bool MinDamage(TicTacToeBoard i_gameBoard, TicTacToeBoard.CellState i_ComputerSign)
        {
            bool successMove=true;
            const int k_InitialMaxRisk = 100;
            int minRisk = k_InitialMaxRisk;
            int minCellRow = 0;
            int minCellColom = 0;
            for (int i = 0; i < i_gameBoard.GetLength(); i++)
            {
               for(int j = 0; j < i_gameBoard.GetLength(); j++)
                {
                    int rowOCount =0;
                    int colomOCount = 0;
                    int leftDiagonalOCount = 0;
                    if (i_gameBoard.IsCellEmpty(i, j))
                    {
                        GetCellRisk(i_gameBoard, i_ComputerSign, i, j,out rowOCount, out colomOCount, out leftDiagonalOCount);


                        int maxCellOCount = Math.Max(rowOCount, colomOCount);
                        int maxCellDiagonalOCount = Math.Max(leftDiagonalOCount, maxCellOCount);
                        int maxOcount = Math.Max(maxCellOCount, maxCellDiagonalOCount);
                        if (maxOcount < minRisk)
                        {
                            minCellRow = i;
                            minCellColom = j;
                            minRisk = maxOcount;
                        }
                    }
                }
            }
            if (minRisk < i_gameBoard.GetLength() - 1)
            {
                i_gameBoard.FillCell(minCellRow, minCellColom, i_ComputerSign);
            }
            else
            {
                successMove = false;
            }

            return successMove;
        }
        public static void RandomMove(TicTacToeBoard i_gameBoard, TicTacToeBoard.CellState i_ComputerSign)
        {
            Random random = new Random();
            int startRow = random.Next(0, i_gameBoard.GetLength());
            int startCol = random.Next(0, i_gameBoard.GetLength());

            for (int i = 0; i < i_gameBoard.GetLength(); i++)
            {
                int row = (startRow + i) % i_gameBoard.GetLength();

                for (int j = 0; j < i_gameBoard.GetLength(); j++)
                {
                    int col = (startCol + j) % i_gameBoard.GetLength();

                   
                    if (i_gameBoard.IsCellEmpty(row, col))
                    {
                        i_gameBoard.FillCell(row, col, i_ComputerSign);
                        return; 
                    }
                }
            }
        }

        public static void ComputerMove(TicTacToeBoard i_gameBoard, TicTacToeBoard.CellState i_ComputerSign) 
        {
            bool ismoveMade = trySmartMove(i_gameBoard, i_ComputerSign);

            if (!ismoveMade)
            {
                RandomMove(i_gameBoard, i_ComputerSign);
            }
        }

        public static bool trySmartMove(TicTacToeBoard i_board, TicTacToeBoard.CellState i_computerSign)
        {
            bool ismoveMade = false;
            ismoveMade = MinDamage(i_board, i_computerSign);
            
            return ismoveMade;
        }

        public static void GetCellRisk(TicTacToeBoard i_gameBoard , TicTacToeBoard.CellState i_ComputerSign, int i_extendIndex , int i_inerrIndex , out int o_rowOCount , out int o_colomOCount , out int o_leftDiagonalOCount)
        {
            o_rowOCount = 0;
            o_colomOCount = 0;
            o_leftDiagonalOCount = 0;
            for (int k = 0; k < i_gameBoard.GetLength(); k++)
            {
                if (i_gameBoard[i_extendIndex, k] == i_ComputerSign)
                {
                    o_rowOCount++;
                }

                if (i_gameBoard[k, i_inerrIndex] == i_ComputerSign)
                {
                    o_colomOCount++;
                }

                if (i_extendIndex == i_inerrIndex && i_gameBoard[k, k] == i_ComputerSign)
                {
                    o_leftDiagonalOCount++;
                }
            }
        }

        public TicTacToeBoard.CellState GetWinningSign(TicTacToeBoard.CellState i_Player1Sign, TicTacToeBoard.CellState i_Player2Sign, TicTacToeBoard.CellState i_CurrentPlayerSign)
        {
            return (i_CurrentPlayerSign == i_Player1Sign) ? i_Player2Sign : i_Player1Sign;
        }
    }
}
