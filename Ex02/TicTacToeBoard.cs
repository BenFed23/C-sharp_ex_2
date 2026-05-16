using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        private readonly int m_length;
        private readonly int m_width;
        private char[,] m_boardMatrix;
        //maybe getAllBord
        public char this[int i_Row, int i_Col]
        {
            get { return m_boardMatrix[i_Row, i_Col]; }
            set { m_boardMatrix[i_Row, i_Col] = value; }
        }
    }
}
