using System;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        public enum CellState
        {
            Empty= ' ',
            X= 'X',
            O='O'
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
            for (int row = 0; row < m_length; ++row)
            {
                for (int col = 0; col < m_width; ++col)
                {
                    m_Matrixboard[row, col] = ' ';
                }
            }
        }

        public int GetLength()
        {
            return m_Matrixboard.GetLength(0);
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
      
        public bool FillCell(int i_MatrixRow, int i_MatrixCol, Player i_currentPlayer)
        {
            bool succesFill = false;
            if(!ValidLenght(i_MatrixRow , i_MatrixCol))
            {

                UserInterface.ShowMessage("The cell doesn't exist on the board ");
                //clear

                return succesFill;
            }
            else if (!this.IsCellEmpty(i_MatrixRow, i_MatrixCol))
            {
                UserInterface.ShowMessage("The cell is full,pick another cell");
                //clear

                return succesFill;
            }
            else
            {
                m_Matrixboard[i_MatrixRow, i_MatrixCol] = i_currentPlayer.Sighn;
                succesFill = true;

                return succesFill;
            }
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
            bool boardIsFull=true;
            for(int i = 0; i < m_boardSize; i++)
            {
                for(int j = 0; j < m_boardSize; j++)
                {
                    if (m_Matrixboard[i, j] == CellState.Empty)
                    {
                        boardIsFull = false;

                        return boardIsFull;
                    }
                }
            }
            return boardIsFull;
        }

        public bool TryGetNextCell (out char o_CellValue)
        {
            int boardSize = m_Matrixboard.GetLength(0);
            int totalCells = boardSize * boardSize;
            bool hasNext = false;
            o_CellValue = ' ';

            if (m_IteratorIndex < totalCells)
            {
                int row = m_IteratorIndex / boardSize;
                int column = m_IteratorIndex % boardSize;

                o_CellValue = m_Matrixboard[row, column];
                m_IteratorIndex++;
                hasNext = true;
            }
            else if (m_IteratorIndex == totalCells)
            {
                m_IteratorIndex = 0;
            }

            return hasNext;
        }
    }
}
