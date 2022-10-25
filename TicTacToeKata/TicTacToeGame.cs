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

        var allXForColumn0 = IsSameSymbolForRow(0, "X");
        var allXForColumn1 = IsSameSymbolForRow(1, "X");
        var allXForColumn2 = IsSameSymbolForRow(2, "X");

        if (allXForColumn0 || allXForColumn1 || allXForColumn2)
            return "Player X";
        return string.Empty;
    }

    private bool IsSameSymbolForRow(int row, string symbol)
    {
        return GetSquaresForRow(row).All(s => board.GetSymbol(s) == symbol);
    }

    private static IEnumerable<Square> GetSquaresForRow(int row) {
        return new List<Square>()
        {
            new(row, 0), new (row, 1), new (row, 2)
        };
    }
}