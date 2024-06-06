namespace TicTacToe.Tests
{
    public class BoardTest
    {
        [Fact]
        public void MakeMoveTest()
        {
            // Create Test Object
            Board board = new Board();

            // Assert That The Board Is Blank
            Assert.Equal('\0', board.GetPosition(0, 0));
            Assert.Equal('\0', board.GetPosition(0, 1));
            Assert.Equal('\0', board.GetPosition(0, 2));
            Assert.Equal('\0', board.GetPosition(1, 0));
            Assert.Equal('\0', board.GetPosition(1, 1));
            Assert.Equal('\0', board.GetPosition(1, 2));
            Assert.Equal('\0', board.GetPosition(2, 0));
            Assert.Equal('\0', board.GetPosition(2, 1));
            Assert.Equal('\0', board.GetPosition(2, 2));

            // Make a Move
            board.MakeMove('X', 0, 0);

            // Verify That The Move Was Made
            Assert.Equal('X', board.GetPosition(0, 0));
            Assert.Equal('\0', board.GetPosition(0, 1));
            Assert.Equal('\0', board.GetPosition(0, 2));
            Assert.Equal('\0', board.GetPosition(1, 0));
            Assert.Equal('\0', board.GetPosition(1, 1));
            Assert.Equal('\0', board.GetPosition(1, 2));
            Assert.Equal('\0', board.GetPosition(2, 0));
            Assert.Equal('\0', board.GetPosition(2, 1));
            Assert.Equal('\0', board.GetPosition(2, 2));
        }

        [Fact]
        public void ClearBoardTest()
        {
            // Create Test Board
            Board board = new Board();

            /* Test Fill The Board
             *    X | O | X
             *   -----------
             *    O | X | X
             *   -----------
             *    O | O | X
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Assert That The Board Was Filled
            Assert.Equal('X', board.GetPosition(0, 0));
            Assert.Equal('O', board.GetPosition(0, 1));
            Assert.Equal('X', board.GetPosition(0, 2));
            Assert.Equal('O', board.GetPosition(1, 0));
            Assert.Equal('X', board.GetPosition(1, 1));
            Assert.Equal('X', board.GetPosition(1, 2));
            Assert.Equal('O', board.GetPosition(2, 0));
            Assert.Equal('O', board.GetPosition(2, 1));
            Assert.Equal('X', board.GetPosition(2, 2));

            // Clear The Board
            /* Expected After Clearing The Board
             *      |   |  
             *   -----------
             *      |   |  
             *   -----------
             *      |   |  
            */
            board.ClearBoard();

            // Verify That The Board Cleared
            Assert.Equal('\0', board.GetPosition(0, 0));
            Assert.Equal('\0', board.GetPosition(0, 1));
            Assert.Equal('\0', board.GetPosition(0, 2));
            Assert.Equal('\0', board.GetPosition(1, 0));
            Assert.Equal('\0', board.GetPosition(1, 1));
            Assert.Equal('\0', board.GetPosition(1, 2));
            Assert.Equal('\0', board.GetPosition(2, 0));
            Assert.Equal('\0', board.GetPosition(2, 1));
            Assert.Equal('\0', board.GetPosition(2, 2));
        }

        [Fact]
        public void IsBoardFullTest()
        {
            // Create a Test Object
            Board board = new Board();

            // Verify That The Board Should Not Be Full
            Assert.False(board.IsBoardFull());

            /* Test Fill The Board
             *    X | O | X
             *   -----------
             *    O | X | X
             *   -----------
             *    O | O | X
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Assert That The Board Should Be Full
            Assert.True(board.IsBoardFull());

            // Clear The Board
            board.ClearBoard();

            // Assert That The Board Is Not Full
            Assert.False(board.IsBoardFull());

            /* Partially Fill The Board
             *    X |   | X
             *   -----------
             *    O | X | X
             *   -----------
             *    O | O | X
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('\0', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Assert That The Board Is Not Full
            Assert.False(board.IsBoardFull());
        }

        [Fact]
        public void IsWinnerTest()
        {
            // Create a Test Object
            Board board = new Board();

            // Test All Possible Winning Combinations

            /* ----------------------------------
            * Combination 1: Horizontal Top Row X
            * -----------------------------------
            *    X | X | X
            *   -----------
            *      | O |  
            *   -----------
            *    O |   | O
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('\0', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('\0', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('\0', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* ----------------------------------
            * Combination 2: Horizontal Top Row O
            * -----------------------------------
            *    O | O | O
            *   -----------
            *      | X |  
            *   -----------
            *    X |   | X
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('\0', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('\0', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('\0', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /*--------------------------------------
            * Combination 3: Horizontal Middle Row X
            * --------------------------------------
            *      | O |  
            *   -----------
            *    X | X | X
            *   -----------
            *    O |   | O
            */
            board.MakeMove('\0', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('\0', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('\0', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* -------------------------------------
            * Combination 4: Horizontal Middle Row O
            * --------------------------------------
            *      | X |  
            *   -----------
            *    O | O | O
            *   -----------
            *    X |   | X
            */
            board.MakeMove('\0', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('\0', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('\0', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* -------------------------------------
            * Combination 5: Horizontal Bottom Row X
            * --------------------------------------
            *      | O |  
            *   -----------
            *    O |   | O
            *   -----------
            *    X | X | X
            */
            board.MakeMove('\0', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('\0', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('\0', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* -------------------------------------
            * Combination 6: Horizontal Bottom Row O
            * --------------------------------------
            *      | X |  
            *   -----------
            *    X |   | X
            *   -----------
            *    O | O | O
            */
            board.MakeMove('\0', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('\0', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('\0', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* ------------------------------------
            * Combination 7: Vertical Left column X
            * -------------------------------------
            *    X | O | O
            *   -----------
            *    X | O | X
            *   -----------
            *    X | X | O
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* ------------------------------------
            * Combination 8: Vertical Left column O
            * -------------------------------------
            *    O | X | X
            *   -----------
            *    O | X | O
            *   -----------
            *    O | O | X
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* --------------------------------------
            * Combination 9: Vertical Middle column X
            * ---------------------------------------
            *    O | X | O
            *   -----------
            *    X | X | O
            *   -----------
            *    O | X | X
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('X', 2, 2);
           
            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* ---------------------------------------
            * Combination 10: Vertical Middle column O
            * ----------------------------------------
            *    X | O | X
            *   -----------
            *    O | O | X
            *   -----------
            *    X | O | O
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* --------------------------------------
            * Combination 11: Vertical Right column X
            * ---------------------------------------
            *    O | O | X
            *   -----------
            *    X | O | X
            *   -----------
            *    O | X | X
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* --------------------------------------
            * Combination 12: Vertical Right column O
            * ---------------------------------------
            *    X | X | O
            *   -----------
            *    O | X | O
            *   -----------
            *    X | O | O
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* ----------------------------------
            * Combination 13: Diagonal Top Left X
            * -----------------------------------
            *    X | X | O
            *   -----------
            *    O | X | O
            *   -----------
            *    X | O | X
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* ----------------------------------
            * Combination 14: Diagonal Top Left O
            * -----------------------------------
            *    O | O | X
            *   -----------
            *    X | O | X
            *   -----------
            *    O | X | O
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));
            
            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();

            /* -----------------------------------
            * Combination 15: Diagonal Top Right X
            * ------------------------------------
            *    O | O | X
            *   -----------
            *    O | X | O
            *   -----------
            *    X | O | X
            */
            board.MakeMove('O', 0, 0);
            board.MakeMove('O', 0, 1);
            board.MakeMove('X', 0, 2);
            board.MakeMove('O', 1, 0);
            board.MakeMove('X', 1, 1);
            board.MakeMove('O', 1, 2);
            board.MakeMove('X', 2, 0);
            board.MakeMove('O', 2, 1);
            board.MakeMove('X', 2, 2);

            // Expect That X Is The Winner
            Assert.True(board.IsWinner('X'));

            // Expect That O Is Not The Winner
            Assert.False(board.IsWinner('O'));

            // Clear The Board
            board.ClearBoard();

            /* -----------------------------------
            * Combination 16: Diagonal Top Right O
            * ------------------------------------
            *    X | X | O
            *   -----------
            *    X | O | X
            *   -----------
            *    O | X | O
            */
            board.MakeMove('X', 0, 0);
            board.MakeMove('X', 0, 1);
            board.MakeMove('O', 0, 2);
            board.MakeMove('X', 1, 0);
            board.MakeMove('O', 1, 1);
            board.MakeMove('X', 1, 2);
            board.MakeMove('O', 2, 0);
            board.MakeMove('X', 2, 1);
            board.MakeMove('O', 2, 2);

            // Expect That O Is The Winner
            Assert.True(board.IsWinner('O'));

            // Expect That X Is Not The Winner
            Assert.False(board.IsWinner('X'));

            // Clear The Board
            board.ClearBoard();
        }
    }
}