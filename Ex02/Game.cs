using System;
using System.Reflection;

namespace Ex02
{
    internal class Game
    {
        private readonly UserInterface r_UserInterface;
        private GameEngine m_Engine;
        private TicTacToeBoard m_Board;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_CurrentPlayer;
        private bool m_IsAgainstComputer;

        public Game() 
        {
            r_UserInterface = new UserInterface();
            r_Player1 = new Player(TicTacToeBoard.eCellState.X, "Player 1");
            r_Player2 = new Player(TicTacToeBoard.eCellState.O, "Player 2");

            m_CurrentPlayer = r_Player1;
        }

        public void Run() 
        {
            bool isCountinueToRematch = true;

            r_UserInterface.GetGameSettingsFromUser(out int boardSize, out m_IsAgainstComputer);
            m_Engine = new GameEngine();
            while(isCountinueToRematch)
            {
                m_Board = new TicTacToeBoard(boardSize);
                m_CurrentPlayer = r_Player1;
                runGameLoop();
                isCountinueToRematch = r_UserInterface.AskForRematch();
            }
        }

        private void runGameLoop()
        {
            bool isGameOver = false;
            int boardRow = 0;
            int boardColumn = 0;

            while (!isGameOver)
            {
                r_UserInterface.ClearScreen();
                r_UserInterface.DrawBoard(m_Board);
                r_UserInterface.AnnounceTurn(m_CurrentPlayer.Name);
                bool wasQKeyPressed = false;
                int boardRowIndex = 0;
                int boardColumnIndex = 0;
                if (m_CurrentPlayer == r_Player2 && m_IsAgainstComputer)
                {
                    GameEngine.ComputerMove(m_Board, r_Player2.Sign);
                }
                else
                {
                    r_UserInterface.GetValidNextMoveFromUser(m_Board.GetLength(), out boardRow, out boardColumn, out wasQKeyPressed);
                    if (wasQKeyPressed)
                    {
                        r_UserInterface.AnnounceGameStopped();
                        break;
                    }

                    boardRowIndex = boardRow - 1;
                    boardColumnIndex = boardColumn - 1;
                    bool isMoveSuccessful = m_Board.FillCell(boardRowIndex, boardColumnIndex, m_CurrentPlayer.Sign);
                    while (!isMoveSuccessful)
                    {
                        r_UserInterface.ClearScreen();
                        r_UserInterface.DrawBoard(m_Board);
                        r_UserInterface.AnnounceInvalidMove();
                        r_UserInterface.GetValidNextMoveFromUser(m_Board.GetLength(), out boardRow, out boardColumn, out wasQKeyPressed);
                        if (wasQKeyPressed)
                        {
                            r_UserInterface.AnnounceGameStopped();
                            isGameOver = true;
                            break;
                        }

                        boardRowIndex = boardRow - 1;
                        boardColumnIndex = boardColumn - 1;
                        isMoveSuccessful = m_Board.FillCell(boardRowIndex, boardColumnIndex, m_CurrentPlayer.Sign);
                    }
                }

                r_UserInterface.ClearScreen();
                r_UserInterface.DrawBoard(m_Board);

                if (m_Engine.IsFullRowColumnOrDiagonalInBoard(m_Board))
                {
                    TicTacToeBoard.eCellState winningPlayerSign = m_Engine.GetWinningSign(r_Player1.Sign, r_Player2.Sign, m_CurrentPlayer.Sign);
                    Player winningPlayer = (winningPlayerSign == r_Player1.Sign) ? r_Player1 : r_Player2;
                    winningPlayer.Score++;
                    r_UserInterface.AnnounceGameOver(m_CurrentPlayer.Name, winningPlayer.Name, winningPlayer.Score);
                    isGameOver = true;
                }
                else if (m_Engine.isFullBoard(m_Board))
                {
                    r_UserInterface.AnnounceTie();
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
            m_CurrentPlayer = (m_CurrentPlayer == r_Player1) ? r_Player2 : r_Player1;
        }
    } 
}
