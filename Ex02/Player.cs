using System;



namespace Ex02
{
    internal class Player
    {
        private int m_score;
        private char TicTacToeBoard.CellState m_sign;
        private string m_name;

        public Player(TicTacToeBoard.CellState i_sign, string i_name) 
        {
            m_sign = i_sign;
            m_name
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

        public char Sign
        {
            get 
            { 
                return m_sign; 
            }
        }

        public int Score
        {
            get
            {
                return m_score;
            }
            set
            {
                m_score = value;
            }
        }

    }
}
