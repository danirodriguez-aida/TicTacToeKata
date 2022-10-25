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
        var rows = new[] { 0, 1, 2 };
        var columns = new[] { 0, 1, 2 };
        var playerXWinInRow = rows.Any(r => IsSameSymbolForRow(r, "X"));
        var playerXWinInColumn = rows.Any(r => IsSameSymbolForColumn(r, "X"));
        if (playerXWinInRow || playerXWinInColumn)
            return "Player X";
        return string.Empty;
    }

    private bool IsSameSymbolForRow(int row, string symbol) {
        return GetSquaresForRow(row).All(s => board.GetSymbol(s) == symbol);
    }
    private bool IsSameSymbolForColumn(int column, string symbol) {
        return GetSquaresForColumn(column).All(s => board.GetSymbol(s) == symbol);
    }
    private static IEnumerable<Square> GetSquaresForRow(int row) {
        return new List<Square>()
        {
            new(row, 0), new (row, 1), new (row, 2)
        };
    }

    private static IEnumerable<Square> GetSquaresForColumn(int column) {
        return new List<Square>()
        {
            new(0,column), new (1,column), new (2,column)
        };
    }
}