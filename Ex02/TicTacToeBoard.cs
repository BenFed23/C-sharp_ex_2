using Ex02.ConsoleUtils;
using System;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        public const char k_XSign = 'X';
        public const char k_OSign = 'O';
        public const char k_EmptySign = ' ';

        public enum eCellState
        {
            Empty,
            X,
            O
        }
        private readonly int r_boardSize;
        private eCellState[,] m_Matrixboard;

        public TicTacToeBoard(int i_BoardSize)
        {
            r_boardSize = i_BoardSize;
            m_Matrixboard = new eCellState[r_boardSize, r_boardSize];
            fillBoardWithBlankSpaces();
        }
      
        public eCellState this[int i_Row, int i_Col]
        {
            get
            {
                return m_Matrixboard[i_Row, i_Col];
            }
        }

        private void fillBoardWithBlankSpaces()
        {
            for (int row = 0; row < r_boardSize; ++row)
            {
                for (int col = 0; col < r_boardSize; ++col)
                {
                    m_Matrixboard[row, col] = eCellState.Empty;
                }
            }
        }

        public int GetLength()
        {
            return r_boardSize;
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            bool isEmpty = false;

            if (m_Matrixboard[i_Row, i_Col] == eCellState.Empty)
            {
                isEmpty = true;
            }

            return isEmpty;
        }
      
        public bool FillCell(int i_MatrixRow, int i_MatrixCol, eCellState i_PlayerSign)
        {
            bool successFill = false;

            if (ValidLength(i_MatrixRow, i_MatrixCol) && IsCellEmpty(i_MatrixRow, i_MatrixCol))
            {
                m_Matrixboard[i_MatrixRow, i_MatrixCol] = i_PlayerSign;
                successFill = true;
            }

            return successFill;
        }
      
        public bool ValidLength(int i_Row, int i_Col)
        {
            bool isValid = true;

            if ((i_Row >= r_boardSize) || (i_Col >= r_boardSize) || (i_Row < 0) || (i_Col < 0)) 
            {
                isValid = false;
                
            }
            
            return isValid;
        }

        public bool CheckIfBoardIsFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i < r_boardSize; ++i)
            {
                for(int j = 0; j < r_boardSize; ++j)
                {
                    if (m_Matrixboard[i,j] == eCellState.Empty)
                    {
                        isBoardFull = false;
                        break;
                    }
                }
            }

            return isBoardFull;
        }
    }
}
