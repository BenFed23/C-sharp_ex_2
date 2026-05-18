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
            bool isFullBoard = true;

            while(isFullBoard && i_board.TryGetNextCell(out TicTacToeBoard.CellState currentCell))
            {
                if (currentCell == TicTacToeBoard.CellState.Empty)
                {
                    isFullBoard = false;
                }
            }

            return isFullBoard;
        }
    }
}
