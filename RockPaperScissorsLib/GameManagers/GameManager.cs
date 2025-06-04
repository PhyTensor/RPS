using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Players;

namespace RockPaperScissorsLib.GameManagers;

public class GameManager
{
    private IPlayer _player1;
    private IPlayer _player2;

    public GameManager(IPlayer player1, IPlayer player2)
    {
        _player1 = player1;
        _player2 = player2;
    }

    public RoundResult PlayRound()
    {
        Choice player1Choice = _player1.GetChoice();
        Choice player2Choice = _player2.GetChoice();

        Console.WriteLine($"Player 1 picks: {player1Choice.ToString()}");
        Console.WriteLine($"Player 2 picks: {player2Choice.ToString()}");

        if (player1Choice == player2Choice)
        {
            return RoundResult.Draw;
        }

        if (
            player1Choice == Choice.Rock && player2Choice == Choice.Scissors
            || player1Choice == Choice.Paper && player2Choice == Choice.Rock
            || player1Choice == Choice.Scissors && player2Choice == Choice.Paper
        )
        {
            return RoundResult.Player1Win;
        }

        return RoundResult.Player2Win;
    }
}
