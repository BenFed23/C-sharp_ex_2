using System;


namespace Ex02
{
    internal class Game
    {
        private readonly UserInterface m_UserInterface;
        private GameEngine m_Engine;
        private TicTacToeBoard m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private bool m_IsAgainstComputer;

        public Game() 
        {
            m_UserInterface = new UserInterface();
            m_Player1 = new Player('X', "Player 1");
            m_Player2 = new Player('O', "Player 2");

            m_CurrentPlayer = m_Player1;
        }
        public void Run() 
        {
            m_UserInterface.GetGameSettingsFromUser(out int boardSize, out m_IsAgainstComputer);
            m_Board = new TicTacToeBoard(boardSize, boardSize);
            m_Engine = new GameEngine();
            runGameLoop();
        }

        private void runGameLoop()
        {
            bool isGameOver = false;

            while (!isGameOver)
            {
                UserInterface.DrawBoard(m_Board);
                UserInterface.ShowMessage($"Player {m_CurrentPlayer.Name}'s turn.");

                int boardRow = 0;
                int boardColumn = 0;
                bool wasQKeyPressed = false;

                if (m_CurrentPlayer == m_Player2 && m_IsAgainstComputer)
                {
                    UserInterface.ShowMessage("Computer is thinking...");
                    //computer move logic 
                }
                else
                {
                    m_UserInterface.GetValidNextMoveFromUser(m_Board.GetLength(), out boardRow, out boardColumn, out wasQKeyPressed);
                }

                if (wasQKeyPressed)
                {
                    UserInterface.ShowMessage("Game stopped by User");
                    break;
                }

                int boardRowIndex = boardRow - 1;
                int boardColIndex = boardColumn - 1;
                bool isMoveSuccessful = m_Board.FillCell(boardRowIndex, boardColIndex, m_CurrentPlayer.Sign);
                while (!isMoveSuccessful)
                {
                    UserInterface.ShowMessage("This cell is already full! Choose another one.");
                }

                if (m_Engine.IsFullRowColumnOrDiagonalInBoard(m_Board))
                {
                    UserInterface.DrawBoard(m_Board);
                    m_CurrentPlayer.Score++;
                    UserInterface.ShowMessage($"Player {m_CurrentPlayer.Sign} Won! Score: {m_CurrentPlayer.Score}");
                    isGameOver = true;
                }
                else if (m_Engine.isFullBoard(m_Board))
                {
                    UserInterface.DrawBoard(m_Board);
                    UserInterface.ShowMessage("It's a tie! The board is full.");
                    isGameOver = true;
                }
                else
                {
                    switchPlayer();
                }
            }
        }

        private void switchPlayer()
        {
            m_CurrentPlayer = (m_CurrentPlayer == m_Player1) ? m_Player2 : m_Player1;
        }
    } 
}
