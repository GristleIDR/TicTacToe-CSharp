using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private Status game_status;
        private int current_player = 0;

        private Board game_board;
        private Player player_1;
        private Player player_2;
        public enum Status {Win, Draw, InProgress}

        public Game()
        {
            this.game_status = Status.InProgress;
            this.current_player = 1;
            this.game_board = new Board();
            this.player_1 = new Player();
            this.player_2 = new Player();
        }

        public Status GetStatus() => this.game_status;
        public void SetStatus(Status status) => this.game_status = status;

        public int GetCurrentPlayer() => this.current_player;
        public void SetCurrentPlayer(int player) => this.current_player = player;

        public void PlayGame()
        {
            // Print The Title Screen
            this.PrintTitleScreen();

            // Get Player 1 Username
            Console.WriteLine("Player 1: Please Select a Username: ");
            string player_1_username = Console.ReadLine();

            Console.WriteLine("\n" + player_1_username + ", Please Choose Your Symbol (X or O): ");
            char player_1_symbol = Console.ReadLine().ToUpper()[0];

            // Get Player 2 Username
            Console.WriteLine("\nPlayer 2: Please Select a Username: ");
            string player_2_username = Console.ReadLine();

            // Set Player 1 symbol
            if (player_1_symbol != 'X' || player_1_symbol != 'O')
            {
                player_1.SetSymbol('X');
            } else
            {
                player_1.SetSymbol(player_1_symbol);
            }

            // Give Player 2 The Opposite Symbol
            if (player_1.GetSymbol() == 'X')
            {
                player_2.SetSymbol('O');
            }
            else
            {
                player_2.SetSymbol('X');
            }

            // Set Player Selections in Objects
            if (player_1_username == "")
            {
                player_1.SetUsername("Player 1");
            } else
            {
                player_1.SetUsername(player_1_username);
            }

            if (player_2_username == "")
            {
                player_2.SetUsername("Player 2");
            }
            else
            {
                player_2.SetUsername(player_2_username);
            }

            // Review Selections
            Console.WriteLine("\nPlayer 1: " + player_1.GetUsername() + " - Symbol: " + player_1.GetSymbol());
            Console.WriteLine("Player 2: " + player_2.GetUsername() + " - Symbol: " + player_2.GetSymbol());

            // Game Play
            while (this.game_status != Status.Win || this.game_status != Status.Draw)
            {
                if (this.current_player == 1)
                {
                    Console.WriteLine("\n" + player_1.GetUsername() + " it is your turn...\n");
                } else
                {
                    Console.WriteLine("\n" + player_2.GetUsername() + " it is your turn...\n");
                }

                game_board.PrintBoard();

                Console.WriteLine("Select X Coordinate: \n");
                string x_axis = Console.ReadLine();

                Console.WriteLine("\nSelect Y Coordinate: \n");
                string y_axis = Console.ReadLine();

                int x = int.Parse(x_axis);
                int y = int.Parse(y_axis);

                if (this.current_player == 1)
                {
                    game_board.MakeMove(player_1.GetSymbol(), x, y);
                } else
                {
                    game_board.MakeMove(player_2.GetSymbol(), x, y);
                }

                this.SwitchPlayer();
                this.UpdateCurrentGameStatus();
            }
        }
        public void UpdateCurrentGameStatus()
        {
            if (game_board.IsDraw())
            {
                this.game_status = Status.Draw;
            }
            else if (game_board.IsWinner(player_1.GetSymbol()) || game_board.IsWinner(player_2.GetSymbol()))
            {
                this.game_status = Status.Win;
            }
            else
            {
                this.game_status = Status.InProgress;
            }
        }
        public void SwitchPlayer()
        {
            if (this.current_player == 1)
            {
                this.current_player = 2;
            }
            else
            {
                this.current_player = 1;
            }
        }
        public void PrintTitleScreen()
        {
            Console.WriteLine("--------------------------[ TicTacToe ]--------------------------\nProgrammer: Isaac Replogle\nGithub Project: https://github.com/GristleIDR/TicTacToe-CSharp\n\nWelcome...\n\n");
        }
        public void PrintEndGame()
        {

        }
    }
}
