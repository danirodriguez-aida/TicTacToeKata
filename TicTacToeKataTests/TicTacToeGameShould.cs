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

        [Test]
        public void set_mark_on_the_board_when_playerX_plays()
        {
            var ticTacToeGame = new TicTacToeGame();

            var board = ticTacToeGame.SetMarkOnBoard(0,0);

            board[0, 0].Should().Be("X");
        }
    }

    public class TicTacToeGame
    {
        public string GetPlayerTurn()
        {
            return "X";
        }

        public string[,] SetMarkOnBoard(int x, int y)
        {
            var board = new string[3, 3];
            board[0, 0] = "X";
            return board;
        }
    }
}