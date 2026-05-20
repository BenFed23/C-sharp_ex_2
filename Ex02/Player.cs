using System;



namespace Ex02
{
    internal class Player
    {
        private int m_Score;
        private TicTacToeBoard.eCellState m_Sign;
        private string m_Name;

        public Player(TicTacToeBoard.eCellState i_Sign, string i_Name) 
        {
            m_Sign = i_Sign;
            m_Name = i_Name;
            m_Score = 0;
        }

        public TicTacToeBoard.eCellState Sign
        {
            get
            {
                return m_Sign;
            }   
        }
      
        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }
        public string Name 
        {
            get
            {
                return m_Name;
            }
        }
    }
}