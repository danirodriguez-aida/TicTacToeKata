namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    private Board board = new();

    public string GetPlayerTurn() {
        return turn;
    }

    public Board SetMarkOnBoard(Square square) {
        board.SetCoordinate(turn, square);
        turn = turn == "X" ? "Y" : "X";
        return board;
    }
}