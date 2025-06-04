using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.GameManagers;
using RockPaperScissorsLib.Players;

namespace SinglePlayerGame;

public class Program
{
    public static void Main(string[] args)
    {
        // GameManager gm = new GameManager(new ComputerPlayer(), new ComputerPlayer());
        GameManager gm = new GameManager(new HumanPlayer(), new ComputerPlayer());
        // GameManager gm = new GameManager(new HumanPlayer(), new HumanPlayer());

        do
        {
            RoundResult result = gm.PlayRound();

            if (result == RoundResult.Player1Win)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (result == RoundResult.Player2Win)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

            Console.Write("Play Again (Y/N)? ");
        } while (Console.ReadLine()!.ToUpper() == "Y");
    }
}
