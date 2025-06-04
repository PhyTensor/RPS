using Microsoft.AspNetCore.SignalR;
using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Models;

namespace SignalRGame.Server.Hubs;

public class GameHub : Hub
{
    private static readonly Dictionary<string, Choice> PlayerChoices = new();
    private static readonly object Lock = new();

    public async Task MakeChoice(Choice choice)
    {
        lock (Lock)
        {
            PlayerChoices[Context.ConnectionId] = choice;
        }

        if (PlayerChoices.Count == 2)
        {
            List<KeyValuePair<string, Choice>> players = PlayerChoices.ToList();
            KeyValuePair<string, Choice> player1 = players[0];
            KeyValuePair<string, Choice> player2 = players[1];

            RoundResult result = DetermineResult(player1.Value, player2.Value);

            GameResult gameResult = new GameResult
            {
                Player1ConnectionId = player1.Key,
                Player2ConnectionId = player2.Key,
                Player1Choice = player1.Value,
                Player2Choice = player2.Value,
                Result = result
            };

            await Clients.Client(player1.Key).SendAsync("ReceiveResult", gameResult);
            await Clients.Client(player2.Key).SendAsync("ReceiveResult", gameResult);

            lock (Lock)
            {
                PlayerChoices.Clear();
            }
        }
    }

    public RoundResult DetermineResult(Choice c1, Choice c2)
    {
        if (c1 == c2) return RoundResult.Draw;

        if (c1 == Choice.Rock && c2 == Choice.Scissors)
            return RoundResult.Player1Win;
        else if (c1 == Choice.Paper && c2 == Choice.Rock)
            return RoundResult.Player1Win;
        else if (c1 == Choice.Scissors && c2 == Choice.Paper)
            return RoundResult.Player1Win;
        else
            return RoundResult.Player2Win;
    }
}
