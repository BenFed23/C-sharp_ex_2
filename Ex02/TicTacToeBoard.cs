using Ex02.ConsoleUtils;
using System;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        public enum CellState
        {
            Empty,
            X,
            O
        }
        private readonly int m_boardSize;
        private CellState[,] m_Matrixboard;

        public TicTacToeBoard(int i_boardSize)
        {
            m_boardSize = i_boardSize;
            m_Matrixboard = new CellState[m_boardSize, m_boardSize];
            fillBoardWithBlankSpaces();
        }
      
        public CellState this[int i_Row, int i_Col]
        {
            get
            {
                return m_Matrixboard[i_Row, i_Col];
            }
        }
        

        private void fillBoardWithBlankSpaces()
        {
            for (int row = 0; row < m_boardSize; ++row)
            {
                for (int col = 0; col < m_boardSize; ++col)
                {
                    m_Matrixboard[row, col] = CellState.Empty;
                }
            }
        }

        public int GetLength()
        {
            return m_boardSize;
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            bool isEmpty = false;

            if (m_Matrixboard[i_Row, i_Col] == CellState.Empty)
            {
                isEmpty = true;
            }

            return isEmpty;
        }
      
        public bool FillCell(int i_MatrixRow, int i_MatrixCol, CellState i_PlayerSign)
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
            bool isValid=true;

            if ((i_Row >= m_boardSize) || (i_Col >= m_boardSize) || (i_Row < 0) || (i_Col < 0)) 
            {
                isValid = false;
                
            }
            
            return isValid;
        }

        public bool CheckIfBoardIsFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i< m_boardSize; ++i)
            {
                for(int j = 0; j < m_boardSize; ++j)
                {
                    if (m_Matrixboard[i,j] == CellState.Empty)
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
