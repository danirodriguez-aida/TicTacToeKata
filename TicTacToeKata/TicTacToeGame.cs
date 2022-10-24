namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    private Board board = new();

    public string GetPlayerTurn() {
        return turn;
    }

    public Board SetMarkOnBoard(Coordinate coordinate) {
        board.SetCoordinate(turn, coordinate.X, coordinate.Y);
        turn = turn == "X" ? "Y" : "X";
        return board;
    }
}