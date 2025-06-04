using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Players;

public class ForcedPlayer : IPlayer
{
    private Choice _choice;

    public ForcedPlayer(Choice choice)
    {
        _choice = choice;
    }

    public Choice GetChoice()
    {
        return _choice;
    }
}
