using FluentAssertions;

namespace TicTacToeKataTests {
    public class TicTacToeGameShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_playerX_to_start()
        {
            var ticTacToeGame = new TicTacToeGame();

            var playerTurn = ticTacToeGame.GetPlayerTurn();
                
            playerTurn.Should().Be("X");
        }
    }

    public class TicTacToeGame
    {
        public string GetPlayerTurn()
        {
            return "X";
        }
    }
}