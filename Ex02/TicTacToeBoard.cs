using System;


namespace Ex02
{
    internal class TicTacToeBoard
    {
        private readonly int m_length;
        private readonly int m_width;
        private char[,] m_Matrixboard;
        private int m_IteratorIndex;

        public TicTacToeBoard(int length, int width) 
        {
            m_length = length;
            m_width = width;
            m_Matrixboard=new char[width,m_width];
            m_IteratorIndex = 0;
            
            fillBoardWithBlankSpaces();
        }

        public char this[int i_Row, int i_Col]
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
            if (m_Matrixboard[i_Col,i_Row] == ' ')
            {
                isEmpty = true;
            }
           
            return isEmpty;
        }

        public bool FillCell(int i_MatrixRow, int i_MatrixCol,char i_characterToFill) //maybe matrix of enum insted of char and need to think about small characters
        {
            bool succesFill=false;
            if (!this.IsCellEmpty(i_MatrixRow, i_MatrixCol)) 
            {
                UserInterface.ShowMessage("The cell is full,pick another cell");
                return succesFill;
            }
           else if ((i_MatrixCol > m_width) || (i_MatrixRow > m_length))
            {
                
                UserInterface.ShowMessage("The cell doesn't exist on the board ");
                //clear

                return succesFill;
            }
            else if ((i_characterToFill != 'X') && (i_characterToFill != 'O'))
            {
                UserInterface.ShowMessage("Invalid character ");
                //clear

                return succesFill;
            }
            else
            {
                m_Matrixboard[i_MatrixCol, i_MatrixRow] = i_characterToFill;
                succesFill = true;

                return succesFill;
            }
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
