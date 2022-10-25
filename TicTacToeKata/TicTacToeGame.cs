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

    public string GetWinner()
    {
        if (board.GetCoordinate(0, 0) == "X" && board.GetCoordinate(0, 1) == "X" && board.GetCoordinate(0, 2) == "X")
            return "Player X";
        return string.Empty;
    }
}