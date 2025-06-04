using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Players;

namespace RockPaperScissorsLib.GameManagers;

public class GameManager
{
    public RoundResult PlayRound(IPlayer player1, IPlayer player2)
    {
        Choice player1Choice = player1.GetChoice();
        Choice player2Choice = player2.GetChoice();

        Console.WriteLine($"Player 1 picks: {player1Choice.ToString()}");
        Console.WriteLine($"Player 2 picks: {player2Choice.ToString()}");

        return DetermineResult(player1Choice, player2Choice);
    }

    public RoundResult DetermineResult(Choice c1, Choice c2)
    {
        if (c1 == c2) return RoundResult.Draw;

        if (
                (c1 == Choice.Rock && c2 == Choice.Scissors)
                || (c1 == Choice.Paper && c2 == Choice.Rock)
                || (c1 == Choice.Scissors && c2 == Choice.Paper)
            )
            return RoundResult.Player1Win;
        else
            return RoundResult.Player2Win;
    }
}
