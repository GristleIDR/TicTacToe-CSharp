using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public char[,] board = { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, };

        public void MakeMove(char p, int x, int y)
        {
            this.board[x, y] = p;
        }
        public char GetPosition(int x, int y) => board[x, y];

        public void PrintBoard()
        {
            // display the board
            Console.WriteLine(this.board[0,0] + " | " + this.board[0,1] + " | " + this.board[0,2] + "\n-------------\n" + this.board[1,0] + " | " + this.board[1,1] + " | " + this.board[1,2] + "\n-------------\n" + this.board[2,0] + " | " + this.board[2,1] + " | " + this.board[2,2]);
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '\0';
                }

            }
        }

        public bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsWinner(char p)
        {
            // Function Should Check Win Condition For Passed Character ... X or O
            return false;
        }

        public bool IsDraw()
        {
            // Function Should Check If The Board Is Full and There Are No Winners
            return false;
        }
    }
}
