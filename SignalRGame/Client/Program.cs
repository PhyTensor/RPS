using Microsoft.AspNetCore.SignalR.Client;
using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Models;
using RockPaperScissorsLib.Utils;

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5080/gamehub")
    .WithAutomaticReconnect()
    .Build();


connection.On<GameResult>("ReceiveResult", result =>
        {
            Console.WriteLine("Game Result Received!");
            Console.WriteLine($"You Chose: {result.Player1Choice}");
            Console.WriteLine($"Opponent Chose: {result.Player2Choice}");
            Console.WriteLine($"Result: {result.Result}\n");
        });

await connection.StartAsync();
Console.WriteLine("Connected to game server.");

while (true)
{
    Choice choice = PromptUtils.PromptForChoice();

    await connection.InvokeAsync("MakeChoice", choice);
}
