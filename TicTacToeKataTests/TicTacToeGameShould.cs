using FluentAssertions;

namespace TicTacToeKataTests {
    public class TicTacToeGameShould {
        [Test]
        public void return_player1_to_start() {
            var ticTacToeGame = new TicTacToeGame();

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("Player X");
        }

        [Test]
        public void return_player2_after_player1_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("Player O");
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        public void set_mark_on_the_board_when_player1_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();

            var board = ticTacToeGame.SetMarkOnBoard(new Square(x, y));

            board.GetSymbol(new Square(x, y)).Should().Be(Symbol.X);
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        public void set_mark_on_the_board_when_player2_plays_coordinates(int x, int y) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));

            var board = ticTacToeGame.SetMarkOnBoard(new Square(x, y));

            board.GetSymbol(new Square(x, y)).Should().Be(Symbol.O);
        }

        [Test]
        public void return_player1_after_player2_plays() {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));

            var playerTurn = ticTacToeGame.GetPlayerTurn();

            playerTurn.Should().Be("Player X");
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
        public void player1_wins_for_row(int xPlayer1, int xPlayer2) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer2, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer2, 2));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1, 2));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player X");
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 0)]
        public void player1_wins_for_column(int yPlayer1, int yPlayer2) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer1));
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer2));
            ticTacToeGame.SetMarkOnBoard(new Square(1, yPlayer1));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer2));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer1));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player X");
        }

        [TestCase(0, 2)]
        [TestCase(2, 0)]
        public void player1_wins_for_diagonal(int yPlayer1First, int yPlayer1Last) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer1First));
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer1Last));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player X");
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(0, 2)]
        public void player2_wins_for_row(int xPlayer1, int xPlayer2) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer2, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer2, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer1 == 2 ? 0 : xPlayer1 + 1, 2));
            ticTacToeGame.SetMarkOnBoard(new Square(xPlayer2, 2));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player O");
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(0, 2)]
        public void player2_wins_for_column(int yPlayer1, int yPlayer2) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer1));
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer2));
            ticTacToeGame.SetMarkOnBoard(new Square(1, yPlayer1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, yPlayer2));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer1 == 2 ? 0 : yPlayer1 + 1));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer2));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player O");
        }

        [TestCase(0, 2)]
        [TestCase(2, 0)]
        public void player2_wins_for_diagonal(int yPlayer2First, int yPlayer2Last) {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.SetMarkOnBoard(new Square(0, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(0, yPlayer2First));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 0));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 1));
            ticTacToeGame.SetMarkOnBoard(new Square(1, 2));
            ticTacToeGame.SetMarkOnBoard(new Square(2, yPlayer2Last));

            var winner = ticTacToeGame.GetWinner();

            winner.Should().Be("Player O");
        }
    }
}