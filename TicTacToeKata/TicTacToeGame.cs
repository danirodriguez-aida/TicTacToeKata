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
        var playerXWinInRow = sizeBoard.Any(r => IsSameSymbolForRow(r, "X"));
        var playerXWinInColumn = sizeBoard.Any(r => IsSameSymbolForColumn(r, "X"));
        var playerXWinInDiagonal = IsSameSymbolForDiagonal(true, "X") || IsSameSymbolForDiagonal(false, "X");

        var playerYWinInRow = sizeBoard.Any(r => IsSameSymbolForRow(r, "Y"));
        var playerYWinInColumn = sizeBoard.Any(r => IsSameSymbolForColumn(r, "Y"));

        if (playerXWinInRow || playerXWinInColumn || playerXWinInDiagonal)
            return "Player X";
        if (playerYWinInRow || playerYWinInColumn)  return "Player Y";
        return string.Empty;
    }

    private bool IsSameSymbolForRow(int row, string symbol) {
        return GetSquaresForRow(row).All(s => board.GetSymbol(s) == symbol);
    }

    private bool IsSameSymbolForColumn(int column, string symbol) {
        return GetSquaresForColumn(column).All(s => board.GetSymbol(s) == symbol);
    }
    private bool IsSameSymbolForDiagonal(bool isLeftUpToRightDown, string symbol) {
        return GetSquaresForDiagonal(isLeftUpToRightDown).All(s => board.GetSymbol(s) == symbol);
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

    private static IEnumerable<Square> GetSquaresForDiagonal(bool isLeftUpToRightDown) {
        if (isLeftUpToRightDown) {
            return new List<Square>()
            {
                new(0,0), new (1,1), new (2,2)
            };
        }
        return new List<Square>()
        {
            new(0,2), new (1,1), new (2,0)
        };
    }
}