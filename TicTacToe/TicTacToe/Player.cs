using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        private string username;
        private char symbol;
        public Player(string username, char symbol) 
        {
            this.username = username;
            this.symbol = symbol;
        }

        public Player()
        {
            this.username = "";
            this.symbol = '\0';
        }
        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getUsername() => this.username;
        public void setSymbol(char symbol)
        {
            this.symbol = symbol;
        }
        public char getSymbol() => this.symbol;
    }
}
