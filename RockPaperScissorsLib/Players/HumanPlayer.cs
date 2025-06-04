using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Utils;

namespace RockPaperScissorsLib.Players;

public class HumanPlayer : IPlayer
{
    public Choice GetChoice()
    {
        Choice choice = PromptUtils.PromptForChoice();
        return choice;
    }
}
