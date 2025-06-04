using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Players;

public class ComputerPlayer : IPlayer
{
    private Random _rng = new Random();

    public Choice GetChoice()
    {
        Choice choice = (Choice)_rng.Next(0, 3);

        return choice;
    }
}
