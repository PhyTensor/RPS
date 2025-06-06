using Microsoft.AspNetCore.SignalR.Client;
using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Models;
using RockPaperScissorsLib.Utils;

Console.Write("Enter you username: ");
string username = Console.ReadLine()?.Trim() ?? "Anonymous";

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5080/gamehub")
    .WithAutomaticReconnect()
    .Build();


connection.On<GameResult>("ReceiveResult", result =>
        {
            Console.WriteLine("\n");
            Console.WriteLine($"{result.Player1Username} Chose: {result.Player1Choice}");
            Console.WriteLine($"{result.Player2Username} Chose: {result.Player2Choice}");
            Console.WriteLine($"Result: {result.Result}\n");
        });

await connection.StartAsync();
Console.WriteLine("Connected to game server.");

await connection.InvokeAsync("Register", username);

while (true)
{
    Choice choice = PromptUtils.PromptForChoice();

    await connection.InvokeAsync("MakeChoice", choice);
}
