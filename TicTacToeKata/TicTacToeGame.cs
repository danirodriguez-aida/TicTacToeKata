namespace TicTacToeKataTests;

public class TicTacToeGame {
    private string turn = "X";
    private Board board = new();

    public string GetPlayerTurn() {
        return turn;
    }

    public Board SetMarkOnBoard(Square square) {
        board.SetSymbol(turn, square);
        turn = turn == "X" ? "Y" : "X";
        return board;
    }

    public string GetWinner() {
        var sizeBoard = new[] { 0, 1, 2 };
        var playerXWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, "X"));
        var playerXWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, "X"));
        var playerXWinInDiagonal = board.IsSameSymbolForDiagonal(true, "X") || board.IsSameSymbolForDiagonal(false, "X");

        var playerYWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, "Y"));
        var playerYWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, "Y"));
        var playerYWinInDiagonal = board.IsSameSymbolForDiagonal(true, "Y") || board.IsSameSymbolForDiagonal(false, "Y");

        if (playerXWinInRow || playerXWinInColumn || playerXWinInDiagonal)
            return "Player X";
        if (playerYWinInRow || playerYWinInColumn || playerYWinInDiagonal)  return "Player Y";
        return string.Empty;
    }
}