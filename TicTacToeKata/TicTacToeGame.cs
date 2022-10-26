namespace TicTacToeKataTests;

public class TicTacToeGame {
    private const string Player1 = "X";
    private const string Player2 = "Y";

    private string turnPlayer = Player1;
    private Board board = new();

    public string GetPlayerTurn() {
        return turnPlayer;
    }

    public Board SetMarkOnBoard(Square square) {
        board.SetSymbol(new Symbol(turnPlayer), square);
        turnPlayer = turnPlayer == Player1 ? Player2 : Player1;
        return board;
    }

    public string GetWinner() {
        var sizeBoard = new[] { 0, 1, 2 };
        var playerXWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, Player1));
        var playerXWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, Player1));
        var playerXWinInDiagonal = board.IsSameSymbolForDiagonal(true, Player1) || board.IsSameSymbolForDiagonal(false, Player1);

        var playerYWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, Player2));
        var playerYWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, Player2));
        var playerYWinInDiagonal = board.IsSameSymbolForDiagonal(true, Player2) || board.IsSameSymbolForDiagonal(false, Player2);

        if (playerXWinInRow || playerXWinInColumn || playerXWinInDiagonal) return $"Player {Player1}";
        if (playerYWinInRow || playerYWinInColumn || playerYWinInDiagonal) return $"Player {Player2}";
        return string.Empty;
    }
}