namespace TicTacToeKataTests;

public class Player
{
    public Symbol Symbol { get; }

    public Player(Symbol symbol)
    {
        Symbol = symbol;
    }

    public string GetDescription()
    {
        return $"Player {Symbol}";
    }
}