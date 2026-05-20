using Ex02.ConsoleUtils;
using System;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        public const int k_MinBoardSize = 3;
        public const int k_MaxBoardSize = 9;
      
        private readonly int r_BoardSize;
        private eCellState[,] m_Matrixboard;

        public TicTacToeBoard(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            m_Matrixboard = new eCellState[r_BoardSize, r_BoardSize];
            fillBoardWithBlankSpaces();
        }
      
        public eCellState GetCellValue(int i_MatrixRow, int i_MatrixColumn) 
        {

                return m_Matrixboard[i_MatrixRow, i_MatrixColumn];
        }

        private void fillBoardWithBlankSpaces()
        {
            for (int row = 0; row < r_BoardSize; ++row)
            {
                for (int col = 0; col < r_BoardSize; ++col)
                {
                    m_Matrixboard[row, col] = eCellState.Empty;
                }
            }
        }

        public int GetLength()
        {
            return r_BoardSize;
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

            if ((i_Row >= r_BoardSize) || (i_Col >= r_BoardSize) || (i_Row < 0) || (i_Col < 0)) 
            {
                isValid = false;
                
            }
            
            return isValid;
        }

        public bool CheckIfBoardIsFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i < r_BoardSize; ++i)
            {
                for(int j = 0; j < r_BoardSize; ++j)
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
