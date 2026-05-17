using System;


namespace Ex02
{
    internal class Player
    {
        private int m_score;
        private char m_sign;
        private string m_name;

        public Player(char i_sign, string i_name) 
        {
            m_sign = i_sign;
            m_name
            m_score = 0;
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
