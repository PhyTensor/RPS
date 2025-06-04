using System.Text.Json;
using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Utils;

public class Message
{
    public required MessageType Type { get; set; }
    public required string Payload { get; set; }

    public static string Serialise(Message message)
    {
        return JsonSerializer.Serialize(message);
    }

    public static Message Deserialise(string message)
    {
        return JsonSerializer.Deserialize<Message>(message);
    }
}


