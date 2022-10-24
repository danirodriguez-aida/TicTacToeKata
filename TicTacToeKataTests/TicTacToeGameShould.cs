using FluentAssertions;

namespace TicTacToeKataTests {
    public class TicTacToeGameShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_playerX_to_start() {
            var ticTacToeGame = new TicTacToeGame();

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("X");
        }

        [TestCase(0,0)]
        [TestCase(0,1)]
        public void set_mark_on_the_board_when_playerX_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();

            var board = ticTacToeGame.SetMarkOnBoard(x, y);

            board.GetCoordinate(x, y).Should().Be("X");
        }

        [TestCase(0,0)]
        [TestCase(0,1)]
        public void set_mark_on_the_board_when_playerY_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(1, 1);

            var board = ticTacToeGame.SetMarkOnBoard(x, y);

            board.GetCoordinate(x, y).Should().Be("Y");
        }

        [Test]
        public void return_playerY_after_playerX_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(0, 1);

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("Y");
        }

        [Test]
        public void return_playerX_after_playerY_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(0, 1);
            ticTacToeGame.SetMarkOnBoard(1, 1);

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("X");
        }

        [Test]
        public void fail_when_playing_the_same_coordinate() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(0, 0);

            Action action = () => ticTacToeGame.SetMarkOnBoard(0, 0);

            action.Should().Throw<UsedCoordinateException>();
        }
    }
}