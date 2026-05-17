using System;


namespace Ex02
{
    internal class TicTacToeBoard
    {
        private readonly int m_length;
        private readonly int m_width;
        private char[,] m_Matrixboard;
        public TicTacToeBoard(int length, int width) 
        {
            m_length = length;
            m_width = width;
            m_Matrixboard=new char[width,m_width];
        }
        public char[,] this[int i_Row, int i_Col]
        {
            get 
            {
                return m_Matrixboard; 
            }
            
        }
        public  bool IsCellEmpty(int i_Row, int i_Col)
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
            if (!this.IsCellEmpty(i_MatrixCol,i_MatrixRow)) 
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
            else if ((i_characterToFill != 'X') || (i_characterToFill != 'O'))
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

    }
}
