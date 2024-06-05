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
            Assert.True(testPlayer1.getUsername() == "Bob");
            Assert.True(testPlayer1.getSymbol() == 'X');
            Assert.True(testPlayer2.getUsername() == "");
            Assert.True(testPlayer2.getSymbol() == '\0');
        }

        [Fact]
        public void SetUsernameTest()
        {
            // Create Test Object
            Player testPlayer = new Player();

            // Set The Username
            testPlayer.setUsername("test");

            // Assertions
            Assert.Equal("test", testPlayer.getUsername());
            Assert.Equal('\0', testPlayer.getSymbol());
        }

        [Fact]
        public void SetSymbolTest()
        {
            // Create Test Object
            Player testPlayer = new Player();

            // Set The Symbol
            testPlayer.setSymbol('O');

            // Assertions
            Assert.Equal("", testPlayer.getUsername());
            Assert.Equal('O', testPlayer.getSymbol());
        }

    }
}