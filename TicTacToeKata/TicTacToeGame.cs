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

    public string GetWinner()
    {
        var squaresColumn0 = new List<Square>()
        {
            new Square(0, 0), new Square(0, 1),new Square(0, 2)
        };
        var squaresColumn1 = new List<Square>()
        {
            new Square(1, 0), new Square(1, 1),new Square(1, 2)
        };

        var allXforColumn0 = squaresColumn0.All(s => board.GetSymbol(s) == "X");
        var allXforColumn1 = squaresColumn1.All(s => board.GetSymbol(s) == "X");

        if (allXforColumn0 ||  allXforColumn1)
            return "Player X";
        return string.Empty;
    }
}