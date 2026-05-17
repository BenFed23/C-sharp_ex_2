using System;


namespace Ex02
{
    internal class Game
    {
        TicTacToeBoard board;
        bool m_twoPlayers;
        public Game() 
        {
            //Maya logic here..
        }
        public  void Run() 
        {
            if (this.m_twoPlayers)
            {
                //Game.Rungamewithhuman();
            }
            else 
            {
                //Game.Rungamewithcomputer();
            }

        }
    }
}
