using System.Net;
using System.Net.Sockets;
using RockPaperScissorsLib.Utils;
using RockPaperScissorsLib.GameManagers;
using RockPaperScissorsLib.Players;
using RockPaperScissorsLib.Enums;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        Server server = new Server();
        server.Start();
    }
}

public class Server
{
    private TcpListener _listener;

    public Server()
    {
        _listener = new TcpListener(IPAddress.Any, 5060);
    }

    public void Start()
    {
        _listener.Start();
        Console.WriteLine("Server started...");
        Console.WriteLine("Waiting for two players to connect...");

        var client1 = _listener.AcceptTcpClient();
        Console.WriteLine("Client 1 connected");
        var client2 = _listener.AcceptTcpClient();
        Console.WriteLine("Client 2 connected");
        Console.WriteLine("Clients connected!");

        var stream1 = client1.GetStream();
        var stream2 = client2.GetStream();

        while (true)
        {
            Message message1 = NetworkUtils.ReceiveMessage(stream1);
            Message message2 = NetworkUtils.ReceiveMessage(stream2);

            Choice choice1 = Enum.Parse<Choice>(message1.Payload);
            Choice choice2 = Enum.Parse<Choice>(message2.Payload);

            GameManager gm = new GameManager();
            RoundResult result = gm.PlayRound(
                new ForcedPlayer(choice: choice1),
                new ForcedPlayer(choice: choice2)
            );

            Message resultMessage = new Message
            {
                Type = MessageType.Result,
                Payload = result.ToString()
            };

            NetworkUtils.SendMessage(stream1, resultMessage);
            NetworkUtils.SendMessage(stream2, resultMessage);

            if (result == RoundResult.Player1Win)
                Console.WriteLine("Player 1 wins!");
            else if (result == RoundResult.Player2Win)
                Console.WriteLine("Player 2 wins!");
            else
                Console.WriteLine("Draw!");

        }
    }
}
