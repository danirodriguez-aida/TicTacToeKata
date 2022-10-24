namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    public string GetPlayerTurn() {
        return turn;
    }

    public string[,] SetMarkOnBoard(int x, int y) {
        var board = new string[3, 3];
        board[x, y] = "X";
        turn = turn == "X" ? "Y" : "X";
        return board;
    }
}