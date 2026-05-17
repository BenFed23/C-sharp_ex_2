using System;


namespace Ex02
{
    internal class Game
    {
        TicTacToeBoard gameBoard;
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
                Runwithhuman();
            }

        }
        public void Runwithhuman() 
        {
            //logic of how the players pick the sighn...
            //Player p1 = new Player();
            //Player p2 = new Player();
            while (!gameBoard.CheckIfBoardIsFull())
            {

                //Playerturn(p1);
                //Playerturn(p2);

            }
        }
        public bool GameOver() 
        {
            bool gameOver=false;
            //logic here....
            return gameOver;
        }
        public bool CheckIfStrike(int i_matrixRow , int i_matrixCol) 
        {
            bool strike=false;
            //scan Row with for loop
            //scan colom with for loop
            //scan alhson with for loop
            return strike;
        }
        public void Playerturn(Player i_currentPlayer)
        {
            //consol.writeline("pick a cell")
            // player type row number
            //player type colom number
            //check if palyer press Q
            //gameBoard.FillCell(matrixRow , matrixColom , i_currentPlayer);
            //if(CheckIfStrike(int i_matrixRow , int i_matrixCol))
            //{
            //  //end the game
            //} 
        }
    } 

}
