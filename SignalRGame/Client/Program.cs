using Microsoft.AspNetCore.SignalR.Client;
using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Models;

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5080/gamehub")
    .WithAutomaticReconnect()
    .Build();


connection.On<GameResult>("ReceiveResult", result =>
        {
            Console.WriteLine($"You Chose: {result.Player1Choice}");
            Console.WriteLine($"Opponent Chose: {result.Player2Choice}");
            Console.WriteLine($"Result: {result.Result}");
        });

await connection.StartAsync();
Console.WriteLine("Connected to game server.");

while (true)
{
    Console.WriteLine("Enter your choice (R, P, S): ");

    string input = Console.ReadLine();

    if (Enum.TryParse<Choice>(input, out Choice choice))
    {
        await connection.InvokeAsync("MakeChoice", choice);
    }
    else
    {
        Console.WriteLine("Invalid choice. Try again!");
    }
}
