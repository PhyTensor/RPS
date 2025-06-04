using System.Net.Sockets;
using System.Text;

namespace RockPaperScissorsLib.Utils;

public static class NetworkUtils
{
    public static void SendMessage(NetworkStream stream, Message message)
    {
        string json = Message.Serialise(message);
        byte[] bytes = Encoding.UTF8.GetBytes(json + "\n");
        stream.Write(bytes, 0, bytes.Length);
    }

    public static Message ReceiveMessage(NetworkStream stream)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
        string? json = reader.ReadLine();
        return Message.Deserialise(json!);
    }
}
