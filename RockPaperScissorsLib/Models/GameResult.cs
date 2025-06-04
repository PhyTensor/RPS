using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Models;

public class GameResult
{
    public required string Player1ConnectionId { get; set; }
    public required string Player2ConnectionId { get; set; }
    public Choice Player1Choice { get; set; }
    public Choice Player2Choice { get; set; }
    public RoundResult Result { get; set; }
}
