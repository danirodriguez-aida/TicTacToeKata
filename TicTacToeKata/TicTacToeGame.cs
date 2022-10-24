namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    private Board board = new();

    public string GetPlayerTurn() {
        return turn;
    }

    public Board SetMarkOnBoard(int x, int y) {
        board.SetCoordinate(turn,x ,y);
        turn = turn == "X" ? "Y" : "X";
        return board;
    }
}