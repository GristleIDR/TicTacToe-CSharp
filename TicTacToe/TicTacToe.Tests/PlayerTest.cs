namespace TicTacToe.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void ConstructorTest()
        {
            // Create Test Object
            Player testPlayer1 = new Player("Bob", 'X');
            Player testPlayer2 = new Player();

            // Assertions
            Assert.True(testPlayer1.GetUsername() == "Bob");
            Assert.True(testPlayer1.GetSymbol() == 'X');
            Assert.True(testPlayer2.GetUsername() == "");
            Assert.True(testPlayer2.GetSymbol() == '\0');
        }

        [Fact]
        public void SetUsernameTest()
        {
            // Create Test Object
            Player testPlayer = new Player();

            // Set The Username
            testPlayer.SetUsername("test");

            // Assertions
            Assert.Equal("test", testPlayer.GetUsername());
            Assert.Equal('\0', testPlayer.GetSymbol());
        }

        [Fact]
        public void SetSymbolTest()
        {
            // Create Test Object
            Player testPlayer = new Player();

            // Set The Symbol
            testPlayer.SetSymbol('O');

            // Assertions
            Assert.Equal("", testPlayer.GetUsername());
            Assert.Equal('O', testPlayer.GetSymbol());
        }

        [Fact]
        public void IncrementWinsTest()
        {
            // Create Test Object
            Player player = new Player();

            // Assert Default Values
            Assert.Equal("", player.GetUsername());
            Assert.Equal('\0', player.GetSymbol());
            Assert.Equal(0, player.GetWins());
            Assert.Equal(0, player.GetLosses());

            // Increment Wins
            player.IncrementWins();

            // Verify That Wins Incremented and Didn't Change Other Values
            Assert.Equal("", player.GetUsername());
            Assert.Equal('\0', player.GetSymbol());
            Assert.Equal(1, player.GetWins());
            Assert.Equal(0, player.GetLosses());
        }

        [Fact]
        public void IncrementLossesTest()
        {
            // Create Test Object
            Player player = new Player();

            // Assert Default Values
            Assert.Equal("", player.GetUsername());
            Assert.Equal('\0', player.GetSymbol());
            Assert.Equal(0, player.GetWins());
            Assert.Equal(0, player.GetLosses());

            // Increment Losses
            player.IncrementLosses();

            // Verify That Wins Incremented and Didn't Change Other Values
            Assert.Equal("", player.GetUsername());
            Assert.Equal('\0', player.GetSymbol());
            Assert.Equal(0, player.GetWins());
            Assert.Equal(1, player.GetLosses());
        }
    }
}