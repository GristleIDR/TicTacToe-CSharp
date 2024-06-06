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
    }
}