namespace TicTacToeKataTests;

public class TicTacToeGame {
    private readonly Player Player1 = new(Symbol.X);
    private readonly Player Player2 = new(Symbol.Y);
    private Player turnPlayer;
    private Board board = new();

    public TicTacToeGame()
    {
        turnPlayer = Player1;
    }

    public string GetPlayerTurn() {
        return turnPlayer.Symbol.ToString();
    }

    public Board SetMarkOnBoard(Square square) {
        board.SetSymbol(turnPlayer.Symbol, square);
        turnPlayer = turnPlayer == Player1 ? Player2 : Player1;
        return board;
    }

    public string GetWinner() {
        var sizeBoard = new[] { 0, 1, 2 };
        var playerXWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, Player1.Symbol));
        var playerXWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, Player1.Symbol));
        var playerXWinInDiagonal = board.IsSameSymbolForDiagonal(true, Player1.Symbol) || board.IsSameSymbolForDiagonal(false, Player1.Symbol);

        var playerYWinInRow = sizeBoard.Any(r => board.IsSameSymbolForRow(r, Player2.Symbol));
        var playerYWinInColumn = sizeBoard.Any(r => board.IsSameSymbolForColumn(r, Player2.Symbol));
        var playerYWinInDiagonal = board.IsSameSymbolForDiagonal(true, Player2.Symbol) || board.IsSameSymbolForDiagonal(false, Player2.Symbol);

        if (playerXWinInRow || playerXWinInColumn || playerXWinInDiagonal) return Player1.GetDescription();
        if (playerYWinInRow || playerYWinInColumn || playerYWinInDiagonal) return Player2.GetDescription();
        return string.Empty;
    }
}