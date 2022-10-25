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

        [Test]
        public void return_playerY_after_playerX_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("Y");
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        public void set_mark_on_the_board_when_playerX_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();

            var board = ticTacToeGame.SetMarkOnBoard(new Square(x, y));

            board.GetSymbol(new Square(x, y)).Should().Be("X");
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        public void set_mark_on_the_board_when_playerY_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));

            var board = ticTacToeGame.SetMarkOnBoard(new Square(x, y));

            board.GetSymbol(new Square(x, y)).Should().Be("Y");
        }

        [Test]
        public void return_playerX_after_playerY_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("X");
        }

        [Test]
        public void fail_when_playing_the_same_coordinate() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 0));

            Action action = () => ticTacToeGame.SetMarkOnBoard(new Square(0, 0));

            action.Should().Throw<UsedCoordinateException>();
        }

        [Test]
        public void without_winner() {
            var ticTacToeGame = new TicTacToeGame();

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be(string.Empty);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 0)]
        public void playerX_wins_for_row(int xPlayerX, int xPlayerY) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayerX, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayerY, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayerX, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayerY, 2));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayerX, 2));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player X");
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 0)]
        public void playerX_wins_for_column(int yPlayerX, int yPlayerY) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayerX));
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayerY));
            ticTacToeGame.SetMarkOnBoard(new Square(1, yPlayerX));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayerY));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayerX));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player X");
        }
    }
}