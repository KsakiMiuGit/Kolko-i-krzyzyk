using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ZasadyGry 
    {
        public char player;
        public char computerSymbol;
        private char[,] gameTable;
        Random random = new Random();
        public ZasadyGry()
        {
            gameTable = new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } };
        }
        public void XorO()
        {
            int randomNumber = random.Next(0, 2);

            if (randomNumber == 0)
            {
                player = 'X';
                computerSymbol = 'O';
            }
            else
            {
                player = 'O';
                computerSymbol = 'X';
            }
        }
        public char GetCurrentPlayer()
        {
            return player; 
        }

        public void UpdateGameTable(int row, int col)
        {
            gameTable[row, col] = player;
        }
        public bool GetWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameTable[i, 0] != '\0' && gameTable[i, 0] == gameTable[i, 1] && gameTable[i, 1] == gameTable[i, 2])
                {
                    return true; 
                }

                if (gameTable[0, i] != '\0' && gameTable[0, i] == gameTable[1, i] && gameTable[1, i] == gameTable[2, i])
                {
                    return true; 
                }
            }
            if (gameTable[0, 0] != '\0' && gameTable[0, 0] == gameTable[1, 1] && gameTable[1, 1] == gameTable[2, 2])
            {
                return true; 
            }

            if (gameTable[0, 2] != '\0' && gameTable[0, 2] == gameTable[1, 1] && gameTable[1, 1] == gameTable[2, 0])
            {
                return true; 
            }
            return false;
        }
        public bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (gameTable[row, col] == '\0')
                    {
                        return false; 
                    }
                }
            }

            return true;
        }
        public void MakeComputerMoveEasy()
        {
            if (IsBoardFull()) 
            {
                return;
            }

            int row, col;
            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (gameTable[row, col] != '\0');

            gameTable[row, col] = computerSymbol;
        }
        public void MakeComputerMoveMedium()
        {
            int row, col;

            for (row = 0; row < 3; row++)
            {
                for (col = 0; col < 3; col++)
                {
                    if (gameTable[row, col] == '\0')
                    {
                        gameTable[row, col] = computerSymbol;

                        if (GetWinner())
                        {
                            return;
                        }

                        gameTable[row, col] = '\0';
                    }
                }
            }

            for (row = 0; row < 3; row++)
            {
                for (col = 0; col < 3; col++)
                {
                    if (gameTable[row, col] == '\0')
                    {
                        gameTable[row, col] = player;

                        if (GetWinner())
                        {
                            gameTable[row, col] = computerSymbol;
                            return;
                        }

                        gameTable[row, col] = '\0';
                    }
                }
            }

            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (gameTable[row, col] != '\0');

            gameTable[row, col] = computerSymbol;
        }
        public void MakeComputerMoveHard()
        {
            int row, col;

            for (row = 0; row < 3; row++)
            {
                for (col = 0; col < 3; col++)
                {
                    if (gameTable[row, col] == '\0')
                    {
                        gameTable[row, col] = computerSymbol;

                        if (GetWinner())
                        {
                            return;
                        }

                        gameTable[row, col] = '\0';
                    }
                }
            }

            for (row = 0; row < 3; row++)
            {
                for (col = 0; col < 3; col++)
                {
                    if (gameTable[row, col] == '\0')
                    {
                        gameTable[row, col] = player;

                        if (GetWinner())
                        {
                            gameTable[row, col] = computerSymbol;
                            return;
                        }

                        gameTable[row, col] = '\0';
                    }
                }
            }

            if (gameTable[1, 1] == '\0')
            {
                gameTable[1, 1] = computerSymbol;
                return;
            }

            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (gameTable[row, col] != '\0');

            gameTable[row, col] = computerSymbol;
        }
        public char[,] GetGameStatus
        {
            get { return gameTable; }
        }
    }
}
