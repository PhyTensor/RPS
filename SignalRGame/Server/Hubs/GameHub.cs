using Microsoft.AspNetCore.SignalR;
using RockPaperScissorsLib.GameManagers;
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

            foreach (KeyValuePair<string, Choice> player in players)
                Console.WriteLine($"{player.Key} picked {player.Value}");

            KeyValuePair<string, Choice> player1 = players[0];
            KeyValuePair<string, Choice> player2 = players[1];

            GameManager gm = new GameManager();
            RoundResult result = gm.DetermineResult(player1.Value, player2.Value);

            GameResult gameResult = new GameResult
            {
                Player1ConnectionId = player1.Key, // connection id of player 1
                Player2ConnectionId = player2.Key, // connection id of player 2
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
}
