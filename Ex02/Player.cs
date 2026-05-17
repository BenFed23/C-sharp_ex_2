using System;



namespace Ex02
{
    internal class Player
    {
        private int m_score;
        private readonly TicTacToeBoard.CellState m_sighn;
        public Player(TicTacToeBoard.CellState i_sighn) 
        {
            m_sighn = i_sighn;
            m_score = 0;
          
        }
        public TicTacToeBoard.CellState Sighn
        {
            get
            {
                return m_sighn;
            }
           
        }
        public int Score 
        {
            get {return m_score; }
            set { m_score = value; }
        }

    }
}
