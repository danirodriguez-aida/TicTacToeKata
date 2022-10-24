namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    private string[,] board = new string[3, 3];

    public string GetPlayerTurn() {
        return turn;
    }

    public string[,] SetMarkOnBoard(int x, int y) {
        if (board[x, y] != null) throw new UsedCoordinateException();
        board[x, y] = turn;
        turn = turn == "X" ? "Y" : "X";
        return board;
    }
}