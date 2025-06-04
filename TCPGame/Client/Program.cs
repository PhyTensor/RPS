using System.Net.Sockets;

using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.Utils;

public class Program
{
    public static void Main(string[] args)
    {
        Client client = new Client();
        client.Start();
    }
}

public class Client
{
    public void Start()
    {
        TcpClient client = new TcpClient("127.0.0.1", 5060);
        NetworkStream stream = client.GetStream();

        while (true)
        {
            Choice choice = PromptUtils.PromptForChoice();
            Message message = new Message
            {
                Type = MessageType.Choice,
                Payload = choice.ToString()
            };

            NetworkUtils.SendMessage(stream, message);

            Message response = NetworkUtils.ReceiveMessage(stream);
            Console.WriteLine($"Game Result: {response.Payload}");
        }
    }
}
