using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        private string username;
        private char symbol;
        private int wins;
        private int losses; 
        public Player(string username, char symbol) 
        {
            this.username = username;
            this.symbol = symbol;
            this.wins = 0;
            this.losses = 0;
        }

        public Player()
        {
            this.username = "";
            this.symbol = '\0';
            this.wins = 0;
            this.losses = 0;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string GetUsername() => this.username;

        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }
        public char GetSymbol() => this.symbol;

        public void IncrementWins()
        {
            this.wins++;
        }
        public int GetWins() => this.wins;

        public void IncrementLosses()
        {
            this.losses++;
        }
        public int GetLosses() => this.losses;
    }
}
