using System;
using System.Reflection;
using Ex02.ConsoleUtils;

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
            m_Player1 = new Player(TicTacToeBoard.CellState.X, "Player 1");
            m_Player2 = new Player(TicTacToeBoard.CellState.O, "Player 2");

            m_CurrentPlayer = m_Player1;
        }
        public void Run() 
        {
            bool isCountinueToRematch = true;
            m_UserInterface.GetGameSettingsFromUser(out int boardSize, out m_IsAgainstComputer);
            m_Engine = new GameEngine();
            while(isCountinueToRematch)
            {
                m_Board = new TicTacToeBoard(boardSize);
                m_CurrentPlayer = m_Player1;
                runGameLoop();
                isCountinueToRematch = m_UserInterface.AskForRematch();
            }
        }

        private void runGameLoop()
        {

            bool isGameOver = false;
            int boardRow = 0;
            int boardColumn = 0;

            while (!isGameOver)
            {
                Screen.Clear();
                m_UserInterface.DrawBoard(m_Board);
                m_UserInterface.AnnounceTurn(m_CurrentPlayer.Name);
                bool wasQKeyPressed = false;
                int boardRowIndex = 0;
                int boardColIndex = 0;

                if (m_CurrentPlayer == m_Player2 && m_IsAgainstComputer)
                {
                    GameEngine.ComputerMove(m_Board, m_Player2.Sign);
                }
                else
                {
                    m_UserInterface.GetValidNextMoveFromUser(m_Board.GetLength(), out boardRow, out boardColumn, out wasQKeyPressed);
                    if (wasQKeyPressed)
                    {
                        m_UserInterface.AnnounceGameStopped();
                        break;
                    }

                    boardRowIndex = boardRow - 1;
                    boardColIndex = boardColumn - 1;
                    bool isMoveSuccessful = m_Board.FillCell(boardRowIndex, boardColIndex, m_CurrentPlayer.Sign);
                    while (!isMoveSuccessful)
                    {
                        m_UserInterface.ClearScreen();
                        m_UserInterface.DrawBoard(m_Board);
                        m_UserInterface.AnnounceInvalidMove();
                        m_UserInterface.GetValidNextMoveFromUser(m_Board.GetLength(), out boardRow, out boardColumn, out wasQKeyPressed);
                        if (wasQKeyPressed)
                        {
                            m_UserInterface.AnnounceGameStopped();
                            isGameOver = true;
                            break;
                        }
                         boardRowIndex = boardRow - 1;
                        boardColIndex = boardColumn - 1;
                        isMoveSuccessful = m_Board.FillCell(boardRowIndex, boardColIndex, m_CurrentPlayer.Sign);
                    }
                }

                if (m_Engine.IsFullRowColumnOrDiagonalInBoard(m_Board))
                {
                    m_UserInterface.ClearScreen();
                    m_UserInterface.DrawBoard(m_Board);
                    TicTacToeBoard.CellState winningSign = m_Engine.GetWinningSign(m_Player1.Sign, m_Player2.Sign, m_CurrentPlayer.Sign);
                    Player winner = (winningSign == m_Player1.Sign) ? m_Player1 : m_Player2;
                    winner.Score++;
                    m_UserInterface.AnnounceGameOver(m_CurrentPlayer.Name, winner.Name, winner.Score);
                    isGameOver = true;
                }
                else if (m_Engine.isFullBoard(m_Board))
                {
                    m_UserInterface.ClearScreen();
                    m_UserInterface.DrawBoard(m_Board);
                    m_UserInterface.AnnounceTie();
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
